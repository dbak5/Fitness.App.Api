using System;
using System.Collections.Generic;
using Fitness.App.Api.Domain.BodyPart.Entities;
using Fitness.App.Api.Domain.Category.Entities;
using Fitness.App.Api.Domain.Equipment.Entities;
using Fitness.App.Api.Domain.Exercise.Entities;
using Fitness.App.Api.Domain.Pb.Entities;
using Fitness.App.Api.Domain.Program.Entities;
using Fitness.App.Api.Domain.Workout.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fitness.App.Api.Persistence;

public partial class FitnessAppContext : DbContext
{
    public FitnessAppContext()
    {
    }

    public FitnessAppContext(DbContextOptions<FitnessAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BodyPart> BodyParts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Exercise> Exercises { get; set; }

    public virtual DbSet<Pb> Pbs { get; set; }

    public virtual DbSet<Program> Programs { get; set; }

    public virtual DbSet<Workout> Workouts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Host=fitness-sql.home.local;Port=5432;Database=fitness_app;Connection Lifetime=0;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BodyPart>(entity =>
        {
            entity.HasKey(e => e.BodyPartId).HasName("body_part_pkey");

            entity.ToTable("body_part");

            entity.Property(e => e.BodyPartId).HasColumnName("body_part_id");
            entity.Property(e => e.BodyPartName)
                .HasColumnType("character varying")
                .HasColumnName("body_part_name");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("category_pkey");

            entity.ToTable("category");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasColumnType("character varying")
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.EquipmentId).HasName("equipment_pkey");

            entity.ToTable("equipment");

            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.EquipmentName)
                .HasColumnType("character varying")
                .HasColumnName("equipment_name");
        });

        modelBuilder.Entity<Exercise>(entity =>
        {
            entity.HasKey(e => e.ExerciseId).HasName("exercise_pkey");

            entity.ToTable("exercise");

            entity.Property(e => e.ExerciseId).HasColumnName("exercise_id");
            entity.Property(e => e.BodyPart).HasColumnName("body_part");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.ExerciseName)
                .HasColumnType("character varying")
                .HasColumnName("exercise_name");
            entity.Property(e => e.LastActivity).HasColumnName("last_activity");

            entity.HasOne(d => d.BodyPartNavigation).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.BodyPart)
                .HasConstraintName("exercise_body_part_fkey");

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Exercises)
                .HasForeignKey(d => d.Category)
                .HasConstraintName("exercise_category_fkey");
        });

        modelBuilder.Entity<Pb>(entity =>
        {
            entity.HasKey(e => e.PbId).HasName("pb_pkey");

            entity.ToTable("pb");

            entity.Property(e => e.PbId).HasColumnName("pb_id");
            entity.Property(e => e.Exercise).HasColumnName("exercise");
            entity.Property(e => e.Workout).HasColumnName("workout");

            entity.HasOne(d => d.ExerciseNavigation).WithMany(p => p.Pbs)
                .HasForeignKey(d => d.Exercise)
                .HasConstraintName("pb_exercise_fkey");

            entity.HasOne(d => d.WorkoutNavigation).WithMany(p => p.Pbs)
                .HasForeignKey(d => d.Workout)
                .HasConstraintName("pb_workout_fkey");
        });

        modelBuilder.Entity<Program>(entity =>
        {
            entity.HasKey(e => e.ProgramId).HasName("program_pkey");

            entity.ToTable("program");

            entity.Property(e => e.ProgramId).HasColumnName("program_id");
            entity.Property(e => e.Day).HasColumnName("day");
            entity.Property(e => e.Equipment).HasColumnName("equipment");
            entity.Property(e => e.Exercise).HasColumnName("exercise");
            entity.Property(e => e.ProgramName)
                .HasColumnType("character varying")
                .HasColumnName("program_name");
            entity.Property(e => e.Reps).HasColumnName("reps");
            entity.Property(e => e.Sets).HasColumnName("sets");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.EquipmentNavigation).WithMany(p => p.Programs)
                .HasForeignKey(d => d.Equipment)
                .HasConstraintName("program_equipment_fkey");

            entity.HasOne(d => d.ExerciseNavigation).WithMany(p => p.Programs)
                .HasForeignKey(d => d.Exercise)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("program_exercise_fkey");
        });

        modelBuilder.Entity<Workout>(entity =>
        {
            entity.HasKey(e => e.WorkoutId).HasName("workout_pkey");

            entity.ToTable("workout");

            entity.Property(e => e.WorkoutId).HasColumnName("workout_id");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Equipment).HasColumnName("equipment");
            entity.Property(e => e.Exercise).HasColumnName("exercise");
            entity.Property(e => e.MadeLift).HasColumnName("made_lift");
            entity.Property(e => e.Note)
                .HasColumnType("character varying")
                .HasColumnName("note");
            entity.Property(e => e.Reps).HasColumnName("reps");
            entity.Property(e => e.Sets).HasColumnName("sets");
            entity.Property(e => e.Weight).HasColumnName("weight");

            entity.HasOne(d => d.EquipmentNavigation).WithMany(p => p.Workouts)
                .HasForeignKey(d => d.Equipment)
                .HasConstraintName("workout_equipment_fkey");

            entity.HasOne(d => d.ExerciseNavigation).WithMany(p => p.Workouts)
                .HasForeignKey(d => d.Exercise)
                .HasConstraintName("workout_exercise_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
