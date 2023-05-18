﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NovyGorod.Infrastructure.DataAccess.EF;

#nullable disable

namespace NovyGorod.Infrastructure.DataAccess.EF.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230518192401_Alter_AttachmentTranslation_PreviewMediaColumnAdded")]
    partial class AlterAttachmentTranslationPreviewMediaColumnAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NovyGorod.Domain.Models.Attachments.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BlockId")
                        .HasColumnType("int");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BlockId");

                    b.ToTable("Attachment");
                });

            modelBuilder.Entity("NovyGorod.Domain.Models.Attachments.AttachmentTranslation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int?>("PreviewMediaId")
                        .HasColumnType("int");

                    b.Property<int>("SourceMediaId")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("PreviewMediaId");

                    b.HasIndex("SourceMediaId");

                    b.HasIndex("EntityId", "LanguageId")
                        .IsUnique();

                    b.ToTable("AttachmentTranslation");
                });

            modelBuilder.Entity("NovyGorod.Domain.Models.Common.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Language");
                });

            modelBuilder.Entity("NovyGorod.Domain.Models.MediaData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsLocal")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Url")
                        .IsUnique();

                    b.ToTable("MediaData");
                });

            modelBuilder.Entity("NovyGorod.Domain.Models.Posts.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("NovyGorod.Domain.Models.Posts.PostBlock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Index")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("PostBlock");
                });

            modelBuilder.Entity("NovyGorod.Domain.Models.Posts.PostBlockTranslation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("EntityId", "LanguageId")
                        .IsUnique();

                    b.ToTable("PostBlockTranslation");
                });

            modelBuilder.Entity("NovyGorod.Domain.Models.Posts.PostTranslation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("PreviewId")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.HasIndex("PreviewId");

                    b.HasIndex("VideoId");

                    b.HasIndex("EntityId", "LanguageId")
                        .IsUnique();

                    b.ToTable("PostTranslation");
                });

            modelBuilder.Entity("NovyGorod.Domain.Models.Posts.PostTypeLink", b =>
                {
                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Type", "PostId");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Type", "PostId"));

                    b.HasIndex("PostId");

                    b.ToTable("PostTypeLink");
                });

            modelBuilder.Entity("NovyGorod.Domain.Models.Attachments.Attachment", b =>
                {
                    b.HasOne("NovyGorod.Domain.Models.Posts.PostBlock", "Block")
                        .WithMany("Attachments")
                        .HasForeignKey("BlockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Block");
                });

            modelBuilder.Entity("NovyGorod.Domain.Models.Attachments.AttachmentTranslation", b =>
                {
                    b.HasOne("NovyGorod.Domain.Models.Attachments.Attachment", "Entity")
                        .WithMany("Translations")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NovyGorod.Domain.Models.Common.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NovyGorod.Domain.Models.MediaData", "PreviewMedia")
                        .WithMany()
                        .HasForeignKey("PreviewMediaId");

                    b.HasOne("NovyGorod.Domain.Models.MediaData", "SourceMedia")
                        .WithMany()
                        .HasForeignKey("SourceMediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entity");

                    b.Navigation("Language");

                    b.Navigation("PreviewMedia");

                    b.Navigation("SourceMedia");
                });

            modelBuilder.Entity("NovyGorod.Domain.Models.Posts.PostBlock", b =>
                {
                    b.HasOne("NovyGorod.Domain.Models.Posts.Post", "Post")
                        .WithMany("Blocks")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("NovyGorod.Domain.Models.Posts.PostBlockTranslation", b =>
                {
                    b.HasOne("NovyGorod.Domain.Models.Posts.PostBlock", "Entity")
                        .WithMany("Translations")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NovyGorod.Domain.Models.Common.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entity");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("NovyGorod.Domain.Models.Posts.PostTranslation", b =>
                {
                    b.HasOne("NovyGorod.Domain.Models.Posts.Post", "Entity")
                        .WithMany("Translations")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NovyGorod.Domain.Models.Common.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NovyGorod.Domain.Models.MediaData", "Preview")
                        .WithMany()
                        .HasForeignKey("PreviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NovyGorod.Domain.Models.MediaData", "Video")
                        .WithMany()
                        .HasForeignKey("VideoId");

                    b.Navigation("Entity");

                    b.Navigation("Language");

                    b.Navigation("Preview");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("NovyGorod.Domain.Models.Posts.PostTypeLink", b =>
                {
                    b.HasOne("NovyGorod.Domain.Models.Posts.Post", "Post")
                        .WithMany("TypeLinks")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("NovyGorod.Domain.Models.Attachments.Attachment", b =>
                {
                    b.Navigation("Translations");
                });

            modelBuilder.Entity("NovyGorod.Domain.Models.Posts.Post", b =>
                {
                    b.Navigation("Blocks");

                    b.Navigation("Translations");

                    b.Navigation("TypeLinks");
                });

            modelBuilder.Entity("NovyGorod.Domain.Models.Posts.PostBlock", b =>
                {
                    b.Navigation("Attachments");

                    b.Navigation("Translations");
                });
#pragma warning restore 612, 618
        }
    }
}
