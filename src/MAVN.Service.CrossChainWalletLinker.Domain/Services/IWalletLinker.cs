using System;
using System.Threading.Tasks;
using MAVN.Service.CrossChainWalletLinker.Domain.Models;

namespace MAVN.Service.CrossChainWalletLinker.Domain.Services
{
    public interface IWalletLinker
    {
        Task<LinkingRequestResultModel> CreateLinkRequestAsync(Guid customerId);
        
        Task<LinkingApprovalResultModel> ApproveLinkRequestAsync(string privateAddress, string publicAddress, string signature);

        Task<UnlinkResultModel> UnlinkAsync(Guid customerId);

        Task<ConfirmationResultModel> ConfirmInPrivateAsync(string privateAddress);
        
        Task<ConfirmationResultModel> ConfirmInPublicAsync(string privateAddress);

        Task<IWalletLinkingRequest> GetByPrivateAddressAsync(string privateAddress);
    }
}
