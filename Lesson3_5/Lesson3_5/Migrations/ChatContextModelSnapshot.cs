﻿// <auto-generated />
using System;
using Lesson3_5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lesson3_5.Migrations
{
    [DbContext(typeof(ChatContext))]
    partial class ChatContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Lesson3_5.Models.Message", b =>
                {
                    b.Property<int?>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("MessageId"));

                    b.Property<DateTime>("DateSend")
                        .HasColumnType("datetime2")
                        .HasColumnName("messageData");

                    b.Property<bool>("IsSent")
                        .HasColumnType("bit")
                        .HasColumnName("is_sent");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("messageText");

                    b.Property<int?>("UserFromId")
                        .HasColumnType("int");

                    b.Property<int?>("UserToId")
                        .HasColumnType("int");

                    b.HasKey("MessageId")
                        .HasName("messagePk");

                    b.HasIndex("UserFromId");

                    b.HasIndex("UserToId");

                    b.ToTable("messages", (string)null);
                });

            modelBuilder.Entity("Lesson3_5.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("FullName");

                    b.HasKey("Id")
                        .HasName("userPk");

                    b.HasIndex("FullName")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Lesson3_5.Models.Message", b =>
                {
                    b.HasOne("Lesson3_5.Models.User", "UserFrom")
                        .WithMany("MessagesFrom")
                        .HasForeignKey("UserFromId")
                        .HasConstraintName("messageFromUserFK");

                    b.HasOne("Lesson3_5.Models.User", "UserTo")
                        .WithMany("MessagesTo")
                        .HasForeignKey("UserToId")
                        .HasConstraintName("messageToUserFK");

                    b.Navigation("UserFrom");

                    b.Navigation("UserTo");
                });

            modelBuilder.Entity("Lesson3_5.Models.User", b =>
                {
                    b.Navigation("MessagesFrom");

                    b.Navigation("MessagesTo");
                });
#pragma warning restore 612, 618
        }
    }
}
