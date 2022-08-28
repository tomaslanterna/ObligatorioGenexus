using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Web.Services;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class reorg : GXReorganization
   {
      public reorg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public reorg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      void executePrivate( )
      {
         SetCreateDataBase( ) ;
         CreateDataBase( ) ;
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void CreateDataBase( )
      {
         DS = (GxDataStore)(context.GetDataStore( "Default"));
         ErrCode = DS.Connection.FullConnect();
         DataBaseName = DS.Connection.Database;
         if ( ErrCode != 0 )
         {
            DS.Connection.Database = "";
            ErrCode = DS.Connection.FullConnect();
            if ( ErrCode == 0 )
            {
               try
               {
                  GeneXus.Reorg.GXReorganization.AddMsg( GXResourceManager.GetMessage("GXM_dbcrea")+ " " +DataBaseName , null);
                  cmdBuffer = "CREATE DATABASE " + "[" + DataBaseName + "]";
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
                  Count = 1;
               }
               catch ( Exception ex )
               {
                  ErrCode = 1;
                  GeneXus.Reorg.GXReorganization.AddMsg( ex.Message , null);
                  throw;
               }
               ErrCode = DS.Connection.Disconnect();
               DS.Connection.Database = DataBaseName;
               ErrCode = DS.Connection.FullConnect();
               while ( ( ErrCode != 0 ) && ( Count > 0 ) && ( Count < 30 ) )
               {
                  Res = GXUtil.Sleep( 1);
                  ErrCode = DS.Connection.FullConnect();
                  Count = (short)(Count+1);
               }
               setupDB = 0;
               if ( ( setupDB == 1 ) || GeneXus.Configuration.Preferences.MustSetupDB( ) )
               {
                  defaultUsers = GXUtil.DefaultWebUser( context);
                  short gxidx;
                  gxidx = 1;
                  while ( gxidx <= defaultUsers.Count )
                  {
                     defaultUser = ((string)defaultUsers.Item(gxidx));
                     try
                     {
                        GeneXus.Reorg.GXReorganization.AddMsg( GXResourceManager.GetMessage("GXM_dbadduser", new   object[]  {defaultUser, DataBaseName}) , null);
                        cmdBuffer = "CREATE LOGIN " + "[" + defaultUser + "]" + " FROM WINDOWS";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "CREATE USER " + "[" + defaultUser + "]" + " FOR LOGIN " + "[" + defaultUser + "]";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "EXEC sp_addrolemember N'db_datareader', N'" + defaultUser + "'";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "EXEC sp_addrolemember N'db_datawriter', N'" + defaultUser + "'";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     gxidx = (short)(gxidx+1);
                  }
               }
            }
            if ( ErrCode != 0 )
            {
               ErrMsg = DS.ErrDescription;
               GeneXus.Reorg.GXReorganization.AddMsg( ErrMsg , null);
               ErrCode = 1;
               throw new Exception( ErrMsg) ;
            }
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void CreateEspectaculoFuncion( )
      {
         string cmdBuffer = "";
         /* Indices for table EspectaculoFuncion */
         try
         {
            cmdBuffer=" CREATE TABLE [EspectaculoFuncion] ([EspectaculoId] smallint NOT NULL , [EspectaculoFuncionId] smallint NOT NULL , [EspectaculoFuncionName] nvarchar(40) NOT NULL , [EspectaculoFuncionPrecio] smallint NOT NULL , PRIMARY KEY([EspectaculoId], [EspectaculoFuncionId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[EspectaculoFuncion]") ;
               cmdBuffer=" DROP TABLE [EspectaculoFuncion] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[EspectaculoFuncion]") ;
                  cmdBuffer=" DROP VIEW [EspectaculoFuncion] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[EspectaculoFuncion]") ;
                     cmdBuffer=" DROP FUNCTION [EspectaculoFuncion] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [EspectaculoFuncion] ([EspectaculoId] smallint NOT NULL , [EspectaculoFuncionId] smallint NOT NULL , [EspectaculoFuncionName] nvarchar(40) NOT NULL , [EspectaculoFuncionPrecio] smallint NOT NULL , PRIMARY KEY([EspectaculoId], [EspectaculoFuncionId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEspectaculoLugarSector( )
      {
         string cmdBuffer = "";
         /* Indices for table EspectaculoLugarSector */
         try
         {
            cmdBuffer=" CREATE TABLE [EspectaculoLugarSector] ([EspectaculoId] smallint NOT NULL , [LugarSectorId] smallint NOT NULL , [LugarSectorEstadoSector] BIT NOT NULL , PRIMARY KEY([EspectaculoId], [LugarSectorId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[EspectaculoLugarSector]") ;
               cmdBuffer=" DROP TABLE [EspectaculoLugarSector] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[EspectaculoLugarSector]") ;
                  cmdBuffer=" DROP VIEW [EspectaculoLugarSector] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[EspectaculoLugarSector]") ;
                     cmdBuffer=" DROP FUNCTION [EspectaculoLugarSector] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [EspectaculoLugarSector] ([EspectaculoId] smallint NOT NULL , [LugarSectorId] smallint NOT NULL , [LugarSectorEstadoSector] BIT NOT NULL , PRIMARY KEY([EspectaculoId], [LugarSectorId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEspectaculo( )
      {
         string cmdBuffer = "";
         /* Indices for table Espectaculo */
         try
         {
            cmdBuffer=" CREATE TABLE [Espectaculo] ([EspectaculoId] smallint NOT NULL IDENTITY(1,1), [EspectaculoName] nvarchar(40) NOT NULL , [EspectaculoFecha] datetime NOT NULL , [LugarId] smallint NOT NULL , [TipoEspectaculoId] smallint NOT NULL , [EspectaculoImagen] VARBINARY(MAX) NOT NULL , [EspectaculoImagen_GXI] varchar(2048) NULL , PRIMARY KEY([EspectaculoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Espectaculo]") ;
               cmdBuffer=" DROP TABLE [Espectaculo] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Espectaculo]") ;
                  cmdBuffer=" DROP VIEW [Espectaculo] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Espectaculo]") ;
                     cmdBuffer=" DROP FUNCTION [Espectaculo] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Espectaculo] ([EspectaculoId] smallint NOT NULL IDENTITY(1,1), [EspectaculoName] nvarchar(40) NOT NULL , [EspectaculoFecha] datetime NOT NULL , [LugarId] smallint NOT NULL , [TipoEspectaculoId] smallint NOT NULL , [EspectaculoImagen] VARBINARY(MAX) NOT NULL , [EspectaculoImagen_GXI] varchar(2048) NULL , PRIMARY KEY([EspectaculoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IESPECTACULO1] ON [Espectaculo] ([TipoEspectaculoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IESPECTACULO1] ON [Espectaculo] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IESPECTACULO1] ON [Espectaculo] ([TipoEspectaculoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IESPECTACULO2] ON [Espectaculo] ([LugarId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IESPECTACULO2] ON [Espectaculo] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IESPECTACULO2] ON [Espectaculo] ([LugarId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [UESPECTACULO] ON [Espectaculo] ([EspectaculoName] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [UESPECTACULO] ON [Espectaculo] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [UESPECTACULO] ON [Espectaculo] ([EspectaculoName] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateLugarSector( )
      {
         string cmdBuffer = "";
         /* Indices for table LugarSector */
         try
         {
            cmdBuffer=" CREATE TABLE [LugarSector] ([LugarId] smallint NOT NULL , [LugarSectorId] smallint NOT NULL , [LugarSectorName] nvarchar(40) NOT NULL , [LugarSectorCantidad] smallint NOT NULL , [LugarSectorPrecio] smallint NOT NULL , PRIMARY KEY([LugarId], [LugarSectorId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[LugarSector]") ;
               cmdBuffer=" DROP TABLE [LugarSector] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[LugarSector]") ;
                  cmdBuffer=" DROP VIEW [LugarSector] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[LugarSector]") ;
                     cmdBuffer=" DROP FUNCTION [LugarSector] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [LugarSector] ([LugarId] smallint NOT NULL , [LugarSectorId] smallint NOT NULL , [LugarSectorName] nvarchar(40) NOT NULL , [LugarSectorCantidad] smallint NOT NULL , [LugarSectorPrecio] smallint NOT NULL , PRIMARY KEY([LugarId], [LugarSectorId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateInvitacion( )
      {
         string cmdBuffer = "";
         /* Indices for table Invitacion */
         try
         {
            cmdBuffer=" CREATE TABLE [Invitacion] ([InvitacionId] smallint NOT NULL IDENTITY(1,1), [InvitacionFecha] datetime NOT NULL , [InvitacionName] nvarchar(40) NULL , [LugarSectorId] smallint NOT NULL , [EspectaculoId] smallint NOT NULL , [EspectaculoFuncionId] smallint NOT NULL , PRIMARY KEY([InvitacionId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Invitacion]") ;
               cmdBuffer=" DROP TABLE [Invitacion] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Invitacion]") ;
                  cmdBuffer=" DROP VIEW [Invitacion] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Invitacion]") ;
                     cmdBuffer=" DROP FUNCTION [Invitacion] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Invitacion] ([InvitacionId] smallint NOT NULL IDENTITY(1,1), [InvitacionFecha] datetime NOT NULL , [InvitacionName] nvarchar(40) NULL , [LugarSectorId] smallint NOT NULL , [EspectaculoId] smallint NOT NULL , [EspectaculoFuncionId] smallint NOT NULL , PRIMARY KEY([InvitacionId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINVITACION1] ON [Invitacion] ([EspectaculoId] ,[LugarSectorId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IINVITACION1] ON [Invitacion] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINVITACION1] ON [Invitacion] ([EspectaculoId] ,[LugarSectorId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINVITACION2] ON [Invitacion] ([EspectaculoId] ,[EspectaculoFuncionId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IINVITACION2] ON [Invitacion] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IINVITACION2] ON [Invitacion] ([EspectaculoId] ,[EspectaculoFuncionId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateEntrada( )
      {
         string cmdBuffer = "";
         /* Indices for table Entrada */
         try
         {
            cmdBuffer=" CREATE TABLE [Entrada] ([EntradaId] smallint NOT NULL IDENTITY(1,1), [ClienteId] smallint NOT NULL , [LugarSectorId] smallint NOT NULL , [EntradaFecha] datetime NOT NULL , [EspectaculoId] smallint NOT NULL , [EspectaculoFuncionId] smallint NOT NULL , [EspectaculoPaisName] nvarchar(40) NOT NULL , PRIMARY KEY([EntradaId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Entrada]") ;
               cmdBuffer=" DROP TABLE [Entrada] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Entrada]") ;
                  cmdBuffer=" DROP VIEW [Entrada] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Entrada]") ;
                     cmdBuffer=" DROP FUNCTION [Entrada] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Entrada] ([EntradaId] smallint NOT NULL IDENTITY(1,1), [ClienteId] smallint NOT NULL , [LugarSectorId] smallint NOT NULL , [EntradaFecha] datetime NOT NULL , [EspectaculoId] smallint NOT NULL , [EspectaculoFuncionId] smallint NOT NULL , [EspectaculoPaisName] nvarchar(40) NOT NULL , PRIMARY KEY([EntradaId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IENTRADA2] ON [Entrada] ([ClienteId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IENTRADA2] ON [Entrada] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IENTRADA2] ON [Entrada] ([ClienteId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IENTRADA1] ON [Entrada] ([EspectaculoId] ,[LugarSectorId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IENTRADA1] ON [Entrada] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IENTRADA1] ON [Entrada] ([EspectaculoId] ,[LugarSectorId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IENTRADA3] ON [Entrada] ([EspectaculoId] ,[EspectaculoFuncionId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IENTRADA3] ON [Entrada] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IENTRADA3] ON [Entrada] ([EspectaculoId] ,[EspectaculoFuncionId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCliente( )
      {
         string cmdBuffer = "";
         /* Indices for table Cliente */
         try
         {
            cmdBuffer=" CREATE TABLE [Cliente] ([ClienteId] smallint NOT NULL IDENTITY(1,1), [ClienteName] nvarchar(40) NOT NULL , [PaisId] smallint NOT NULL , PRIMARY KEY([ClienteId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Cliente]") ;
               cmdBuffer=" DROP TABLE [Cliente] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Cliente]") ;
                  cmdBuffer=" DROP VIEW [Cliente] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Cliente]") ;
                     cmdBuffer=" DROP FUNCTION [Cliente] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Cliente] ([ClienteId] smallint NOT NULL IDENTITY(1,1), [ClienteName] nvarchar(40) NOT NULL , [PaisId] smallint NOT NULL , PRIMARY KEY([ClienteId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICLIENTE1] ON [Cliente] ([PaisId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICLIENTE1] ON [Cliente] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICLIENTE1] ON [Cliente] ([PaisId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [UCLIENTE] ON [Cliente] ([ClienteName] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [UCLIENTE] ON [Cliente] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [UCLIENTE] ON [Cliente] ([ClienteName] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateTipoEspectaculo( )
      {
         string cmdBuffer = "";
         /* Indices for table TipoEspectaculo */
         try
         {
            cmdBuffer=" CREATE TABLE [TipoEspectaculo] ([TipoEspectaculoId] smallint NOT NULL IDENTITY(1,1), [TipoEspectaculoName] nvarchar(40) NOT NULL , PRIMARY KEY([TipoEspectaculoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[TipoEspectaculo]") ;
               cmdBuffer=" DROP TABLE [TipoEspectaculo] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[TipoEspectaculo]") ;
                  cmdBuffer=" DROP VIEW [TipoEspectaculo] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[TipoEspectaculo]") ;
                     cmdBuffer=" DROP FUNCTION [TipoEspectaculo] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [TipoEspectaculo] ([TipoEspectaculoId] smallint NOT NULL IDENTITY(1,1), [TipoEspectaculoName] nvarchar(40) NOT NULL , PRIMARY KEY([TipoEspectaculoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [UTIPOESPECTACULO] ON [TipoEspectaculo] ([TipoEspectaculoName] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [UTIPOESPECTACULO] ON [TipoEspectaculo] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [UTIPOESPECTACULO] ON [TipoEspectaculo] ([TipoEspectaculoName] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreatePais( )
      {
         string cmdBuffer = "";
         /* Indices for table Pais */
         try
         {
            cmdBuffer=" CREATE TABLE [Pais] ([PaisId] smallint NOT NULL IDENTITY(1,1), [PaisName] nvarchar(40) NOT NULL , [PaisFlag] VARBINARY(MAX) NULL , [PaisFlag_GXI] varchar(2048) NULL , PRIMARY KEY([PaisId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Pais]") ;
               cmdBuffer=" DROP TABLE [Pais] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Pais]") ;
                  cmdBuffer=" DROP VIEW [Pais] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Pais]") ;
                     cmdBuffer=" DROP FUNCTION [Pais] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Pais] ([PaisId] smallint NOT NULL IDENTITY(1,1), [PaisName] nvarchar(40) NOT NULL , [PaisFlag] VARBINARY(MAX) NULL , [PaisFlag_GXI] varchar(2048) NULL , PRIMARY KEY([PaisId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [UPAIS] ON [Pais] ([PaisName] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [UPAIS] ON [Pais] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [UPAIS] ON [Pais] ([PaisName] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateLugar( )
      {
         string cmdBuffer = "";
         /* Indices for table Lugar */
         try
         {
            cmdBuffer=" CREATE TABLE [Lugar] ([LugarId] smallint NOT NULL IDENTITY(1,1), [LugarName] nvarchar(40) NOT NULL , [PaisId] smallint NOT NULL , PRIMARY KEY([LugarId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Lugar]") ;
               cmdBuffer=" DROP TABLE [Lugar] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Lugar]") ;
                  cmdBuffer=" DROP VIEW [Lugar] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Lugar]") ;
                     cmdBuffer=" DROP FUNCTION [Lugar] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Lugar] ([LugarId] smallint NOT NULL IDENTITY(1,1), [LugarName] nvarchar(40) NOT NULL , [PaisId] smallint NOT NULL , PRIMARY KEY([LugarId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ILUGAR1] ON [Lugar] ([PaisId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ILUGAR1] ON [Lugar] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ILUGAR1] ON [Lugar] ([PaisId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ULUGAR] ON [Lugar] ([LugarName] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ULUGAR] ON [Lugar] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ULUGAR] ON [Lugar] ([LugarName] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RILugarPais( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Lugar] ADD CONSTRAINT [ILUGAR1] FOREIGN KEY ([PaisId]) REFERENCES [Pais] ([PaisId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Lugar] DROP CONSTRAINT [ILUGAR1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Lugar] ADD CONSTRAINT [ILUGAR1] FOREIGN KEY ([PaisId]) REFERENCES [Pais] ([PaisId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClientePais( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Cliente] ADD CONSTRAINT [ICLIENTE1] FOREIGN KEY ([PaisId]) REFERENCES [Pais] ([PaisId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Cliente] DROP CONSTRAINT [ICLIENTE1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Cliente] ADD CONSTRAINT [ICLIENTE1] FOREIGN KEY ([PaisId]) REFERENCES [Pais] ([PaisId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEntradaCliente( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Entrada] ADD CONSTRAINT [IENTRADA2] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([ClienteId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Entrada] DROP CONSTRAINT [IENTRADA2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Entrada] ADD CONSTRAINT [IENTRADA2] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([ClienteId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEntradaEspectaculoLugarSector( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Entrada] ADD CONSTRAINT [IENTRADA1] FOREIGN KEY ([EspectaculoId], [LugarSectorId]) REFERENCES [EspectaculoLugarSector] ([EspectaculoId], [LugarSectorId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Entrada] DROP CONSTRAINT [IENTRADA1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Entrada] ADD CONSTRAINT [IENTRADA1] FOREIGN KEY ([EspectaculoId], [LugarSectorId]) REFERENCES [EspectaculoLugarSector] ([EspectaculoId], [LugarSectorId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEntradaEspectaculoFuncion( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Entrada] ADD CONSTRAINT [IENTRADA3] FOREIGN KEY ([EspectaculoId], [EspectaculoFuncionId]) REFERENCES [EspectaculoFuncion] ([EspectaculoId], [EspectaculoFuncionId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Entrada] DROP CONSTRAINT [IENTRADA3] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Entrada] ADD CONSTRAINT [IENTRADA3] FOREIGN KEY ([EspectaculoId], [EspectaculoFuncionId]) REFERENCES [EspectaculoFuncion] ([EspectaculoId], [EspectaculoFuncionId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIInvitacionEspectaculoLugarSector( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Invitacion] ADD CONSTRAINT [IINVITACION1] FOREIGN KEY ([EspectaculoId], [LugarSectorId]) REFERENCES [EspectaculoLugarSector] ([EspectaculoId], [LugarSectorId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Invitacion] DROP CONSTRAINT [IINVITACION1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Invitacion] ADD CONSTRAINT [IINVITACION1] FOREIGN KEY ([EspectaculoId], [LugarSectorId]) REFERENCES [EspectaculoLugarSector] ([EspectaculoId], [LugarSectorId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIInvitacionEspectaculoFuncion( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Invitacion] ADD CONSTRAINT [IINVITACION2] FOREIGN KEY ([EspectaculoId], [EspectaculoFuncionId]) REFERENCES [EspectaculoFuncion] ([EspectaculoId], [EspectaculoFuncionId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Invitacion] DROP CONSTRAINT [IINVITACION2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Invitacion] ADD CONSTRAINT [IINVITACION2] FOREIGN KEY ([EspectaculoId], [EspectaculoFuncionId]) REFERENCES [EspectaculoFuncion] ([EspectaculoId], [EspectaculoFuncionId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RILugarSectorLugar( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [LugarSector] ADD CONSTRAINT [ILUGARSECTOR1] FOREIGN KEY ([LugarId]) REFERENCES [Lugar] ([LugarId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [LugarSector] DROP CONSTRAINT [ILUGARSECTOR1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [LugarSector] ADD CONSTRAINT [ILUGARSECTOR1] FOREIGN KEY ([LugarId]) REFERENCES [Lugar] ([LugarId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEspectaculoLugar( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Espectaculo] ADD CONSTRAINT [IESPECTACULO2] FOREIGN KEY ([LugarId]) REFERENCES [Lugar] ([LugarId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Espectaculo] DROP CONSTRAINT [IESPECTACULO2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Espectaculo] ADD CONSTRAINT [IESPECTACULO2] FOREIGN KEY ([LugarId]) REFERENCES [Lugar] ([LugarId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEspectaculoTipoEspectaculo( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Espectaculo] ADD CONSTRAINT [IESPECTACULO1] FOREIGN KEY ([TipoEspectaculoId]) REFERENCES [TipoEspectaculo] ([TipoEspectaculoId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Espectaculo] DROP CONSTRAINT [IESPECTACULO1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Espectaculo] ADD CONSTRAINT [IESPECTACULO1] FOREIGN KEY ([TipoEspectaculoId]) REFERENCES [TipoEspectaculo] ([TipoEspectaculoId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEspectaculoLugarSectorEspectaculo( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [EspectaculoLugarSector] ADD CONSTRAINT [IESPECTACULOLUGARSECTOR1] FOREIGN KEY ([EspectaculoId]) REFERENCES [Espectaculo] ([EspectaculoId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [EspectaculoLugarSector] DROP CONSTRAINT [IESPECTACULOLUGARSECTOR1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [EspectaculoLugarSector] ADD CONSTRAINT [IESPECTACULOLUGARSECTOR1] FOREIGN KEY ([EspectaculoId]) REFERENCES [Espectaculo] ([EspectaculoId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIEspectaculoFuncionEspectaculo( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [EspectaculoFuncion] ADD CONSTRAINT [IESPECTACULOFUNCION1] FOREIGN KEY ([EspectaculoId]) REFERENCES [Espectaculo] ([EspectaculoId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [EspectaculoFuncion] DROP CONSTRAINT [IESPECTACULOFUNCION1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [EspectaculoFuncion] ADD CONSTRAINT [IESPECTACULOFUNCION1] FOREIGN KEY ([EspectaculoId]) REFERENCES [Espectaculo] ([EspectaculoId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      private void TablesCount( )
      {
      }

      private bool PreviousCheck( )
      {
         if ( ! IsResumeMode( ) )
         {
            if ( GXUtil.DbmsVersion( context, "DEFAULT") < 10 )
            {
               SetCheckError ( GXResourceManager.GetMessage("GXM_bad_DBMS_version", new   object[]  {"2012"}) ) ;
               return false ;
            }
         }
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         if ( GXUtil.IsSQLSERVER2005( context, "DEFAULT") )
         {
            /* Using cursor P00012 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               sSchemaVar = P00012_AsSchemaVar[0];
               nsSchemaVar = P00012_nsSchemaVar[0];
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else
         {
            /* Using cursor P00023 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               sSchemaVar = P00023_AsSchemaVar[0];
               nsSchemaVar = P00023_nsSchemaVar[0];
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         return true ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "CreateEspectaculoFuncion" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "CreateEspectaculoLugarSector" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "CreateEspectaculo" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "CreateLugarSector" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 5 ,  "CreateInvitacion" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 6 ,  "CreateEntrada" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 7 ,  "CreateCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 8 ,  "CreateTipoEspectaculo" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 9 ,  "CreatePais" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 10 ,  "CreateLugar" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 11 ,  "RILugarPais" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 12 ,  "RIClientePais" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 13 ,  "RIEntradaCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 14 ,  "RIEntradaEspectaculoLugarSector" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 15 ,  "RIEntradaEspectaculoFuncion" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 16 ,  "RIInvitacionEspectaculoLugarSector" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 17 ,  "RIInvitacionEspectaculoFuncion" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 18 ,  "RILugarSectorLugar" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 19 ,  "RIEspectaculoLugar" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 20 ,  "RIEspectaculoTipoEspectaculo" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 21 ,  "RIEspectaculoLugarSectorEspectaculo" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 22 ,  "RIEspectaculoFuncionEspectaculo" , new Object[]{ });
      }

      private void ExecuteTablesReorganization( )
      {
         ExecuteOnlyTablesReorganization( ) ;
         ExecuteOnlyRisReorganization( ) ;
         ReorgExecute.SubmitAll() ;
      }

      private void SetPrecedence( )
      {
         SetPrecedencetables( ) ;
         SetPrecedenceris( ) ;
      }

      private void SetPrecedencetables( )
      {
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"EspectaculoFuncion", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateEspectaculoFuncion" ,  "CreateEspectaculo" );
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"EspectaculoLugarSector", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateEspectaculoLugarSector" ,  "CreateEspectaculo" );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Espectaculo", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateEspectaculo" ,  "CreateLugar" );
         ReorgExecute.RegisterPrecedence( "CreateEspectaculo" ,  "CreateTipoEspectaculo" );
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"LugarSector", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateLugarSector" ,  "CreateLugar" );
         GXReorganization.SetMsg( 5 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Invitacion", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateInvitacion" ,  "CreateEspectaculoLugarSector" );
         ReorgExecute.RegisterPrecedence( "CreateInvitacion" ,  "CreateEspectaculoFuncion" );
         GXReorganization.SetMsg( 6 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Entrada", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateEntrada" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "CreateEntrada" ,  "CreateEspectaculoLugarSector" );
         ReorgExecute.RegisterPrecedence( "CreateEntrada" ,  "CreateEspectaculoFuncion" );
         GXReorganization.SetMsg( 7 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Cliente", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCliente" ,  "CreatePais" );
         GXReorganization.SetMsg( 8 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"TipoEspectaculo", ""}) );
         GXReorganization.SetMsg( 9 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Pais", ""}) );
         GXReorganization.SetMsg( 10 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Lugar", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateLugar" ,  "CreatePais" );
      }

      private void SetPrecedenceris( )
      {
         GXReorganization.SetMsg( 11 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ILUGAR1]"}) );
         ReorgExecute.RegisterPrecedence( "RILugarPais" ,  "CreateLugar" );
         ReorgExecute.RegisterPrecedence( "RILugarPais" ,  "CreatePais" );
         GXReorganization.SetMsg( 12 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICLIENTE1]"}) );
         ReorgExecute.RegisterPrecedence( "RIClientePais" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "RIClientePais" ,  "CreatePais" );
         GXReorganization.SetMsg( 13 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IENTRADA2]"}) );
         ReorgExecute.RegisterPrecedence( "RIEntradaCliente" ,  "CreateEntrada" );
         ReorgExecute.RegisterPrecedence( "RIEntradaCliente" ,  "CreateCliente" );
         GXReorganization.SetMsg( 14 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IENTRADA1]"}) );
         ReorgExecute.RegisterPrecedence( "RIEntradaEspectaculoLugarSector" ,  "CreateEntrada" );
         ReorgExecute.RegisterPrecedence( "RIEntradaEspectaculoLugarSector" ,  "CreateEspectaculoLugarSector" );
         GXReorganization.SetMsg( 15 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IENTRADA3]"}) );
         ReorgExecute.RegisterPrecedence( "RIEntradaEspectaculoFuncion" ,  "CreateEntrada" );
         ReorgExecute.RegisterPrecedence( "RIEntradaEspectaculoFuncion" ,  "CreateEspectaculoFuncion" );
         GXReorganization.SetMsg( 16 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IINVITACION1]"}) );
         ReorgExecute.RegisterPrecedence( "RIInvitacionEspectaculoLugarSector" ,  "CreateInvitacion" );
         ReorgExecute.RegisterPrecedence( "RIInvitacionEspectaculoLugarSector" ,  "CreateEspectaculoLugarSector" );
         GXReorganization.SetMsg( 17 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IINVITACION2]"}) );
         ReorgExecute.RegisterPrecedence( "RIInvitacionEspectaculoFuncion" ,  "CreateInvitacion" );
         ReorgExecute.RegisterPrecedence( "RIInvitacionEspectaculoFuncion" ,  "CreateEspectaculoFuncion" );
         GXReorganization.SetMsg( 18 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ILUGARSECTOR1]"}) );
         ReorgExecute.RegisterPrecedence( "RILugarSectorLugar" ,  "CreateLugarSector" );
         ReorgExecute.RegisterPrecedence( "RILugarSectorLugar" ,  "CreateLugar" );
         GXReorganization.SetMsg( 19 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IESPECTACULO2]"}) );
         ReorgExecute.RegisterPrecedence( "RIEspectaculoLugar" ,  "CreateEspectaculo" );
         ReorgExecute.RegisterPrecedence( "RIEspectaculoLugar" ,  "CreateLugar" );
         GXReorganization.SetMsg( 20 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IESPECTACULO1]"}) );
         ReorgExecute.RegisterPrecedence( "RIEspectaculoTipoEspectaculo" ,  "CreateEspectaculo" );
         ReorgExecute.RegisterPrecedence( "RIEspectaculoTipoEspectaculo" ,  "CreateTipoEspectaculo" );
         GXReorganization.SetMsg( 21 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IESPECTACULOLUGARSECTOR1]"}) );
         ReorgExecute.RegisterPrecedence( "RIEspectaculoLugarSectorEspectaculo" ,  "CreateEspectaculoLugarSector" );
         ReorgExecute.RegisterPrecedence( "RIEspectaculoLugarSectorEspectaculo" ,  "CreateEspectaculo" );
         GXReorganization.SetMsg( 22 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IESPECTACULOFUNCION1]"}) );
         ReorgExecute.RegisterPrecedence( "RIEspectaculoFuncionEspectaculo" ,  "CreateEspectaculoFuncion" );
         ReorgExecute.RegisterPrecedence( "RIEspectaculoFuncionEspectaculo" ,  "CreateEspectaculo" );
      }

      private void ExecuteReorganization( )
      {
         if ( ErrCode == 0 )
         {
            TablesCount( ) ;
            if ( ! PrintOnlyRecordCount( ) )
            {
               FirstActions( ) ;
               SetPrecedence( ) ;
               ExecuteTablesReorganization( ) ;
            }
         }
      }

      [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.Synchronized)]
      public void DropTableConstraints( string sTableName )
      {
         string cmdBuffer;
         /* Using cursor P00034 */
         pr_default.execute(2, new Object[] {sTableName});
         while ( (pr_default.getStatus(2) != 101) )
         {
            constid = P00034_Aconstid[0];
            nconstid = P00034_nconstid[0];
            fkeyid = P00034_Afkeyid[0];
            nfkeyid = P00034_nfkeyid[0];
            rkeyid = P00034_Arkeyid[0];
            nrkeyid = P00034_nrkeyid[0];
            cmdBuffer = "ALTER TABLE " + "[" + fkeyid + "] DROP CONSTRAINT " + constid;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      public void UtilsCleanup( )
      {
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         DS = new GxDataStore();
         ErrMsg = "";
         DataBaseName = "";
         defaultUsers = new GeneXus.Utils.GxStringCollection();
         defaultUser = "";
         sSchemaVar = "";
         nsSchemaVar = false;
         scmdbuf = "";
         P00012_AsSchemaVar = new string[] {""} ;
         P00012_nsSchemaVar = new bool[] {false} ;
         P00023_AsSchemaVar = new string[] {""} ;
         P00023_nsSchemaVar = new bool[] {false} ;
         sTableName = "";
         constid = "";
         nconstid = false;
         fkeyid = "";
         nfkeyid = false;
         P00034_Aconstid = new string[] {""} ;
         P00034_nconstid = new bool[] {false} ;
         P00034_Afkeyid = new string[] {""} ;
         P00034_nfkeyid = new bool[] {false} ;
         P00034_Arkeyid = new int[1] ;
         P00034_nrkeyid = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_AsSchemaVar
               }
               , new Object[] {
               P00023_AsSchemaVar
               }
               , new Object[] {
               P00034_Aconstid, P00034_Afkeyid, P00034_Arkeyid
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected short Count ;
      protected short Res ;
      protected short setupDB ;
      protected int rkeyid ;
      protected string ErrMsg ;
      protected string DataBaseName ;
      protected string cmdBuffer ;
      protected string defaultUser ;
      protected string sSchemaVar ;
      protected string scmdbuf ;
      protected string sTableName ;
      protected bool nsSchemaVar ;
      protected bool nconstid ;
      protected bool nfkeyid ;
      protected bool nrkeyid ;
      protected string constid ;
      protected string fkeyid ;
      protected GeneXus.Utils.GxStringCollection defaultUsers ;
      protected GxDataStore DS ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected string[] P00012_AsSchemaVar ;
      protected bool[] P00012_nsSchemaVar ;
      protected string[] P00023_AsSchemaVar ;
      protected bool[] P00023_nsSchemaVar ;
      protected string[] P00034_Aconstid ;
      protected bool[] P00034_nconstid ;
      protected string[] P00034_Afkeyid ;
      protected bool[] P00034_nfkeyid ;
      protected int[] P00034_Arkeyid ;
      protected bool[] P00034_nrkeyid ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00012;
          prmP00012 = new Object[] {
          };
          Object[] prmP00023;
          prmP00023 = new Object[] {
          };
          Object[] prmP00034;
          prmP00034 = new Object[] {
          new ParDef("@sTableName",GXType.Char,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT SCHEMA_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT USER_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00034", "SELECT OBJECT_NAME(object_id), OBJECT_NAME(parent_object_id), referenced_object_id FROM sys.foreign_keys WHERE referenced_object_id = OBJECT_ID(RTRIM(LTRIM(@sTableName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00034,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
