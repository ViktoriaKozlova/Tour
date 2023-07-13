using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebTour.Models;

namespace WebTour.Data;

public partial class WebApiTourContext : DbContext
{
    public WebApiTourContext(DbContextOptions<WebApiTourContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<InformationTour> InformationTours { get; set; }

    public virtual DbSet<Insurance> Insurances { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<TourOperator> TourOperators { get; set; }

    public virtual DbSet<TourPackage> TourPackages { get; set; }

    public virtual DbSet<TypeFood> TypeFoods { get; set; }

    public virtual DbSet<TypeRoom> TypeRooms { get; set; }

    public virtual DbSet<TypeTour> TypeTours { get; set; }

    public virtual DbSet<TypeTransport> TypeTransports { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_unicode_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.IdContract).HasName("PRIMARY");

            entity.ToTable("contract");

            entity.HasIndex(e => e.NumberTour, "fk_Contract_Tour1_idx");

            entity.HasIndex(e => e.NumberStatus, "fk_Order_tour_Status1_idx");

            entity.HasIndex(e => e.NumberUser, "fk_Order_tour_User1_idx");

            entity.Property(e => e.IdContract).HasColumnName("id_contract");
            entity.Property(e => e.DateOfConlusion).HasColumnName("date_of_conlusion");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.NumberInvoice)
                .HasMaxLength(30)
                .HasColumnName("number_invoice");
            entity.Property(e => e.NumberStatus).HasColumnName("number_status");
            entity.Property(e => e.NumberTour).HasColumnName("number_tour");
            entity.Property(e => e.NumberUser).HasColumnName("number_user");
            entity.Property(e => e.QuantityTourists).HasColumnName("quantity_tourists");
            entity.Property(e => e.Sum).HasColumnName("SUM");

            entity.HasOne(d => d.NumberStatusNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.NumberStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Order_tour_Status1");

            entity.HasOne(d => d.NumberTourNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.NumberTour)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Contract_Tour1");

            entity.HasOne(d => d.NumberUserNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.NumberUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Order_tour_User1");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.IdCountry).HasName("PRIMARY");

            entity.ToTable("country");

            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.NameCountry)
                .HasMaxLength(45)
                .HasColumnName("name_country");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.IdHotel).HasName("PRIMARY");

            entity.ToTable("hotel");

            entity.Property(e => e.IdHotel)
                .ValueGeneratedNever()
                .HasColumnName("id_hotel");
            entity.Property(e => e.Address)
                .HasMaxLength(70)
                .HasColumnName("address");
            entity.Property(e => e.NameHotel)
                .HasMaxLength(70)
                .HasColumnName("name_hotel");
            entity.Property(e => e.PriceOfHotel).HasColumnName("price_of_hotel");
            entity.Property(e => e.Stars).HasColumnName("stars");
        });

        modelBuilder.Entity<InformationTour>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("information_tour");

            entity.Property(e => e.AmountSeats).HasColumnName("amount_seats");
            entity.Property(e => e.ArrivalDate).HasColumnName("arrival_date");
            entity.Property(e => e.DepartureDate).HasColumnName("departure_date");
            entity.Property(e => e.IdTour).HasColumnName("id_tour");
            entity.Property(e => e.NameCountry)
                .HasMaxLength(45)
                .HasColumnName("name_country");
            entity.Property(e => e.NameFood)
                .HasMaxLength(45)
                .HasColumnName("name_food");
            entity.Property(e => e.NameHotel)
                .HasMaxLength(70)
                .HasColumnName("name_hotel");
            entity.Property(e => e.NameRoom)
                .HasMaxLength(45)
                .HasColumnName("name_room");
            entity.Property(e => e.NameTourOperator)
                .HasColumnType("tinytext")
                .HasColumnName("name_tour_operator");
            entity.Property(e => e.NameTypeTour)
                .HasMaxLength(30)
                .HasColumnName("name_type_tour");
            entity.Property(e => e.Place)
                .HasMaxLength(70)
                .HasColumnName("place");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Stars).HasColumnName("stars");
        });

        modelBuilder.Entity<Insurance>(entity =>
        {
            entity.HasKey(e => e.ContractIdContract).HasName("PRIMARY");

            entity.ToTable("insurance");

            entity.HasIndex(e => e.ContractIdContract, "fk_Insurance_Contract1_idx");

            entity.Property(e => e.ContractIdContract)
                .ValueGeneratedNever()
                .HasColumnName("Contract_id_contract");
            entity.Property(e => e.DateLicense).HasColumnName("date_license");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.NameInsurance)
                .HasMaxLength(45)
                .HasColumnName("name_insurance");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.ContractIdContractNavigation).WithOne(p => p.Insurance)
                .HasForeignKey<Insurance>(d => d.ContractIdContract)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Insurance_Contract1");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.IdLocation).HasName("PRIMARY");

            entity.ToTable("location");

            entity.HasIndex(e => e.NumberCountry, "fk_Location_Country1_idx");

            entity.Property(e => e.IdLocation).HasColumnName("id_location");
            entity.Property(e => e.NumberCountry).HasColumnName("number_country");
            entity.Property(e => e.Place)
                .HasMaxLength(70)
                .HasColumnName("place");

            entity.HasOne(d => d.NumberCountryNavigation).WithMany(p => p.Locations)
                .HasForeignKey(d => d.NumberCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Location_Country1");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PRIMARY");

            entity.ToTable("role");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.NameRole)
                .HasMaxLength(30)
                .HasColumnName("name_role")
                .UseCollation("utf8_general_ci");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PRIMARY");

            entity.ToTable("status");

            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.NameStatus)
                .HasMaxLength(45)
                .HasColumnName("name_status");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.IdTicket).HasName("PRIMARY");

            entity.ToTable("ticket");

            entity.Property(e => e.IdTicket)
                .ValueGeneratedNever()
                .HasColumnName("id_ticket");
            entity.Property(e => e.Class)
                .HasMaxLength(50)
                .HasColumnName("class");
            entity.Property(e => e.DataOfDeparture).HasColumnName("data_of_departure");
            entity.Property(e => e.DateOfArrival).HasColumnName("date_of_arrival");
            entity.Property(e => e.PlaceOfArrival)
                .HasColumnType("text")
                .HasColumnName("place_of_arrival");
            entity.Property(e => e.PlaceOfDeparture)
                .HasColumnType("text")
                .HasColumnName("place_of_departure");
            entity.Property(e => e.PriceTicket).HasColumnName("price_ticket");
            entity.Property(e => e.TimeOfArrival)
                .HasColumnType("time")
                .HasColumnName("time_of_arrival");
            entity.Property(e => e.TimeOfDeparture)
                .HasColumnType("time")
                .HasColumnName("time_of_departure");

            entity.HasMany(d => d.TypeTransports).WithMany(p => p.Tickets)
                .UsingEntity<Dictionary<string, object>>(
                    "NumberRoute",
                    r => r.HasOne<TypeTransport>().WithMany()
                        .HasForeignKey("TypeTransportId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Number_route_Type_transport1"),
                    l => l.HasOne<Ticket>().WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Number__Ticket1"),
                    j =>
                    {
                        j.HasKey("TicketId", "TypeTransportId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("number_route");
                        j.HasIndex(new[] { "TicketId" }, "fk_Number__Ticket1_idx");
                        j.HasIndex(new[] { "TypeTransportId" }, "fk_Number_route_Type_transport1_idx");
                        j.IndexerProperty<int>("TicketId").HasColumnName("ticket_id");
                        j.IndexerProperty<int>("TypeTransportId").HasColumnName("type_transport_id");
                    });
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.IdTour).HasName("PRIMARY");

            entity.ToTable("tour");

            entity.HasIndex(e => e.NumberLocation, "fk_Tour_Location1_idx");

            entity.HasIndex(e => e.NumberTourOperator, "fk_Tour_Tour_operator1_idx");

            entity.HasIndex(e => e.NumberTypeTour, "fk_Tour_Type_tour_idx");

            entity.Property(e => e.IdTour).HasColumnName("id_tour");
            entity.Property(e => e.AmountSeats).HasColumnName("amount_seats");
            entity.Property(e => e.ArrivalDate).HasColumnName("arrival_date");
            entity.Property(e => e.DepartureDate).HasColumnName("departure_date");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.NumberLocation).HasColumnName("number_location");
            entity.Property(e => e.NumberTourOperator).HasColumnName("number_tour_operator");
            entity.Property(e => e.NumberTypeTour).HasColumnName("number_type_tour");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.NumberLocationNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.NumberLocation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Tour_Location1");

            entity.HasOne(d => d.NumberTourOperatorNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.NumberTourOperator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Tour_Tour_operator1");

            entity.HasOne(d => d.NumberTypeTourNavigation).WithMany(p => p.Tours)
                .HasForeignKey(d => d.NumberTypeTour)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Tour_Type_tour");

            entity.HasMany(d => d.TourPackages).WithMany(p => p.Tours)
                .UsingEntity<Dictionary<string, object>>(
                    "TypeTourPackage",
                    r => r.HasOne<TourPackage>().WithMany()
                        .HasForeignKey("TourPackageId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_table1_Tour_package1"),
                    l => l.HasOne<Tour>().WithMany()
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_table1_Tour1"),
                    j =>
                    {
                        j.HasKey("TourId", "TourPackageId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("type_tour_package");
                        j.HasIndex(new[] { "TourPackageId" }, "fk_table1_Tour_package1_idx");
                        j.IndexerProperty<int>("TourId").HasColumnName("tour_id");
                        j.IndexerProperty<int>("TourPackageId").HasColumnName("tour_package_id");
                    });
        });

        modelBuilder.Entity<TourOperator>(entity =>
        {
            entity.HasKey(e => e.IdTourOperator).HasName("PRIMARY");

            entity.ToTable("tour_operator");

            entity.Property(e => e.IdTourOperator)
                .ValueGeneratedNever()
                .HasColumnName("id_tour_operator");
            entity.Property(e => e.Address)
                .HasColumnType("text")
                .HasColumnName("address");
            entity.Property(e => e.DateOfContract).HasColumnName("date_of_contract");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.NameTourOperator)
                .HasColumnType("tinytext")
                .HasColumnName("name_tour_operator");
            entity.Property(e => e.NumberPhone)
                .HasMaxLength(45)
                .HasColumnName("number_phone");
            entity.Property(e => e.NumberRegistration).HasColumnName("number_registration");
        });

        modelBuilder.Entity<TourPackage>(entity =>
        {
            entity.HasKey(e => e.IdTourPackage).HasName("PRIMARY");

            entity.ToTable("tour_package");

            entity.HasIndex(e => e.NumberHotel, "fk_Tour_package_Hotel1_idx");

            entity.HasIndex(e => e.NumberTypeFood, "fk_Tour_package_Type_food1_idx");

            entity.HasIndex(e => e.NumberTypeRoom, "fk_Tour_package_Type_room1_idx");

            entity.Property(e => e.IdTourPackage).HasColumnName("id_tour_package");
            entity.Property(e => e.CostTourPackage).HasColumnName("cost_tour_package");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.NumberHotel).HasColumnName("number_hotel");
            entity.Property(e => e.NumberTypeFood).HasColumnName("number_type_food");
            entity.Property(e => e.NumberTypeRoom).HasColumnName("number_type_room");

            entity.HasOne(d => d.NumberHotelNavigation).WithMany(p => p.TourPackages)
                .HasForeignKey(d => d.NumberHotel)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Tour_package_Hotel1");

            entity.HasOne(d => d.NumberTypeFoodNavigation).WithMany(p => p.TourPackages)
                .HasForeignKey(d => d.NumberTypeFood)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Tour_package_Type_food1");

            entity.HasOne(d => d.NumberTypeRoomNavigation).WithMany(p => p.TourPackages)
                .HasForeignKey(d => d.NumberTypeRoom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Tour_package_Type_room1");

            entity.HasMany(d => d.Tickets).WithMany(p => p.TourPackages)
                .UsingEntity<Dictionary<string, object>>(
                    "TicketTourPackage",
                    r => r.HasOne<Ticket>().WithMany()
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Ticket_Tour_package_Ticket1"),
                    l => l.HasOne<TourPackage>().WithMany()
                        .HasForeignKey("TourPackageId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Ticket_Tour_package_Tour_package1"),
                    j =>
                    {
                        j.HasKey("TourPackageId", "TicketId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("ticket_tour_package");
                        j.HasIndex(new[] { "TicketId" }, "fk_Ticket_Tour_package_Ticket1_idx");
                        j.IndexerProperty<int>("TourPackageId").HasColumnName("tour_package_id");
                        j.IndexerProperty<int>("TicketId").HasColumnName("ticket_id");
                    });
        });

        modelBuilder.Entity<TypeFood>(entity =>
        {
            entity.HasKey(e => e.IdTypeFood).HasName("PRIMARY");

            entity.ToTable("type_food");

            entity.Property(e => e.IdTypeFood).HasColumnName("id_type_food");
            entity.Property(e => e.NameFood)
                .HasMaxLength(45)
                .HasColumnName("name_food");
            entity.Property(e => e.PriceOfFood).HasColumnName("price_of_food");
        });

        modelBuilder.Entity<TypeRoom>(entity =>
        {
            entity.HasKey(e => e.IdTypeRoom).HasName("PRIMARY");

            entity.ToTable("type_room");

            entity.Property(e => e.IdTypeRoom).HasColumnName("id_type_room");
            entity.Property(e => e.NameRoom)
                .HasMaxLength(45)
                .HasColumnName("name_room");
            entity.Property(e => e.PriceOfRoom).HasColumnName("price_of_room");
        });

        modelBuilder.Entity<TypeTour>(entity =>
        {
            entity.HasKey(e => e.IdTypeTour).HasName("PRIMARY");

            entity.ToTable("type_tour");

            entity.Property(e => e.IdTypeTour).HasColumnName("id_type_tour");
            entity.Property(e => e.NameTypeTour)
                .HasMaxLength(30)
                .HasColumnName("name_type_tour");
        });

        modelBuilder.Entity<TypeTransport>(entity =>
        {
            entity.HasKey(e => e.IdTypeTransport).HasName("PRIMARY");

            entity.ToTable("type_transport");

            entity.Property(e => e.IdTypeTransport).HasColumnName("id_type_transport");
            entity.Property(e => e.NameTypeTransport)
                .HasMaxLength(45)
                .HasColumnName("name_type_transport");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PRIMARY");

            entity.ToTable("user");

            entity.HasIndex(e => e.NumberRole, "fk_User_Role1_idx");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.CovidCertificate).HasColumnName("covid_certificate");
            entity.Property(e => e.DateOfBirhday).HasColumnName("date_of_birhday");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(70)
                .HasColumnName("name");
            entity.Property(e => e.NumberPassport)
                .HasMaxLength(10)
                .HasColumnName("number_passport");
            entity.Property(e => e.NumberPhone)
                .HasMaxLength(45)
                .HasColumnName("number_phone");
            entity.Property(e => e.NumberRole).HasColumnName("number_role");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.Surname)
                .HasMaxLength(70)
                .HasColumnName("surname")
                .UseCollation("utf8_general_ci");

            entity.HasOne(d => d.NumberRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.NumberRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_User_Role1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
