using System.Threading.Tasks;
using Common.Log;
using Lykke.Common.Log;
using Lykke.Common.MsSql;
using Lykke.Service.CrossChainWalletLinker.Domain.Models;
using Lykke.Service.CrossChainWalletLinker.Domain.Repositories;
using Lykke.Service.CrossChainWalletLinker.MsSqlRepositories.Entities;

namespace Lykke.Service.CrossChainWalletLinker.MsSqlRepositories
{
    public class WalletLinkingRequestsCounterRepository : IWalletLinkingRequestsCounterRepository
    {
        private readonly MsSqlContextFactory<WalletLinkingContext> _contextFactory;
        private readonly ILog _log;
        
        public WalletLinkingRequestsCounterRepository(
            MsSqlContextFactory<WalletLinkingContext> contextFactory, 
            ILogFactory logFactory)
        {
            _contextFactory = contextFactory;
            _log = logFactory.CreateLog(this);
        }

        public async Task UpsertAsync(string customerId, int approvalsCounter, TransactionContext txContext = null)
        {
            using (var context = _contextFactory.CreateDataContext(txContext))
            {
                var entity = await context.LinkingRequestsCounter.FindAsync(customerId);

                if (entity == null)
                {
                    entity = WalletLinkingRequestsCounterEntity.Create(customerId, approvalsCounter);

                    context.LinkingRequestsCounter.Add(entity);
                    
                    _log.Info($"Counter was not found for customer {customerId}, creating one.");
                }
                else
                {
                    entity.ApprovalsCounter = approvalsCounter;
                    
                    _log.Info($"Counter was found for customer {customerId}, updating one.");
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task<IWalletLinkingRequestsCounter> GetAsync(string customerId, TransactionContext txContext = null)
        {
            using (var context = _contextFactory.CreateDataContext(txContext))
            {
                var counter = await context.LinkingRequestsCounter.FindAsync(customerId);

                return counter;
            }
        }
    }
}
