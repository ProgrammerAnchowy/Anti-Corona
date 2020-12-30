﻿// <auto-generated />
using System;
using Anti_Corona.Data.Concrete.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Anti_Corona.Data.Migrations
{
    [DbContext(typeof(AntiCoronaContext))]
    [Migration("20201230122358_deneme")]
    partial class deneme
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Anti_Corona.Entity.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Anti_Corona.Entity.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            ImageUrl = "maske.jpg",
                            Name = "Maskeler"
                        },
                        new
                        {
                            CategoryId = 2,
                            ImageUrl = "eldiven.jpg",
                            Name = "Eldivenler"
                        },
                        new
                        {
                            CategoryId = 3,
                            ImageUrl = "dezenfektan.jpg",
                            Name = "Dezenfektanlar"
                        },
                        new
                        {
                            CategoryId = 4,
                            ImageUrl = "siperlik.jpg",
                            Name = "Siperlikler"
                        });
                });

            modelBuilder.Entity("Anti_Corona.Entity.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("ProductId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentId = 1,
                            Description = "Güzel maske",
                            ProductId = 1
                        },
                        new
                        {
                            CommentId = 2,
                            Description = "Güzel maske1",
                            ProductId = 2
                        });
                });

            modelBuilder.Entity("Anti_Corona.Entity.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            ImageId = 1,
                            ImageUrl = "maske1.1.jpg",
                            ProductId = 1
                        },
                        new
                        {
                            ImageId = 2,
                            ImageUrl = "maske1.2.jpg",
                            ProductId = 1
                        },
                        new
                        {
                            ImageId = 3,
                            ImageUrl = "maske1.3.jpg",
                            ProductId = 1
                        },
                        new
                        {
                            ImageId = 4,
                            ImageUrl = "maske1.4.jpg",
                            ProductId = 1
                        },
                        new
                        {
                            ImageId = 5,
                            ImageUrl = "maske2.1.jpg",
                            ProductId = 2
                        },
                        new
                        {
                            ImageId = 6,
                            ImageUrl = "maske2.2.jpg",
                            ProductId = 2
                        },
                        new
                        {
                            ImageId = 7,
                            ImageUrl = "maske2.3.jpg",
                            ProductId = 2
                        },
                        new
                        {
                            ImageId = 8,
                            ImageUrl = "maske3.1.jpg",
                            ProductId = 3
                        },
                        new
                        {
                            ImageId = 9,
                            ImageUrl = "maske3.2.jpg",
                            ProductId = 3
                        },
                        new
                        {
                            ImageId = 10,
                            ImageUrl = "maske3.3.jpg",
                            ProductId = 3
                        },
                        new
                        {
                            ImageId = 11,
                            ImageUrl = "maske3.4.jpg",
                            ProductId = 3
                        },
                        new
                        {
                            ImageId = 12,
                            ImageUrl = "maske3.5.jpg",
                            ProductId = 3
                        },
                        new
                        {
                            ImageId = 13,
                            ImageUrl = "dezenfektan1.1.jpg",
                            ProductId = 4
                        },
                        new
                        {
                            ImageId = 14,
                            ImageUrl = "dezenfektan1.2.jpg",
                            ProductId = 4
                        },
                        new
                        {
                            ImageId = 15,
                            ImageUrl = "dezenfektan1.3.jpg",
                            ProductId = 4
                        },
                        new
                        {
                            ImageId = 16,
                            ImageUrl = "dezenfektan1.4.jpg",
                            ProductId = 4
                        },
                        new
                        {
                            ImageId = 17,
                            ImageUrl = "dezenfektan2.1.jpg",
                            ProductId = 5
                        },
                        new
                        {
                            ImageId = 18,
                            ImageUrl = "dezenfektan2.2.jpg",
                            ProductId = 5
                        },
                        new
                        {
                            ImageId = 19,
                            ImageUrl = "dezenfektan2.3.jpg",
                            ProductId = 5
                        },
                        new
                        {
                            ImageId = 20,
                            ImageUrl = "dezenfektan2.4.jpg",
                            ProductId = 5
                        },
                        new
                        {
                            ImageId = 21,
                            ImageUrl = "dezenfektan2.5.jpg",
                            ProductId = 5
                        },
                        new
                        {
                            ImageId = 22,
                            ImageUrl = "dezenfektan3.1.jpg",
                            ProductId = 6
                        },
                        new
                        {
                            ImageId = 23,
                            ImageUrl = "dezenfektan3.2.jpg",
                            ProductId = 6
                        },
                        new
                        {
                            ImageId = 24,
                            ImageUrl = "dezenfektan3.3.jpg",
                            ProductId = 6
                        },
                        new
                        {
                            ImageId = 25,
                            ImageUrl = "dezenfektan3.4.jpg",
                            ProductId = 6
                        },
                        new
                        {
                            ImageId = 26,
                            ImageUrl = "eldiven1.1.jpg",
                            ProductId = 7
                        },
                        new
                        {
                            ImageId = 27,
                            ImageUrl = "eldiven1.2.jpg",
                            ProductId = 7
                        },
                        new
                        {
                            ImageId = 28,
                            ImageUrl = "eldiven1.3.jpg",
                            ProductId = 7
                        },
                        new
                        {
                            ImageId = 29,
                            ImageUrl = "eldiven2.1.jpg",
                            ProductId = 8
                        },
                        new
                        {
                            ImageId = 30,
                            ImageUrl = "eldiven2.2.jpg",
                            ProductId = 8
                        },
                        new
                        {
                            ImageId = 31,
                            ImageUrl = "siperlik1.1.jpg",
                            ProductId = 9
                        },
                        new
                        {
                            ImageId = 32,
                            ImageUrl = "siperlik1.2.jpg",
                            ProductId = 9
                        },
                        new
                        {
                            ImageId = 33,
                            ImageUrl = "siperlik2.1.jpg",
                            ProductId = 10
                        },
                        new
                        {
                            ImageId = 34,
                            ImageUrl = "siperlik2.2.jpg",
                            ProductId = 10
                        },
                        new
                        {
                            ImageId = 35,
                            ImageUrl = "siperlik3.1.jpg",
                            ProductId = 11
                        },
                        new
                        {
                            ImageId = 36,
                            ImageUrl = "siperlik3.2.jpg",
                            ProductId = 11
                        });
                });

            modelBuilder.Entity("Anti_Corona.Entity.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Anti_Corona.Entity.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsHomePage")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOnSale")
                        .HasColumnType("bit");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            Date = new DateTime(2020, 12, 27, 13, 30, 50, 0, DateTimeKind.Unspecified),
                            Description = "Hayat Kimya olarak, hijyen ve temizlik kategorilerindeki 33 yıllık deneyimimizi Evony markamızla cerrahi maske kategorisine taşıyoruz. TSE Tip2R ve TSE Güvenli Üretim sertifikalı Evony Maske %99 a kadar bakteri filtrasyonu sağlamaktadır. 3 katmanlı, Melt Blown+ Spunbond cilde dost katmanlar. Tek katmanda değil her katmanda koruma. Pamuksu Yumuşak katmanlarla saatlerce rahat kullanım. Acıtmayan Yumuşak Elastik Kulaklarıyla koruma ve konforu bir arada. Yüze tam uyumlu Burun Teli. Alerji Yapmaz. Latex İçermez. Paraben içermez. Naylon İçermez. CE sertifikalı. TSE Tip2R , EN14683, ISO13485, TSE Güvenli ",
                            IsHomePage = true,
                            IsOnSale = true,
                            Price = 100.0,
                            Stock = 100,
                            Title = "Evony Yumuşak Elastik Kulaklı Maske 100 Adet"
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            Date = new DateTime(2020, 12, 26, 12, 30, 50, 0, DateTimeKind.Unspecified),
                            Description = "1 Kutuda 50 adet bulunmaktadır. 2 Kutu Gönderilecektir.Hava Geçiren Yapı.Yumuşak ve Ayarlanabilir, Tahriş etmez, Rahat takılır.Fiberglass ve Lateks İçermiyor.Filtreli, Üç katlı, tek kullanımlık, lastikli, 3 kıvrımlı.Polipropilen / Non-Woven.Yuvarlak lastikli ultrasonik dikişlidir.Kullanımda rahatlık.Lateks içermez.Hava geçirgen, kolay nefes almayı sağlayan RC cerrahi maske non woven kumaştan üretilmiştir.Gipe lastik kullanılan bu maske tek kullanımlık olup hijyenik ve CE'li dir.Yüze tam uyumludur.",
                            IsHomePage = true,
                            IsOnSale = true,
                            Price = 200.0,
                            Stock = 200,
                            Title = "Smask Cerrahi Telli 3 Katlı Nonwoven Filtreli Maske 50'li 2 Adet"
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 1,
                            Date = new DateTime(2020, 12, 26, 12, 30, 50, 0, DateTimeKind.Unspecified),
                            Description = "Happy Yumuşak Elastik Kulaklı 3 Katlı Telli Mavi Cerrahi Maske 50 li x 2 Adet,Acıtmayan yumuşak elastik kulaklarıyla koruma ve konforu bir arada,Yüze tam uyumlu burun teli,Alerji Yapmaz,Latex İçermez,Klor içermez,Naylon İçermez,Ce Sertifikalı,FDA , ISO 13485 ",
                            IsHomePage = true,
                            IsOnSale = true,
                            Price = 200.0,
                            Stock = 200,
                            Title = "Happy Yumuşak Elastik Kulaklı 3 Katlı Telli Mavi Cerrahi Maske 100 Lü"
                        },
                        new
                        {
                            ProductId = 7,
                            CategoryId = 2,
                            Date = new DateTime(2020, 12, 26, 12, 30, 50, 0, DateTimeKind.Unspecified),
                            Description = "Beybi tek kullanımlık eldiven, elin şeklini alarak kolay hareket imkanı sağlar. Tek kullanımlık eldiven ile yemekler hijyenik bir şekilde hazırlanır. Hem temizlik hem de yemek yapımı sırasında ellerin kurumasını, kirlenmesini ve tahriş olmasını önler.Tek kullanımlıkMiktar : Kutu içerisinde 100 AdetRenk : Beyaz",
                            IsHomePage = true,
                            IsOnSale = true,
                            Price = 200.0,
                            Stock = 200,
                            Title = "Beybi Latex Pudralı Çok Amaçlı Kullan At Eldiven Lateks 100' lü (L) Large / Büyük"
                        },
                        new
                        {
                            ProductId = 8,
                            CategoryId = 2,
                            Date = new DateTime(2020, 12, 26, 12, 30, 50, 0, DateTimeKind.Unspecified),
                            Description = "Pudrasız Lateks Eldiven (Large)- Pudrasız Lateks Eldivenler, Hijyen Gerektiren Tüm Ortamlarda, Elle Bulaşması Muhtemel Mikrop, Virüs Ve Bakterilere Karşı Koruyucudur. - Doğal Lateks Hammaddeden Üretilmiştir. - Giymesi Ve Çıkartması Kolaydır. - Yumuşak Ve Elastik Yapısı Sayesinde Elinize Tam Oturur. - Hastaneler, Diş Klinikleri, Veterinerler, Laboratuvarlar, İlaç Sektörü, Deterjan Ve Temizlik, Kozmetik Gibi Çok Çeşitli Endüstrilerde Kullanım İçin İdealdir. - Beyaz Renklidir. - Yuvarlak Hatlı Manşeti Sayesinde Kolayca Giyilir Ve Çıkartılır. Özellikle Hastane Kullanımlarında Çok Hızlı Giyilip Çıkartılabilir.",
                            IsHomePage = true,
                            IsOnSale = true,
                            Price = 200.0,
                            Stock = 200,
                            Title = "Pudrasız Lateks Eldiven (Large)"
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 3,
                            Date = new DateTime(2020, 12, 26, 12, 30, 50, 0, DateTimeKind.Unspecified),
                            Description = "Sağlık bakanlığı tarafından Ruhsatnameli, ISO ve CE sertifikalı, Msds Raporu bulunmaktadır. Toplamda % 70 Alkol oranına sahiptir. (% 58 Ethil % 12 İzopropil).Ürüne kullanım esnasında kokusundan dolayı rahatsız etmemesi amacı ile % 002 esans eklenerek herkes tarafından kullanılabilinir hale getirilmiştir.Elde hızlıca kurumaktadır.",
                            IsHomePage = true,
                            IsOnSale = true,
                            Price = 93.0,
                            Stock = 200,
                            Title = "Dermosept Handplus El Dezenfektanı 5000 ml"
                        },
                        new
                        {
                            ProductId = 5,
                            CategoryId = 3,
                            Date = new DateTime(2020, 12, 26, 12, 30, 50, 0, DateTimeKind.Unspecified),
                            Description = "Cildinizde ekonomik ve sağlıklı bir şekilde virüs, bakteri ve mantarlara karşı %100 doğal koruma sağlayarak, hayatınızın her alanında yanınızda taşıyabilmeniz için tasarlanmış bir üründür.  Crystalin Eco Antiseptik Dezenfektan Hijyenik Yaşam Kiti içerisinde bulunan 1 litrelik şişedeki konsantre ürünle 10 litre anti-septik dezenfektan elde ederek aylarca güvenle kullanabilirsiniz.",
                            IsHomePage = true,
                            IsOnSale = true,
                            Price = 93.0,
                            Stock = 200,
                            Title = "Crystalin Eco Dezenfektan Hijyenik Yaşam Kiti"
                        },
                        new
                        {
                            ProductId = 6,
                            CategoryId = 3,
                            Date = new DateTime(2020, 12, 26, 12, 30, 50, 0, DateTimeKind.Unspecified),
                            Description = "Sağlık bakanlığı tarafından Ruhsatnameli, ISO ve CE sertifikalı, Msds Raporu bulunmaktadır. Toplamda % 70 Alkol oranına sahiptir. (% 58 Ethil % 12 İzopropil).Ürüne kullanım esnasında kokusundan dolayı rahatsız etmemesi amacı ile % 002 esans eklenerek herkes tarafından kullanılabilinir hale getirilmiştir.Elde hızlıca kurumaktadır.",
                            IsHomePage = true,
                            IsOnSale = true,
                            Price = 93.0,
                            Stock = 200,
                            Title = "Deep Fresh Antibakteriyel El Temizleme Jeli 3 x 200 ml"
                        },
                        new
                        {
                            ProductId = 9,
                            CategoryId = 4,
                            Date = new DateTime(2020, 12, 26, 12, 30, 50, 0, DateTimeKind.Unspecified),
                            Description = "ÖzgürceSeç Şeffaf Maske Yikanabilir Yeniden Kullanabilabilir Kulakta yara ve iz bırakmaz.Yumuşak malzemeden üretilmiştir.Başta ağrı ve ağırlık hissi yaratmaz.Herkes rahatlıkla kullanabilir.Her bedene göre ayarlanabilir.Maskemizin en alt kısmından hava sirkülasyonu  gerçekleşmektedir.Korucuyu maskedir.Ürün tek kullanımlık değildir.Yıkanabilir.Uzun kullanım süresi  tanımaktadır.Ürünümüzün CE - ISO belgeleri bulunmaktadır.",
                            IsHomePage = true,
                            IsOnSale = true,
                            Price = 93.0,
                            Stock = 200,
                            Title = "ÖzgürceSeç Şeffaf Maske Yikanabilir Yeniden Kullanabilabilir"
                        },
                        new
                        {
                            ProductId = 10,
                            CategoryId = 4,
                            Date = new DateTime(2020, 12, 26, 12, 30, 50, 0, DateTimeKind.Unspecified),
                            Description = "Siperlik klipsi; Koruyucu maskenin burun, ağız ve çene bölgesinde oluşabilecek boşlukları minimuma indirerek Siperliğin yüze tam oturmasını sağlar.",
                            IsHomePage = true,
                            IsOnSale = true,
                            Price = 93.0,
                            Stock = 200,
                            Title = "Tuğbasan Yüz Koruyucu Siperlik"
                        },
                        new
                        {
                            ProductId = 11,
                            CategoryId = 4,
                            Date = new DateTime(2020, 12, 26, 12, 30, 50, 0, DateTimeKind.Unspecified),
                            Description = "Partikül, tükürük, damlacık, toz ve benzeri küçük cisimlerin yüzünüze (göz, ağız, burun) gelmesini ve sizden karşı tarafa gitmesini engeller.Şeffaf siperliksağlık ürünleri yönetmenliğine uygun; kırılmaz, esnet Pet(polietilen) malzemeden üretilmiştir. Karşılıklı konuşma, işlem (muayene, karşılama, satış, toplantı vb.) esnasında kişisel kullanım içindir.Hafiftir, kullanımı kolaydır, çıkarılıp takılması basittir.  Esnek materyal kullanıldığından yetişkin her başa uyum sağlar. Görüş alanınızı kapatmaz, görüş alanı geniştir. Işık geçirgenliği yüksek olduğundan görüntü kaybına neden olmaz. Ürün dezenfekte edilmiş olarak gönderilir ve dezenfekte edilerek tekrar kullanılabilir.",
                            IsHomePage = true,
                            IsOnSale = true,
                            Price = 59.899999999999999,
                            Stock = 200,
                            Title = "Medizer Novid Siyah Gözlüklü Yüz Koruyucu Siperli"
                        });
                });

            modelBuilder.Entity("Anti_Corona.Entity.CartItem", b =>
                {
                    b.HasOne("Anti_Corona.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Anti_Corona.Entity.Comment", b =>
                {
                    b.HasOne("Anti_Corona.Entity.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Anti_Corona.Entity.Image", b =>
                {
                    b.HasOne("Anti_Corona.Entity.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Anti_Corona.Entity.OrderItem", b =>
                {
                    b.HasOne("Anti_Corona.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Anti_Corona.Entity.Product", b =>
                {
                    b.HasOne("Anti_Corona.Entity.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
