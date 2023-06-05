﻿// <auto-generated />
using System;
using ConnOutlineMessenger.DBstur;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConnOutlineMessenger.DataAccess.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230605140322_update2")]
    partial class update2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.Property<long>("ChatsId")
                        .HasColumnType("bigint");

                    b.Property<long>("MembersId")
                        .HasColumnType("bigint");

                    b.HasKey("ChatsId", "MembersId");

                    b.HasIndex("MembersId");

                    b.ToTable("ChatUser");
                });

            modelBuilder.Entity("ConnOutlineMessenger.DataAccess.Entities.Friend", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("FriendUserId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FriendUserId");

                    b.HasIndex("Id");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("ConnOutlineMessenger.Entities.Chat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ChatName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("ConnOutlineMessenger.Entities.Image", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<byte[]>("ImageData")
                        .HasMaxLength(2097152)
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("MessageId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("MessageId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ConnOutlineMessenger.Entities.Message", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CurrentChatId")
                        .HasColumnType("bigint");

                    b.Property<string>("MessageText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SendTime")
                        .HasColumnType("datetime2");

                    b.Property<long>("SenderId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CurrentChatId");

                    b.HasIndex("Id");

                    b.HasIndex("SenderId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ConnOutlineMessenger.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UserIconId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.HasIndex("UserIconId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ChatUser", b =>
                {
                    b.HasOne("ConnOutlineMessenger.Entities.Chat", null)
                        .WithMany()
                        .HasForeignKey("ChatsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConnOutlineMessenger.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConnOutlineMessenger.DataAccess.Entities.Friend", b =>
                {
                    b.HasOne("ConnOutlineMessenger.Entities.User", "FriendUser")
                        .WithMany("Friends")
                        .HasForeignKey("FriendUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FriendUser");
                });

            modelBuilder.Entity("ConnOutlineMessenger.Entities.Image", b =>
                {
                    b.HasOne("ConnOutlineMessenger.Entities.Message", null)
                        .WithMany("MessageImg")
                        .HasForeignKey("MessageId");
                });

            modelBuilder.Entity("ConnOutlineMessenger.Entities.Message", b =>
                {
                    b.HasOne("ConnOutlineMessenger.Entities.Chat", "CurrentChat")
                        .WithMany("Messages")
                        .HasForeignKey("CurrentChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConnOutlineMessenger.Entities.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentChat");

                    b.Navigation("Sender");
                });

            modelBuilder.Entity("ConnOutlineMessenger.Entities.User", b =>
                {
                    b.HasOne("ConnOutlineMessenger.Entities.Image", "UserIcon")
                        .WithMany()
                        .HasForeignKey("UserIconId");

                    b.Navigation("UserIcon");
                });

            modelBuilder.Entity("ConnOutlineMessenger.Entities.Chat", b =>
                {
                    b.Navigation("Messages");
                });

            modelBuilder.Entity("ConnOutlineMessenger.Entities.Message", b =>
                {
                    b.Navigation("MessageImg");
                });

            modelBuilder.Entity("ConnOutlineMessenger.Entities.User", b =>
                {
                    b.Navigation("Friends");
                });
#pragma warning restore 612, 618
        }
    }
}
