using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace MM.ClientModels
{
    public partial class ClientTimeZone
    {
        public ClientTimeZone()
        {
            Client = new HashSet<ClientOrganization>();
            Event = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }

        public virtual ICollection<ClientOrganization> Client { get; set; }
        public virtual ICollection<Event> Event { get; set; }
    }

    public partial class TimeZoneConfiguration : IEntityTypeConfiguration<ClientTimeZone>
    {
        public void Configure(EntityTypeBuilder<ClientTimeZone> builder)
        {

            builder.Property(e => e.CreatedOn).HasColumnType("datetime");
            builder.Property(e => e.Description).HasMaxLength(200);
            builder.Property(e => e.ModifiedOn).HasColumnType("datetime");
            builder.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

        }


    }

    public static partial class Seeder
    {
        public static void SeedTimeZone(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientTimeZone>().HasData(
                        new ClientTimeZone { Id = 1, Name = "Dateline Standard Time", Description = "(GMT-12:00) International Date Line West", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 2, Name = "Samoa Standard Time", Description = "(GMT-11:00) MIdway Island, Samoa", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 3, Name = "Hawaiian Standard Time", Description = "(GMT-10:00) Hawaii", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 4, Name = "Alaskan Standard Time", Description = "(GMT-09:00) Alaska", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 5, Name = "Pacific Standard Time", Description = "(GMT-08:00) Pacific Time (US and Canada); Tijuana", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 6, Name = "Mountain Standard Time", Description = "(GMT-07:00) Mountain Time (US and Canada)", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 7, Name = "Mexico Standard Time 2", Description = "(GMT-07:00) Chihuahua, La Paz, Mazatlan", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 8, Name = "U.S. Mountain Standard Time", Description = "(GMT-07:00) Arizona", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 9, Name = "Central Standard Time", Description = "(GMT-06:00) Central Time (US and Canada)", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 10, Name = "Canada Central Standard Time", Description = "(GMT-06:00) Saskatchewan", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 11, Name = "Mexico Standard Time", Description = "(GMT-06:00) Guadalajara, Mexico City, Monterrey", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 12, Name = "Central America Standard Time", Description = "(GMT-06:00) Central America", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 13, Name = "Eastern Standard Time", Description = "(GMT-05:00) Eastern Time (US and Canada)", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 14, Name = "U.S. Eastern Standard Time", Description = "(GMT-05:00) Indiana (East)", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 15, Name = "S.A. Pacific Standard Time", Description = "(GMT-05:00) Bogota, Lima, Quito", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 16, Name = "Atlantic Standard Time", Description = "(GMT-04:00) Atlantic Time (Canada)", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 17, Name = "S.A. Western Standard Time", Description = "(GMT-04:00) Georgetown, La Paz, San Juan", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 18, Name = "Pacific S.A. Standard Time", Description = "(GMT-04:00) Santiago", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 19, Name = "Newfoundland and Labrador Standard Time", Description = "(GMT-03:30) Newfoundland", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 20, Name = "E. South America Standard Time", Description = "(GMT-03:00) Brasilia", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 21, Name = "S.A. Eastern Standard Time", Description = "(GMT-03:00) Georgetown", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 22, Name = "Greenland Standard Time", Description = "(GMT-03:00) Greenland", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 23, Name = "MId-Atlantic Standard Time", Description = "(GMT-02:00) MId-Atlantic", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 24, Name = "Azores Standard Time", Description = "(GMT-01:00) Azores", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 25, Name = "Cape Verde Standard Time", Description = "(GMT-01:00) Cape Verde Islands", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 26, Name = "GMT Standard Time", Description = "(GMT) Greenwich Mean Time: Dublin, Edinburgh, Lisbon, London", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 27, Name = "Greenwich Standard Time", Description = "(GMT) Monrovia, Reykjavik", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 28, Name = "Central Europe Standard Time", Description = "(GMT+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 29, Name = "Central European Standard Time", Description = "(GMT+01:00) Sarajevo, Skopje, Warsaw, Zagreb", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 30, Name = "Romance Standard Time", Description = "(GMT+01:00) Brussels, Copenhagen, MadrId, Paris", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 31, Name = "W. Europe Standard Time", Description = "(GMT+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 32, Name = "W. Central Africa Standard Time", Description = "(GMT+01:00) West Central Africa", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 33, Name = "E. Europe Standard Time", Description = "(GMT+02:00) Minsk", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 34, Name = "Egypt Standard Time", Description = "(GMT+02:00) Cairo", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 35, Name = "FLE Standard Time", Description = "(GMT+02:00) Helsinki, Kiev, Riga, Sofia, Tallinn, Vilnius", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 36, Name = "GTB Standard Time", Description = "(GMT+02:00) Athens, Bucharest, Istanbul", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 37, Name = "Israel Standard Time", Description = "(GMT+02:00) Jerusalem", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 38, Name = "South Africa Standard Time", Description = "(GMT+02:00) Harare, Pretoria", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 39, Name = "Russian Standard Time", Description = "(GMT+03:00) Moscow, St. Petersburg, Volgograd", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 40, Name = "Arab Standard Time", Description = "(GMT+03:00) Kuwait, Riyadh", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 41, Name = "E. Africa Standard Time", Description = "(GMT+03:00) Nairobi", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 42, Name = "Arabic Standard Time", Description = "(GMT+03:00) Baghdad", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 43, Name = "Iran Standard Time", Description = "(GMT+03:30) Tehran", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 44, Name = "Arabian Standard Time", Description = "(GMT+04:00) Abu Dhabi, Muscat", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 45, Name = "Caucasus Standard Time", Description = "(GMT+04:00) Baku, Tbilisi, Yerevan", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 46, Name = "Transitional Islamic State of Afghanistan Standard Time", Description = "(GMT+04:30) Kabul", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 47, Name = "Ekaterinburg Standard Time", Description = "(GMT+05:00) Ekaterinburg", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 48, Name = "West Asia Standard Time", Description = "(GMT+05:00) Tashkent", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 49, Name = "India Standard Time", Description = "(GMT+05:30) Chennai, Kolkata, Mumbai, New Delhi", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 50, Name = "Nepal Standard Time", Description = "(GMT+05:45) Kathmandu", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 51, Name = "Central Asia Standard Time", Description = "(GMT+06:00) Astana, Dhaka", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 52, Name = "Sri Lanka Standard Time", Description = "(GMT+06:00) Sri Jayawardenepura", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 53, Name = "N. Central Asia Standard Time", Description = "(GMT+06:00) Almaty, Novosibirsk", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 54, Name = "Myanmar Standard Time", Description = "(GMT+06:30) Yangon (Rangoon)", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 55, Name = "S.E. Asia Standard Time", Description = "(GMT+07:00) Bangkok, Hanoi, Jakarta", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 56, Name = "North Asia Standard Time", Description = "(GMT+07:00) Krasnoyarsk", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 57, Name = "China Standard Time", Description = "(GMT+08:00) Beijing, Chongqing, Hong Kong, Urumqi", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 58, Name = "Singapore Standard Time", Description = "(GMT+08:00) Kuala Lumpur, Singapore", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 59, Name = "Taipei Standard Time", Description = "(GMT+08:00) Taipei", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 60, Name = "W. Australia Standard Time", Description = "(GMT+08:00) Perth", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 61, Name = "North Asia East Standard Time", Description = "(GMT+08:00) Irkutsk, Ulaanbaatar", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 62, Name = "Korea Standard Time", Description = "(GMT+09:00) Seoul", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 63, Name = "Tokyo Standard Time", Description = "(GMT+09:00) Osaka, Sapporo, Tokyo", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 64, Name = "Yakutsk Standard Time", Description = "(GMT+09:00) Yakutsk", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 65, Name = "A.U.S. Central Standard Time", Description = "(GMT+09:30) Darwin", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 66, Name = "Cen. Australia Standard Time", Description = "(GMT+09:30) AdelaIde", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 67, Name = "A.U.S. Eastern Standard Time", Description = "(GMT+10:00) Canberra, Melbourne, Sydney", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 68, Name = "E. Australia Standard Time", Description = "(GMT+10:00) Brisbane", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 69, Name = "Tasmania Standard Time", Description = "(GMT+10:00) Hobart", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 70, Name = "Vladivostok Standard Time", Description = "(GMT+10:00) Vladivostok", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 71, Name = "West Pacific Standard Time", Description = "(GMT+10:00) Guam, Port Moresby", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 72, Name = "Central Pacific Standard Time", Description = "(GMT+11:00) Magadan, Solomon Islands, New Caledonia", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 73, Name = "Fiji Islands Standard Time", Description = "(GMT+12:00) Fiji, Kamchatka, Marshall Is.", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 74, Name = "New Zealand Standard Time", Description = "(GMT+12:00) Auckland, Wellington", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 75, Name = "Tonga Standard Time", Description = "(GMT+13:00) Nuku'alofa", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 76, Name = "Azerbaijan Standard Time ", Description = "(GMT-03:00) Buenos Aires", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 77, Name = "MIddle East Standard Time", Description = "(GMT+02:00) Beirut", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 78, Name = "Jordan Standard Time", Description = "(GMT+02:00) Amman", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 79, Name = "Central Standard Time (Mexico)", Description = "(GMT-06:00) Guadalajara, Mexico City, Monterrey - New", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 80, Name = "Mountain Standard Time (Mexico)", Description = "(GMT-07:00) Chihuahua, La Paz, Mazatlan - New", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 81, Name = "Pacific Standard Time (Mexico)", Description = "(GMT-08:00) Tijuana, Baja California", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 82, Name = "Namibia Standard Time", Description = "(GMT+02:00) Windhoek", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 83, Name = "Georgian Standard Time", Description = "(GMT+03:00) Tbilisi", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 84, Name = "Central Brazilian Standard Time", Description = "(GMT-04:00) Manaus", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 85, Name = "MontevIdeo Standard Time", Description = "(GMT-03:00) MontevIdeo", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 86, Name = "Armenian Standard Time", Description = "(GMT+04:00) Yerevan", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 87, Name = "Venezuela Standard Time", Description = "(GMT-04:30) Caracas", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 88, Name = "Argentina Standard Time", Description = "(GMT-03:00) Buenos Aires", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 89, Name = "Morocco Standard Time", Description = "(GMT) Casablanca", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 90, Name = "Pakistan Standard Time", Description = "(GMT+05:00) Islamabad, Karachi", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 91, Name = "Mauritius Standard Time", Description = "(GMT+04:00) Port Louis", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 92, Name = "UTC", Description = "(GMT) Coordinated Universal Time", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 93, Name = "Paraguay Standard Time", Description = "(GMT-04:00) Asuncion", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) },
                        new ClientTimeZone { Id = 94, Name = "Kamchatka Standard Time", Description = "(GMT+12:00) Petropavlovsk-Kamchatsky", CreatedOn = new DateTime(2020, 8, 12), ModifiedOn = new DateTime(2020, 8, 12) }

                 );

        }
    }

}
