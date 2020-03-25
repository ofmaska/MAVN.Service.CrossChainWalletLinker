using Lykke.Service.CrossChainWalletLinker.Domain.Enums;
using Lykke.Service.CrossChainWalletLinker.Domain.Models;

namespace Lykke.Service.CrossChainWalletLinker.Domain.Services
{
    public interface IBlockchainEventDecoder
    {
        PublicAccountLinkedDto DecodePublicAccountLinkedEvent(string[] topics, string data);

        PublicAccountUnlinkedDto DecodePublicAccountUnlinkedEvent(string[] topics, string data);

        BlockchainEventType GetEventType(string topic);
    }
}
