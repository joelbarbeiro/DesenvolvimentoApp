﻿// <auto-generated />
namespace iCantine.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
<<<<<<<< HEAD:Migrations/202406182034078_initial_update13.Designer.cs
    public sealed partial class initial_update13 : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(initial_update13));
        
        string IMigrationMetadata.Id
        {
            get { return "202406182034078_initial_update13"; }
========
    public sealed partial class updt : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(updt));
        
        string IMigrationMetadata.Id
        {
            get { return "202406182120290_updt"; }
>>>>>>>> 76d03a9afd178144af8a8934c89681952e040fc3:Migrations/202406182120290_updt.Designer.cs
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
