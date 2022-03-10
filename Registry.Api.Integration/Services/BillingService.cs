using Registry.Api.Integration.Dto.Requests;
using Registry.Api.Integration.Dto.Responses;
using Registry.Api.Integration.Integration;
using Registry.Api.Integration.Service.Interfaces;

using Google.Cloud.PubSub.V1;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace Registry.Api.Integration.Service
{
	public class BillingService : IBillingService
	{
		private readonly GCSettings settings;

		public BillingService(IOptions<GCSettings> settings)
		{
			this.settings = settings.Value;
		}

		public async Task<AssignResponse> Assign(AssignRequest request)
		{
			var topic = TopicName.FromProjectTopic(settings.ProjectId, settings.PublishId);
			var publisher = await PublisherClient.CreateAsync(topic);

			var message = JsonConvert.SerializeObject(request);
			await publisher.PublishAsync(message);

			var subscription = SubscriptionName.FromProjectSubscription(settings.ProjectId, settings.SubscriptionId);
			var subscriberClient = await SubscriberServiceApiClient.CreateAsync();

			var messages = await subscriberClient.PullAsync(subscription, 20);
			await subscriberClient.AcknowledgeAsync(subscription, messages.ReceivedMessages.Select(m => m.AckId));

			var latestMessage = messages.ReceivedMessages.LastOrDefault();

			if (latestMessage == null)
			{
				throw new Exception("receiving error");
			}

			var response = System.Text.Encoding.UTF8.GetString(latestMessage.Message.Data.ToArray());
			var result = JsonConvert.DeserializeObject<AssignResponse>(response);

			return result;
		}
	}
}
