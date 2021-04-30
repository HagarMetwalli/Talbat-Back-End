using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Talbat.Models
{
    public partial class TalabatContext : DbContext
    {
        public TalabatContext()
        {
        }

        public TalabatContext(DbContextOptions<TalabatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientAddress> ClientAddresses { get; set; }
        public virtual DbSet<ClientDeliveryManOrder> ClientDeliveryManOrders { get; set; }
        public virtual DbSet<ClientOffer> ClientOffers { get; set; }
        public virtual DbSet<ClientSeekingJob> ClientSeekingJobs { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DeliveryMan> DeliveryMen { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemCategory> ItemCategories { get; set; }
        public virtual DbSet<ItemReview> ItemReviews { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobCategory> JobCategories { get; set; }
        public virtual DbSet<JobLocation> JobLocations { get; set; }
        public virtual DbSet<JobPeriod> JobPeriods { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }
        public virtual DbSet<Offer> Offers { get; set; }
        public virtual DbSet<OfferItem> OfferItems { get; set; }
        public virtual DbSet<OfferReview> OfferReviews { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<OrderReview> OrderReviews { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<ReviewCategory> ReviewCategories { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreWorkingHour> StoreWorkingHours { get; set; }
        public virtual DbSet<SubItem> SubItems { get; set; }
        public virtual DbSet<SubItemCategory> SubItemCategories { get; set; }
        public virtual DbSet<TempPartnerRegisterationDetail> TempPartnerRegisterationDetails { get; set; }
        public virtual DbSet<TempStoreRegisterationDetail> TempStoreRegisterationDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=Talabat;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.CityId).HasColumnName("City_Id");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("City_Name");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.ClientDateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("Client_DateOfBirth");

                entity.Property(e => e.ClientEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Client_Email");

                entity.Property(e => e.ClientFname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Client_Fname");

                entity.Property(e => e.ClientGender)
                    .IsRequired()
                    .HasMaxLength(6)
                    .HasColumnName("Client_Gender");

                entity.Property(e => e.ClientLname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Client_Lname");

                entity.Property(e => e.ClientNewsletterSubscribe).HasColumnName("Client_NewsletterSubscribe");

                entity.Property(e => e.ClientPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Client_Password");

                entity.Property(e => e.ClientSmsSubscribe).HasColumnName("Client_SmsSubscribe");
            });

            modelBuilder.Entity<ClientAddress>(entity =>
            {
                entity.ToTable("ClientAddress");

                entity.Property(e => e.ClientAddressId).HasColumnName("ClientAddress_Id");

                entity.Property(e => e.CityId).HasColumnName("City_Id");

                entity.Property(e => e.ClientAddressAddressTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ClientAddress_AddressTitle")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ClientAddressApartmentNumber).HasColumnName("ClientAddress_ApartmentNumber");

                entity.Property(e => e.ClientAddressBuilding)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ClientAddress_Building");

                entity.Property(e => e.ClientAddressFloor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ClientAddress_Floor");

                entity.Property(e => e.ClientAddressLandLine)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ClientAddress_LandLine")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ClientAddressMobileNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ClientAddress_MobileNumber");

                entity.Property(e => e.ClientAddressOptionalDirections)
                    .IsUnicode(false)
                    .HasColumnName("ClientAddress_OptionalDirections");

                entity.Property(e => e.ClientAddressStreet)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ClientAddress_Street");

                entity.Property(e => e.ClientAddressType)
                    .IsRequired()
                    .HasMaxLength(9)
                    .HasColumnName("ClientAddress_Type");

                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.RegionId).HasColumnName("Region_Id");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.ClientAddresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientAddress_City");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientAddresses)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientAddress_Client");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.ClientAddresses)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientAddress_Region");
            });

            modelBuilder.Entity<ClientDeliveryManOrder>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.DeliveryManId, e.InvoiceId });

                entity.ToTable("ClientDeliveryManOrder");

                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.DeliveryManId).HasColumnName("DeliveryMan_Id");

                entity.Property(e => e.InvoiceId).HasColumnName("Invoice_Id");

                entity.Property(e => e.ClientAddressId).HasColumnName("ClientAddress_Id");

                entity.Property(e => e.OrderShipingTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Order_Shiping_Time");

                entity.HasOne(d => d.ClientAddress)
                    .WithMany(p => p.ClientDeliveryManOrders)
                    .HasForeignKey(d => d.ClientAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientDeliveryManOrder_ClientAddress");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientDeliveryManOrders)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientDeliveryManOrder_Client");

                entity.HasOne(d => d.DeliveryMan)
                    .WithMany(p => p.ClientDeliveryManOrders)
                    .HasForeignKey(d => d.DeliveryManId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientDeliveryManOrder_DeliveryMan");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.ClientDeliveryManOrders)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientDeliveryManOrder_Order");
            });

            modelBuilder.Entity<ClientOffer>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.OfferId })
                    .HasName("PK_User_Offer");

                entity.ToTable("Client_Offer");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.OfferId).HasColumnName("Offer_Id");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.ClientOffers)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("FK_User_Offer_Offer");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ClientOffers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_Offer_User");
            });

            modelBuilder.Entity<ClientSeekingJob>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.JobId })
                    .HasName("PK_User_Seeking_Jobs");

                entity.ToTable("Client_Seeking_Jobs");

                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.JobId).HasColumnName("Job_Id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientSeekingJobs)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_User_Seeking_Jobs_User");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.ClientSeekingJobs)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Seeking_Jobs_Job");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.CountryId).HasColumnName("Country_Id");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Country_Name");

                entity.Property(e => e.CurrencyName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Currency_Name");
            });

            modelBuilder.Entity<DeliveryMan>(entity =>
            {
                entity.ToTable("DeliveryMan");

                entity.Property(e => e.DeliveryManId).HasColumnName("DeliveryMan_Id");

                entity.Property(e => e.DeliveryManCurrentLocation)
                    .IsUnicode(false)
                    .HasColumnName("DeliveryMan_CurrentLocation");

                entity.Property(e => e.DeliveryManHireDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DeliveryMan_HireDate");

                entity.Property(e => e.DeliveryManName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DeliveryMan_Name");

                entity.Property(e => e.DeliveryManSalary).HasColumnName("DeliveryMan_Salary");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.InvoiceId).HasColumnName("Invoice_Id");

                entity.Property(e => e.AddressDetails).IsUnicode(false);

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_Invoice_Order");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.Property(e => e.ItemId).HasColumnName("Item_Id");

                entity.Property(e => e.CountryId).HasColumnName("Country_Id");

                entity.Property(e => e.ItemCategoryId).HasColumnName("ItemCategory_Id");

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Item_Description")
                    .HasDefaultValueSql("('No Description')");

                entity.Property(e => e.ItemImage)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Item_Image")
                    .HasDefaultValueSql("('Default.png')");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Item_Name");

                entity.Property(e => e.ItemPrice)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Item_Price");

                entity.Property(e => e.StoreId).HasColumnName("Store_Id");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_Country");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Item_Store");
            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.ToTable("ItemCategory");

                entity.Property(e => e.ItemCategoryId).HasColumnName("ItemCategory_Id");

                entity.Property(e => e.ItemCategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ItemCategory_Name");
            });

            modelBuilder.Entity<ItemReview>(entity =>
            {
                entity.HasKey(e => e.ItemId);

                entity.ToTable("ItemReview");

                entity.Property(e => e.ItemId)
                    .ValueGeneratedNever()
                    .HasColumnName("Item_Id");

                entity.Property(e => e.ItemStatus).HasColumnName("Item_Status");

                entity.Property(e => e.OrderReviewId).HasColumnName("OrderReview_Id");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job");

                entity.Property(e => e.JobId).HasColumnName("Job_Id");

                entity.Property(e => e.JobCategoryId).HasColumnName("JobCategory_Id");

                entity.Property(e => e.JobDescription)
                    .IsUnicode(false)
                    .HasColumnName("Job_Description");

                entity.Property(e => e.JobLocationId).HasColumnName("JobLocation_Id");

                entity.Property(e => e.JobPeriodId).HasColumnName("JobPeriod_Id");

                entity.Property(e => e.JobPostedTime)
                    .HasColumnType("date")
                    .HasColumnName("Job_PostedTime");

                entity.Property(e => e.JobTitle)
                    .IsUnicode(false)
                    .HasColumnName("Job_Title");

                entity.Property(e => e.JobTypeId).HasColumnName("JobType_Id");

                entity.HasOne(d => d.JobCategory)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.JobCategoryId)
                    .HasConstraintName("FK_Job_JobCategory");

                entity.HasOne(d => d.JobLocation)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.JobLocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_JobLocation");

                entity.HasOne(d => d.JobPeriod)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.JobPeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_JobPeriod");

                entity.HasOne(d => d.JobType)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.JobTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_JobType");
            });

            modelBuilder.Entity<JobCategory>(entity =>
            {
                entity.ToTable("JobCategory");

                entity.Property(e => e.JobCategoryId).HasColumnName("JobCategory_Id");

                entity.Property(e => e.JobCategoryType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JobCategory_Type");
            });

            modelBuilder.Entity<JobLocation>(entity =>
            {
                entity.ToTable("JobLocation");

                entity.Property(e => e.JobLocationId).HasColumnName("JobLocation_Id");

                entity.Property(e => e.JobLocationName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JobLocation_Name");
            });

            modelBuilder.Entity<JobPeriod>(entity =>
            {
                entity.ToTable("JobPeriod");

                entity.Property(e => e.JobPeriodId).HasColumnName("JobPeriod_Id");

                entity.Property(e => e.JobPeriodName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JobPeriod_Name");
            });

            modelBuilder.Entity<JobType>(entity =>
            {
                entity.ToTable("JobType");

                entity.Property(e => e.JobTypeId).HasColumnName("JobType_Id");

                entity.Property(e => e.JobTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JobType_Name");
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.ToTable("Offer");

                entity.Property(e => e.OfferId).HasColumnName("Offer_Id");

                entity.Property(e => e.OfferDaysNumber).HasColumnName("Offer_DaysNumber");

                entity.Property(e => e.OfferDescription)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Offer_Description");

                entity.Property(e => e.OfferImage)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Offer_Image")
                    .HasDefaultValueSql("('Default.png')");

                entity.Property(e => e.OfferName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Offer_Name");

                entity.Property(e => e.OfferPrice)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Offer_Price");

                entity.Property(e => e.OfferQuantity).HasColumnName("Offer_Quantity");

                entity.Property(e => e.OfferStartDate)
                    .HasColumnType("date")
                    .HasColumnName("Offer_StartDate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OfferType)
                    .IsRequired()
                    .HasMaxLength(9);
            });

            modelBuilder.Entity<OfferItem>(entity =>
            {
                entity.HasKey(e => new { e.OfferId, e.ItemId });

                entity.ToTable("OfferItem");

                entity.Property(e => e.OfferId).HasColumnName("Offer_Id");

                entity.Property(e => e.ItemId).HasColumnName("Item_Id");

                entity.Property(e => e.OfferItemQuantity)
                    .HasColumnName("OfferItem_Quantity")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OfferItemSaleValue).HasColumnName("OfferItem_SaleValue");

                entity.Property(e => e.OfferItemTypePercentage)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("OfferItem_TypePercentage")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OfferItems)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_OfferItem_Item");

                entity.HasOne(d => d.Offer)
                    .WithMany(p => p.OfferItems)
                    .HasForeignKey(d => d.OfferId)
                    .HasConstraintName("FK_OfferItem_Offer");
            });

            modelBuilder.Entity<OfferReview>(entity =>
            {
                entity.HasKey(e => e.OfferId);

                entity.ToTable("OfferReview");

                entity.Property(e => e.OfferId)
                    .ValueGeneratedNever()
                    .HasColumnName("Offer_Id");

                entity.Property(e => e.OfferStatus).HasColumnName("Offer_Status");

                entity.Property(e => e.OrderReviewId).HasColumnName("OrderReview_Id");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.ClientId).HasColumnName("Client_Id");

                entity.Property(e => e.OrderCost).HasColumnName("Order_Cost");

                entity.Property(e => e.OrderSpecialRequest)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Order_SpecialRequest")
                    .HasDefaultValueSql("('none')");

                entity.Property(e => e.OrderTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Order_Time")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StoreId).HasColumnName("Store_Id");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Order_Store");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ItemId });

                entity.ToTable("OrderItem");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.ItemId).HasColumnName("Item_Id");

                entity.Property(e => e.OrderItemQty)
                    .HasColumnName("OrderItem_Qty")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OrderItemSpecialRequest)
                    .IsUnicode(false)
                    .HasColumnName("OrderItem_SpecialRequest")
                    .HasDefaultValueSql("('none')");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItem_Item");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_OrderItem_Order");
            });

            modelBuilder.Entity<OrderReview>(entity =>
            {
                entity.ToTable("OrderReview");

                entity.Property(e => e.OrderReviewId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderReview_Id");

                entity.Property(e => e.OfferReviewBody)
                    .IsUnicode(false)
                    .HasColumnName("OfferReview_body");

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.QualityOffood).HasColumnName("QualityOFFood");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderReviews)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderReview_Order");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.ToTable("Partner");

                entity.Property(e => e.PartnerId)
                    .ValueGeneratedNever()
                    .HasColumnName("Partner_Id");

                entity.Property(e => e.PartnerEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Partner_Email");

                entity.Property(e => e.PartnerFname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Partner_FName");

                entity.Property(e => e.PartnerLname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Partner_LName");

                entity.Property(e => e.PartnerPhoneNo).HasColumnName("Partner_PhoneNo");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Region");

                entity.Property(e => e.RegionId).HasColumnName("Region_Id");

                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Region_Name");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.ReviewId).HasColumnName("Review_Id");

                entity.Property(e => e.ReviewCategoryId).HasColumnName("ReviewCategory_Id");

                entity.Property(e => e.ReviewContent)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Review_Content");

                entity.Property(e => e.ReviewDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Review_Date");

                entity.Property(e => e.ReviewRates).HasColumnName("Review_Rates");

                entity.Property(e => e.StoreId).HasColumnName("Store_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.ReviewCategory)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ReviewCategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Review_ReviewCategory");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Review_Store");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Review_User");
            });

            modelBuilder.Entity<ReviewCategory>(entity =>
            {
                entity.ToTable("ReviewCategory");

                entity.Property(e => e.ReviewCategoryId).HasColumnName("ReviewCategory_Id");

                entity.Property(e => e.ReviewCategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ReviewCategory_Name");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.StoreId).HasColumnName("Store_Id");

                entity.Property(e => e.CountryId).HasColumnName("Country_Id");

                entity.Property(e => e.StoreAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Store_Address");

                entity.Property(e => e.StoreCuisine)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Store_Cuisine");

                entity.Property(e => e.StoreDeliveryFee).HasColumnName("Store_DeliveryFee");

                entity.Property(e => e.StoreDeliveryTime).HasColumnName("Store_DeliveryTime");

                entity.Property(e => e.StoreDescription)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("Store_Description");

                entity.Property(e => e.StoreMinOrder).HasColumnName("Store_MinOrder");

                entity.Property(e => e.StoreName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Store_Name");

                entity.Property(e => e.StorePaymentOnDeliverCash).HasColumnName("Store_PaymentOnDeliverCash");

                entity.Property(e => e.StorePaymentVisa).HasColumnName("Store_PaymentVisa");

                entity.Property(e => e.StorePreOrder)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Store_PreOrder");

                entity.Property(e => e.StoreRate).HasColumnName("Store_Rate");
            });

            modelBuilder.Entity<StoreWorkingHour>(entity =>
            {
                entity.ToTable("StoreWorkingHour");

                entity.Property(e => e.StoreWorkingHourId)
                    .ValueGeneratedNever()
                    .HasColumnName("StoreWorkingHour_Id");

                entity.Property(e => e.StoreId).HasColumnName("Store_Id");

                entity.Property(e => e.StoreWorkingHourDay)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("StoreWorkingHour_Day");

                entity.Property(e => e.StoreWorkingHourEnd)
                    .HasColumnName("StoreWorkingHour_End")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.StoreWorkingHourStart)
                    .HasColumnName("StoreWorkingHour_Start")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreWorkingHours)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StoreWorkingHour_Store");
            });

            modelBuilder.Entity<SubItem>(entity =>
            {
                entity.ToTable("SubItem");

                entity.Property(e => e.SubItemId)
                    .ValueGeneratedNever()
                    .HasColumnName("SubItem_Id");

                entity.Property(e => e.ItemId).HasColumnName("Item_Id");

                entity.Property(e => e.SubItemCategoryId).HasColumnName("SubItemCategory_Id");

                entity.Property(e => e.SubItemName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SubItem_Name");

                entity.Property(e => e.SubItemPrice).HasColumnName("SubItem_Price");

                entity.Property(e => e.SubItemSelectionType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("SubItem_SelectionType")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.SubItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubItem_Item1");

                entity.HasOne(d => d.SubItemCategory)
                    .WithMany(p => p.SubItems)
                    .HasForeignKey(d => d.SubItemCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubItem_SubItemCategory");
            });

            modelBuilder.Entity<SubItemCategory>(entity =>
            {
                entity.ToTable("SubItemCategory");

                entity.Property(e => e.SubItemCategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("SubItemCategory_Id");

                entity.Property(e => e.SubItemCategoryDescription)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("SubItemCategory_Description");

                entity.Property(e => e.SubItemCategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SubItemCategory_Name");
            });

            modelBuilder.Entity<TempPartnerRegisterationDetail>(entity =>
            {
                entity.HasKey(e => e.PartnerId);

                entity.Property(e => e.PartnerId)
                    .ValueGeneratedNever()
                    .HasColumnName("Partner_Id");

                entity.Property(e => e.PartnerContactRole)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Partner_ContactRole");

                entity.Property(e => e.PartnerEmail)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Partner_Email");

                entity.Property(e => e.PartnerFname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Partner_FName");

                entity.Property(e => e.PartnerLname)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Partner_LName");

                entity.Property(e => e.PartnerPhoneNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Partner_PhoneNumber");

                entity.Property(e => e.StoreCountry)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Store_Country");
            });

            modelBuilder.Entity<TempStoreRegisterationDetail>(entity =>
            {
                entity.HasKey(e => e.StoreId);

                entity.Property(e => e.StoreId)
                    .ValueGeneratedNever()
                    .HasColumnName("Store_Id");

                entity.Property(e => e.StoreAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Store_Address");

                entity.Property(e => e.StoreBranchesNo).HasColumnName("Store_BranchesNo");

                entity.Property(e => e.StoreContact)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Store_Contact");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Store_Name");

                entity.Property(e => e.StoreStatus)
                    .HasMaxLength(10)
                    .HasColumnName("Store_Status")
                    .IsFixedLength(true);

                entity.Property(e => e.StoreType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Store_Type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
