
using Apl.ERP.API.Infra;
using Apl.ERP.API.Repositories;
using Apl.ERP.API.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MedGrupo.Infra
{
    public static class Injector
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<ConnectionString>();

            services.AddSingleton<IContatoRepository, ContatoRepository>();
            services.AddSingleton<IContatoService, ContatoService>();

            //services.AddTransient<IRepository<object>, RepositoryBase<object>>();
            //services.AddTransient<IBookBankRepository, BookBankRepository>();
            //services.AddSingleton<IMenuRepository, MenuRepository>();

            //services.AddSingleton<IAccessProfileMenuRepository, AccessProfileMenuRepository>();
            //services.AddSingleton<IConfigReportServiceRepository, ConfigReportServiceRepository>();

            //services.AddSingleton<IBoleEmissoesService, BoleEmissoesService>();
            //services.AddSingleton<IForwardTicketService, ForwardTicketService>();
            //services.AddSingleton<IForeignExchangeTicketService, ForeignExchangeTicketService>();
            //services.AddSingleton<IOptionsTicketService, OptionsTicketService>();
            //services.AddSingleton<ICurrencyOptionsTicketService, CurrencyOptionsTicketService>();

            //services.AddScoped<InstallmentHelper, InstallmentHelper>();
            //services.AddScoped<IGenericsTicketService, GenericsTicketService>();
            //services.AddScoped<IMoneyTransferTicketService, MoneyTransferTicketService>();
            //services.AddScoped<ICdMaturityTicketService, CdMaturityTicketService>();
            //services.AddScoped<ITicketWorkflowService, TicketWorkflowService>();
            //services.AddScoped<IInstallmentService, InstallmentService>();

            //services.AddScoped<ISectionComissionService, SectionComissionService>();
            //services.AddScoped<ISection3737Service, Section3737Service>();
            //services.AddScoped<ISection4131Service, Section4131Service>();
            //services.AddScoped<ISectionForeignBranchService, SectionForeignBranchService>();
            //services.AddScoped<ISectionMarketService, SectionMarketService>();
            //services.AddScoped<ISectionTreasureService, SectionTreasureService>();
            //services.AddScoped<ISectionDiscountRateService, SectionDiscountRateService>();
            //services.AddScoped<ISectionEffectiveRateService, SectionEffectiveRateService>();

            //services.AddScoped<ISectionService<BorrowDetailsSection>, BorrowDetailsService>();
            //services.AddScoped<ISectionService<LenderBankSection>, LenderBankService>();
            //services.AddScoped<ISectionService<TransactionReferencedSection>, SectionTransactionReferencedService>();
            //services.AddScoped<ISectionService<CollateralSection>, SectionCollateralService>();

            //services.AddScoped<ITicketService<LoanTicket, LoanTicketGrid>, LoanTicketService>();
            //services.AddScoped<ITicketService<FinimpTicket, FinimpTicketGrid>, FinimpTicketService>();
            //services.AddScoped<ITicketService<PrepaymentTicket, PrepaymentTicketGrid>, PrepaymentTicketService>();
            //services.AddScoped<ITicketService<BorrowTicket, BorrowTicketGrid>, BorrowTicketService>();

            //services.AddScoped<ITicketService<DiscountNoteTicket, DiscountNoteTicketGrid>, DiscountNoteTicketService>();

            //services.AddScoped<IWalletApiAccess, WalletApiAccess>();
            //services.AddScoped<ITicketComissionService, TicketComissionService>();
            //services.AddScoped<IFeriadoFactory, FeriadoFactory>();
            //services.AddScoped<ICountryFactory, CountryFactory>();
            //services.AddScoped<IPaymentInstructionsService, PaymentInstructionsService>();
            //services.AddScoped<IInstallmentService, InstallmentService>();
            //services.AddScoped<IFixedIncomeTicketService, FixedIncomeTicketService>();

            //services.AddSingleton<IAccessProfileMenuService, AccessProfileMenuService>();
            //services.AddSingleton<IMenuService, MenuService>();
            //services.AddSingleton<IConfigReportServiceService, ConfigReportServiceService>();

            //services.AddSingleton<ISecurityFeeService, SecurityFeeService>();

            //services.AddSingleton<IPaymentInstructionsRepository, PaymentInstructionsRepository>();

            //services.AddScoped<IReportMoneyTransferService, ReportMoneyTransferService>();
            //services.AddScoped<IReportMoneyTransferRepository, ReportMoneyTransferRepository>();
            //services.AddScoped<IReportCdMaturityService, ReportCdMaturityService>();
            //services.AddScoped<IReportCdMaturityRepository, ReportCdMaturityRepository>();
        }
    }
}