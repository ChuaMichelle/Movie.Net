﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Movie.Net
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class DataModelContainer : DbContext
{
    public DataModelContainer()
        : base("name=DataModelContainer")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Movies> Movies { get; set; }

    public virtual DbSet<Genres> Genres { get; set; }

    public virtual DbSet<Comments> Comments { get; set; }

}

}

