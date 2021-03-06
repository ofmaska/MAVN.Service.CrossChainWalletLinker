using System.Threading.Tasks;

namespace MAVN.Service.CrossChainWalletLinker.Domain.RabbitMq.Publishers
{
    public interface IPushNotificationsPublisher
    {

        Task PublishWalletLinkingSuccessfulAsync(string customerId);

        Task PublishWalletLinkingUnsuccessfulAsync(string customerId);

        Task PublishWalletUnlinkingSuccessfulAsync(string customerId);

        Task PublishWalletUnlinkingUnsuccessfulAsync(string customerId);
    }
}
