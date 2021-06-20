using Microsoft.EntityFrameworkCore;

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

        public virtual DbSet<AddressType> AddressTypes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientAddress> ClientAddresses { get; set; }
        public virtual DbSet<ClientCoupon> ClientCoupons { get; set; }
        public virtual DbSet<ClientDeliveryManOrder> ClientDeliveryManOrders { get; set; }
        public virtual DbSet<ClientPromotion> ClientPromotions { get; set; }
        public virtual DbSet<ClientSeekingJob> ClientSeekingJobs { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<CouponItem> CouponItems { get; set; }
        public virtual DbSet<Cuisine> Cuisines { get; set; }
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
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<OrderReview> OrderReviews { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<PromotionItem> PromotionItems { get; set; }
        public virtual DbSet<PromotionReview> PromotionReviews { get; set; }
        public virtual DbSet<RateStatus> RateStatuses { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreType> StoreTypes { get; set; }
        public virtual DbSet<StoreWorkingHour> StoreWorkingHours { get; set; }
        public virtual DbSet<SubItem> SubItems { get; set; }
        public virtual DbSet<SubItemCategory> SubItemCategories { get; set; }
        public virtual DbSet<TempPartnerRegisterationDetail> TempPartnerRegisterationDetails { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        

        public virtual DbSet<SystemReview> SystemReview { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.; Database=Talabat; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityName).IsUnicode(false);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.ClientEmail).IsUnicode(false);

                entity.Property(e => e.ClientFname).IsUnicode(false);

                entity.Property(e => e.ClientLname).IsUnicode(false);
            });

            modelBuilder.Entity<SystemReview>(entity =>
            {
                entity.Property(e => e.SystemReviewId).ValueGeneratedNever();

            });

            modelBuilder.Entity<ClientAddress>(entity =>
            {
                entity.Property(e => e.ClientAddressAddressTitle)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ClientAddressBuilding).IsUnicode(false);

                entity.Property(e => e.ClientAddressFloor).IsUnicode(false);

                entity.Property(e => e.ClientAddressLandLine)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ClientAddressMobileNumber).IsUnicode(false);

                entity.Property(e => e.ClientAddressOptionalDirections).IsUnicode(false);

                entity.Property(e => e.ClientAddressStreet).IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.ClientAddresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientAddress_City");

                entity.HasOne(d => d.ClientAddressType)
                    .WithMany(p => p.ClientAddresses)
                    .HasForeignKey(d => d.ClientAddressTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientAddress_AddressType");

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

            modelBuilder.Entity<ClientCoupon>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.CouponId, e.OrderId });

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientCoupons)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientCoupon_Client");

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.ClientCoupons)
                    .HasForeignKey(d => d.CouponId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientCoupon_Coupon");

                entity.HasOne(d => d.Order)
                   .WithMany(p => p.ClientCoupons)
                   .HasForeignKey(d => d.OrderId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_ClientCoupon_Order");
            });

            modelBuilder.Entity<ClientDeliveryManOrder>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.DeliveryManId}); //, e.InvoiceId 

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

                //entity.HasOne(d => d.Invoice)
                //    .WithMany(p => p.ClientDeliveryManOrders)
                //    .HasForeignKey(d => d.Invoice)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_ClientDeliveryManOrder_Order");
            });

            //modelBuilder.Entity<ClientOffer>(entity =>
            //{
            //    entity.HasKey(e => new { e.UserId, e.OfferId })
            //        .HasName("PK_User_Offer");

            //    entity.HasOne(d => d.Offer)
            //        .WithMany(p => p.ClientOffers)
            //        .HasForeignKey(d => d.OfferId)
            //        .HasConstraintName("FK_User_Offer_Offer");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.ClientOffers)
            //        .HasForeignKey(d => d.UserId)
            //        .HasConstraintName("FK_User_Offer_User");
            //});

            modelBuilder.Entity<ClientPromotion>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.PromotionId });

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientPromotions)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientPromotion_Client");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.ClientPromotions)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClientPromotion_Promotion");
            });

            modelBuilder.Entity<ClientSeekingJob>(entity =>
            {
                entity.HasKey(e => new { e.ClientId, e.JobId })
                    .HasName("PK_User_Seeking_Jobs");

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
                entity.Property(e => e.CountryName).IsUnicode(false);

                entity.Property(e => e.CurrencyName).IsUnicode(false);
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.Property(e => e.CouponId).ValueGeneratedNever();

                entity.Property(e => e.CouponKey).IsUnicode(false);

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Coupons)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Coupon_Store");
            });

            modelBuilder.Entity<CouponItem>(entity =>
            {
                entity.HasKey(e => new { e.CouponId, e.ItemId });

                entity.HasOne(d => d.Coupon)
                    .WithMany(p => p.CouponItems)
                    .HasForeignKey(d => d.CouponId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CouponItem_Coupon");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.CouponItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CouponItem_Item");
            });

            modelBuilder.Entity<DeliveryMan>(entity =>
            {
                entity.Property(e => e.DeliveryManCurrentLocation).IsUnicode(false);

                entity.Property(e => e.DeliveryManName).IsUnicode(false);
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.AddressDetails).IsUnicode(false);

                //entity.HasOne(d => d.Order)
                //    .WithMany(p => p.Invoices)
                //    .HasForeignKey(d => d.OrderId)
                //    .HasConstraintName("FK_Invoice_Order");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemDescription)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('No Description')");

                entity.Property(e => e.ItemImage)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Default.png')");

                entity.Property(e => e.ItemName).IsUnicode(false);

                entity.Property(e => e.ItemPrice).IsUnicode(false);

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
                entity.Property(e => e.ItemCategoryName).IsUnicode(false);
            });

            modelBuilder.Entity<ItemReview>(entity =>
            {
                entity.HasKey(e => new { e.ItemId, e.OrderReviewId });

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemReviews)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemReview_Item");

                entity.HasOne(d => d.OrderReview)
                    .WithMany(p => p.ItemReviews)
                    .HasForeignKey(d => d.OrderReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ItemReview_OrderReview");

                //entity.HasOne(d => d.RateStatus)
                //    .WithMany(p => p.ItemReviews)
                    //.HasForeignKey(d => d.RateStatusId)
                    //.OnDelete(DeleteBehavior.ClientSetNull)
                    //.HasConstraintName("FK_ItemReview_RateStatus");

            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.JobDescription)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.JobTitle)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

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
                entity.Property(e => e.JobCategoryType).IsUnicode(false);
            });

            modelBuilder.Entity<JobLocation>(entity =>
            {
                entity.Property(e => e.JobLocationName).IsUnicode(false);
            });

            modelBuilder.Entity<JobPeriod>(entity =>
            {
                entity.Property(e => e.JobPeriodName).IsUnicode(false);
            });

            modelBuilder.Entity<JobType>(entity =>
            {
                entity.Property(e => e.JobTypeName).IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderSpecialRequest)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('none')");

                entity.Property(e => e.OrderTime).HasDefaultValueSql("(getdate())");

                //entity.Property(e => e.IsDelivered)
                //    .HasConversion(x => (int)x, x => (DeliveryStatus)x);

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

                entity.Property(e => e.OrderItemQty).HasDefaultValueSql("((1))");

                entity.Property(e => e.OrderItemSpecialRequest)
                    .IsUnicode(false)
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
                entity.Property(e => e.OrderReviewComment)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.OrderReviews)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderReview_Client");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderReviews)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderReview_Order");
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.Property(e => e.PartnerId).ValueGeneratedNever();

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Partners)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Partner_Store");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.Property(e => e.PromotionDescription).IsUnicode(false);

                entity.Property(e => e.PromotionImage)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Default.png')");

                entity.Property(e => e.PromotionName).IsUnicode(false);

                entity.Property(e => e.PromotionStartDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PromotionItem>(entity =>
            {
                entity.HasKey(e => new { e.PromotionId, e.ItemId })
                    .HasName("PK_OfferItem");

                entity.Property(e => e.PromotionItemQuantity).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.PromotionItems)
                    .HasForeignKey(d => d.ItemId)
                    .HasConstraintName("FK_OfferItem_Item");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.PromotionItems)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK_OfferItem_Offer");
            });

            modelBuilder.Entity<PromotionReview>(entity =>
            {
                entity.HasKey(e => new { e.PromotionId, e.OrderReviewId, e.RateStatusId })
                    .HasName("PK_OfferReview_1");

                entity.HasOne(d => d.OrderReview)
                    .WithMany(p => p.PromotionReviews)
                    .HasForeignKey(d => d.OrderReviewId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfferReview_OrderReview");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.PromotionReviews)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfferReview_Promotion");

                entity.HasOne(d => d.RateStatus)
                    .WithMany(p => p.PromotionReviews)
                    .HasForeignKey(d => d.RateStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OfferReview_RateStatus");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.RegionName).IsUnicode(false);
            });

            //modelBuilder.Entity<Review>(entity =>
            //{
            //    entity.Property(e => e.ReviewContent).IsUnicode(false);

            //    entity.HasOne(d => d.ReviewCategory)
            //        .WithMany(p => p.Reviews)
            //        .HasForeignKey(d => d.ReviewCategoryId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_Review_ReviewCategory");

            //    entity.HasOne(d => d.Store)
            //        .WithMany(p => p.Reviews)
            //        .HasForeignKey(d => d.StoreId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_Review_Store");

            //    entity.HasOne(d => d.User)
            //        .WithMany(p => p.Reviews)
            //        .HasForeignKey(d => d.UserId)
            //        .OnDelete(DeleteBehavior.Cascade)
            //        .HasConstraintName("FK_Review_User");
            //});


            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StoreAddress).IsUnicode(false);

                entity.Property(e => e.StoreDescription).IsUnicode(false);

                entity.Property(e => e.StoreName).IsUnicode(false);

                entity.Property(e => e.StorePreOrder).IsUnicode(false);

                entity.HasOne(d => d.StoreType)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.StoreTypeId)
                    .HasConstraintName("FK_Store_StoreType");
            });

            modelBuilder.Entity<StoreType>(entity =>
            {
                entity.Property(e => e.StoreTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<StoreWorkingHour>(entity =>
            {
                entity.Property(e => e.StoreWorkingHourId).ValueGeneratedNever();

                entity.Property(e => e.StoreWorkingHourDay).IsUnicode(false);

                entity.Property(e => e.StoreWorkingHourEnd).HasDefaultValueSql("((0))");

                entity.Property(e => e.StoreWorkingHourStart).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreWorkingHours)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StoreWorkingHour_Store");
            });

            modelBuilder.Entity<SubItem>(entity =>
            {
                entity.Property(e => e.SubItemId).ValueGeneratedNever();

                entity.Property(e => e.SubItemName).IsUnicode(false);

                entity.Property(e => e.SubItemIsRadioButton).IsFixedLength(true);

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
                entity.Property(e => e.SubItemCategoryId).ValueGeneratedNever();

                //entity.Property(e => e.SubItemCategoryDescription).IsUnicode(false);

                entity.Property(e => e.SubItemCategoryName).IsUnicode(false);
            });

            // TODO: FIX this SystemReview entity builder
            //modelBuilder.Entity<SystemReview>(entity =>
            //{
            //    entity.Property(e => e.SystemReviewComment)
            //        .IsUnicode(false)
            //        .HasDefaultValueSql("('')");

                //entity.HasOne(d => d.Client)
                //    .WithMany(p => p.SystemReviews)
                //    .HasForeignKey(d => d.ClientId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_SystemReviews_Client");

            //});

            modelBuilder.Entity<TempPartnerRegisterationDetail>(entity =>
            {
                entity.Property(e => e.TempPartnerStoreId).ValueGeneratedNever();

                //entity.Property(e => e.StoreStatus).IsFixedLength(true);

                entity.HasOne(d => d.StoreType)
                    .WithMany(p => p.TempPartnerRegisterationDetails)
                    .HasForeignKey(d => d.StoreTypeId)
                    .HasConstraintName("FK_TempPartnerRegisterationDetails_StoreType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
