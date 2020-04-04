// <auto-generated />
using System;
using MAVN.Service.CrossChainWalletLinker.MsSqlRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MAVN.Service.CrossChainWalletLinker.MsSqlRepositories.Migrations
{
    [DbContext(typeof(WalletLinkingContext))]
    [Migration("20191031150921_IndexConfigurationItems")]
    partial class IndexConfigurationItems
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("cross_chain_wallet_linker")
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MAVN.Service.CrossChainWalletLinker.MsSqlRepositories.Entities.ConfigurationItemEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnName("type");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("Type")
                        .IsUnique();

                    b.ToTable("configuration_items");
                });

            modelBuilder.Entity("MAVN.Service.CrossChainWalletLinker.MsSqlRepositories.Entities.WalletLinkingRequestEntity", b =>
                {
                    b.Property<string>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("customer_id");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("created_on");

                    b.Property<bool>("IsConfirmedInPrivate")
                        .HasColumnName("is_confirmed_in_private");

                    b.Property<bool>("IsConfirmedInPublic")
                        .HasColumnName("is_confirmed_in_public");

                    b.Property<string>("LinkCode")
                        .IsRequired()
                        .HasColumnName("link_code");

                    b.Property<string>("PrivateAddress")
                        .IsRequired()
                        .HasColumnName("private_address");

                    b.Property<string>("PublicAddress")
                        .HasColumnName("public_address");

                    b.Property<string>("Signature")
                        .HasColumnName("signature");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnName("timestamp");

                    b.HasKey("CustomerId");

                    b.HasIndex("PrivateAddress")
                        .IsUnique();

                    b.ToTable("wallet_linking_requests");
                });

            modelBuilder.Entity("MAVN.Service.CrossChainWalletLinker.MsSqlRepositories.Entities.WalletLinkingRequestsCounterEntity", b =>
                {
                    b.Property<string>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("customer_id");

                    b.Property<int>("ApprovalsCounter")
                        .HasColumnName("approvals_counter");

                    b.HasKey("CustomerId");

                    b.ToTable("wallet_linking_requests_counter");
                });
#pragma warning restore 612, 618
        }
    }
}
