using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class lugar_bc : GXHttpHandler, IGxSilentTrn
   {
      public lugar_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public lugar_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow022( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey022( ) ;
         standaloneModal( ) ;
         AddRow022( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z4LugarId = A4LugarId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               if ( AnyError == 0 )
               {
                  ZM022( 2) ;
               }
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode2 = Gx_mode;
            CONFIRM_0211( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode2;
               IsConfirmed = 1;
            }
            /* Restore parent mode. */
            Gx_mode = sMode2;
         }
      }

      protected void CONFIRM_0211( )
      {
         nGXsfl_11_idx = 0;
         while ( nGXsfl_11_idx < bcLugar.gxTpr_Sector.Count )
         {
            ReadRow0211( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound11 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_11 != 0 ) )
            {
               GetKey0211( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound11 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0211( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0211( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0211( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound11 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0211( ) ;
                        Load0211( ) ;
                        BeforeValidate0211( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0211( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_11 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0211( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0211( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0211( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow11( ((SdtLugar_Sector)bcLugar.gxTpr_Sector.Item(nGXsfl_11_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E12022( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11022( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z5LugarName = A5LugarName;
            Z3PaisId = A3PaisId;
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z6PaisName = A6PaisName;
         }
         if ( GX_JID == -1 )
         {
            Z4LugarId = A4LugarId;
            Z5LugarName = A5LugarName;
            Z3PaisId = A3PaisId;
            Z6PaisName = A6PaisName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load022( )
      {
         /* Using cursor BC00027 */
         pr_default.execute(5, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound2 = 1;
            A5LugarName = BC00027_A5LugarName[0];
            A6PaisName = BC00027_A6PaisName[0];
            A3PaisId = BC00027_A3PaisId[0];
            ZM022( -1) ;
         }
         pr_default.close(5);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00026 */
         pr_default.execute(4, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = BC00026_A6PaisName[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey022( )
      {
         /* Using cursor BC00028 */
         pr_default.execute(6, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00025 */
         pr_default.execute(3, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM022( 1) ;
            RcdFound2 = 1;
            A4LugarId = BC00025_A4LugarId[0];
            A5LugarName = BC00025_A5LugarName[0];
            A3PaisId = BC00025_A3PaisId[0];
            Z4LugarId = A4LugarId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode2;
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_020( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00024 */
            pr_default.execute(2, new Object[] {A4LugarId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Lugar"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z5LugarName, BC00024_A5LugarName[0]) != 0 ) || ( Z3PaisId != BC00024_A3PaisId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Lugar"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00029 */
                     pr_default.execute(7, new Object[] {A5LugarName, A3PaisId});
                     A4LugarId = BC00029_A4LugarId[0];
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Lugar");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel022( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000210 */
                     pr_default.execute(8, new Object[] {A5LugarName, A3PaisId, A4LugarId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Lugar");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Lugar"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel022( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0211( ) ;
                  while ( RcdFound11 != 0 )
                  {
                     getByPrimaryKey0211( ) ;
                     Delete0211( ) ;
                     ScanKeyNext0211( ) ;
                  }
                  ScanKeyEnd0211( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000211 */
                     pr_default.execute(9, new Object[] {A4LugarId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Lugar");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                           endTrnMsgCod = "SuccessfullyDeleted";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel022( ) ;
         Gx_mode = sMode2;
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000212 */
            pr_default.execute(10, new Object[] {A3PaisId});
            A6PaisName = BC000212_A6PaisName[0];
            pr_default.close(10);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000213 */
            pr_default.execute(11, new Object[] {A4LugarId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Espectaculo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void ProcessNestedLevel0211( )
      {
         nGXsfl_11_idx = 0;
         while ( nGXsfl_11_idx < bcLugar.gxTpr_Sector.Count )
         {
            ReadRow0211( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound11 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_11 != 0 ) )
            {
               standaloneNotModal0211( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0211( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0211( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0211( ) ;
                  }
               }
            }
            KeyVarsToRow11( ((SdtLugar_Sector)bcLugar.gxTpr_Sector.Item(nGXsfl_11_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_11_idx = 0;
            while ( nGXsfl_11_idx < bcLugar.gxTpr_Sector.Count )
            {
               ReadRow0211( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound11 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcLugar.gxTpr_Sector.RemoveElement(nGXsfl_11_idx);
                  nGXsfl_11_idx = (int)(nGXsfl_11_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0211( ) ;
                  VarsToRow11( ((SdtLugar_Sector)bcLugar.gxTpr_Sector.Item(nGXsfl_11_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0211( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_11 = 0;
         nIsMod_11 = 0;
         Gxremove11 = 0;
      }

      protected void ProcessLevel022( )
      {
         /* Save parent mode. */
         sMode2 = Gx_mode;
         ProcessNestedLevel0211( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode2;
         /* ' Update level parameters */
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart022( )
      {
         /* Scan By routine */
         /* Using cursor BC000214 */
         pr_default.execute(12, new Object[] {A4LugarId});
         RcdFound2 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound2 = 1;
            A4LugarId = BC000214_A4LugarId[0];
            A5LugarName = BC000214_A5LugarName[0];
            A6PaisName = BC000214_A6PaisName[0];
            A3PaisId = BC000214_A3PaisId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound2 = 0;
         ScanKeyLoad022( ) ;
      }

      protected void ScanKeyLoad022( )
      {
         sMode2 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound2 = 1;
            A4LugarId = BC000214_A4LugarId[0];
            A5LugarName = BC000214_A5LugarName[0];
            A6PaisName = BC000214_A6PaisName[0];
            A3PaisId = BC000214_A3PaisId[0];
         }
         Gx_mode = sMode2;
      }

      protected void ScanKeyEnd022( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
      }

      protected void ZM0211( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z28LugarSectorName = A28LugarSectorName;
            Z29LugarSectorCantidad = A29LugarSectorCantidad;
            Z30LugarSectorPrecio = A30LugarSectorPrecio;
         }
         if ( GX_JID == -3 )
         {
            Z4LugarId = A4LugarId;
            Z27LugarSectorId = A27LugarSectorId;
            Z28LugarSectorName = A28LugarSectorName;
            Z29LugarSectorCantidad = A29LugarSectorCantidad;
            Z30LugarSectorPrecio = A30LugarSectorPrecio;
         }
      }

      protected void standaloneNotModal0211( )
      {
      }

      protected void standaloneModal0211( )
      {
      }

      protected void Load0211( )
      {
         /* Using cursor BC000215 */
         pr_default.execute(13, new Object[] {A4LugarId, A27LugarSectorId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound11 = 1;
            A28LugarSectorName = BC000215_A28LugarSectorName[0];
            A29LugarSectorCantidad = BC000215_A29LugarSectorCantidad[0];
            A30LugarSectorPrecio = BC000215_A30LugarSectorPrecio[0];
            ZM0211( -3) ;
         }
         pr_default.close(13);
         OnLoadActions0211( ) ;
      }

      protected void OnLoadActions0211( )
      {
      }

      protected void CheckExtendedTable0211( )
      {
         nIsDirty_11 = 0;
         Gx_BScreen = 1;
         standaloneModal0211( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors0211( )
      {
      }

      protected void enableDisable0211( )
      {
      }

      protected void GetKey0211( )
      {
         /* Using cursor BC000216 */
         pr_default.execute(14, new Object[] {A4LugarId, A27LugarSectorId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey0211( )
      {
         /* Using cursor BC00023 */
         pr_default.execute(1, new Object[] {A4LugarId, A27LugarSectorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0211( 3) ;
            RcdFound11 = 1;
            InitializeNonKey0211( ) ;
            A27LugarSectorId = BC00023_A27LugarSectorId[0];
            A28LugarSectorName = BC00023_A28LugarSectorName[0];
            A29LugarSectorCantidad = BC00023_A29LugarSectorCantidad[0];
            A30LugarSectorPrecio = BC00023_A30LugarSectorPrecio[0];
            Z4LugarId = A4LugarId;
            Z27LugarSectorId = A27LugarSectorId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0211( ) ;
            Load0211( ) ;
            Gx_mode = sMode11;
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0211( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0211( ) ;
            Gx_mode = sMode11;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0211( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0211( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00022 */
            pr_default.execute(0, new Object[] {A4LugarId, A27LugarSectorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LugarSector"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z28LugarSectorName, BC00022_A28LugarSectorName[0]) != 0 ) || ( Z29LugarSectorCantidad != BC00022_A29LugarSectorCantidad[0] ) || ( Z30LugarSectorPrecio != BC00022_A30LugarSectorPrecio[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"LugarSector"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0211( )
      {
         BeforeValidate0211( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0211( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0211( 0) ;
            CheckOptimisticConcurrency0211( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0211( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0211( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000217 */
                     pr_default.execute(15, new Object[] {A4LugarId, A27LugarSectorId, A28LugarSectorName, A29LugarSectorCantidad, A30LugarSectorPrecio});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("LugarSector");
                     if ( (pr_default.getStatus(15) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0211( ) ;
            }
            EndLevel0211( ) ;
         }
         CloseExtendedTableCursors0211( ) ;
      }

      protected void Update0211( )
      {
         BeforeValidate0211( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0211( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0211( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0211( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0211( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000218 */
                     pr_default.execute(16, new Object[] {A28LugarSectorName, A29LugarSectorCantidad, A30LugarSectorPrecio, A4LugarId, A27LugarSectorId});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("LugarSector");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LugarSector"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0211( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0211( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0211( ) ;
         }
         CloseExtendedTableCursors0211( ) ;
      }

      protected void DeferredUpdate0211( )
      {
      }

      protected void Delete0211( )
      {
         Gx_mode = "DLT";
         BeforeValidate0211( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0211( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0211( ) ;
            AfterConfirm0211( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0211( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000219 */
                  pr_default.execute(17, new Object[] {A4LugarId, A27LugarSectorId});
                  pr_default.close(17);
                  dsDefault.SmartCacheProvider.SetUpdated("LugarSector");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0211( ) ;
         Gx_mode = sMode11;
      }

      protected void OnDeleteControls0211( )
      {
         standaloneModal0211( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0211( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0211( )
      {
         /* Scan By routine */
         /* Using cursor BC000220 */
         pr_default.execute(18, new Object[] {A4LugarId});
         RcdFound11 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound11 = 1;
            A27LugarSectorId = BC000220_A27LugarSectorId[0];
            A28LugarSectorName = BC000220_A28LugarSectorName[0];
            A29LugarSectorCantidad = BC000220_A29LugarSectorCantidad[0];
            A30LugarSectorPrecio = BC000220_A30LugarSectorPrecio[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0211( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound11 = 0;
         ScanKeyLoad0211( ) ;
      }

      protected void ScanKeyLoad0211( )
      {
         sMode11 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound11 = 1;
            A27LugarSectorId = BC000220_A27LugarSectorId[0];
            A28LugarSectorName = BC000220_A28LugarSectorName[0];
            A29LugarSectorCantidad = BC000220_A29LugarSectorCantidad[0];
            A30LugarSectorPrecio = BC000220_A30LugarSectorPrecio[0];
         }
         Gx_mode = sMode11;
      }

      protected void ScanKeyEnd0211( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0211( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0211( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0211( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0211( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0211( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0211( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0211( )
      {
      }

      protected void send_integrity_lvl_hashes0211( )
      {
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void AddRow022( )
      {
         VarsToRow2( bcLugar) ;
      }

      protected void ReadRow022( )
      {
         RowToVars2( bcLugar, 1) ;
      }

      protected void AddRow0211( )
      {
         SdtLugar_Sector obj11;
         obj11 = new SdtLugar_Sector(context);
         VarsToRow11( obj11) ;
         bcLugar.gxTpr_Sector.Add(obj11, 0);
         obj11.gxTpr_Mode = "UPD";
         obj11.gxTpr_Modified = 0;
      }

      protected void ReadRow0211( )
      {
         nGXsfl_11_idx = (int)(nGXsfl_11_idx+1);
         RowToVars11( ((SdtLugar_Sector)bcLugar.gxTpr_Sector.Item(nGXsfl_11_idx)), 1) ;
      }

      protected void InitializeNonKey022( )
      {
         A5LugarName = "";
         A3PaisId = 0;
         A6PaisName = "";
         Z5LugarName = "";
         Z3PaisId = 0;
      }

      protected void InitAll022( )
      {
         A4LugarId = 0;
         InitializeNonKey022( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0211( )
      {
         A28LugarSectorName = "";
         A29LugarSectorCantidad = 0;
         A30LugarSectorPrecio = 0;
         Z28LugarSectorName = "";
         Z29LugarSectorCantidad = 0;
         Z30LugarSectorPrecio = 0;
      }

      protected void InitAll0211( )
      {
         A27LugarSectorId = 0;
         InitializeNonKey0211( ) ;
      }

      protected void StandaloneModalInsert0211( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow2( SdtLugar obj2 )
      {
         obj2.gxTpr_Mode = Gx_mode;
         obj2.gxTpr_Lugarname = A5LugarName;
         obj2.gxTpr_Paisid = A3PaisId;
         obj2.gxTpr_Paisname = A6PaisName;
         obj2.gxTpr_Lugarid = A4LugarId;
         obj2.gxTpr_Lugarid_Z = Z4LugarId;
         obj2.gxTpr_Lugarname_Z = Z5LugarName;
         obj2.gxTpr_Paisid_Z = Z3PaisId;
         obj2.gxTpr_Paisname_Z = Z6PaisName;
         obj2.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow2( SdtLugar obj2 )
      {
         obj2.gxTpr_Lugarid = A4LugarId;
         return  ;
      }

      public void RowToVars2( SdtLugar obj2 ,
                              int forceLoad )
      {
         Gx_mode = obj2.gxTpr_Mode;
         A5LugarName = obj2.gxTpr_Lugarname;
         A3PaisId = obj2.gxTpr_Paisid;
         A6PaisName = obj2.gxTpr_Paisname;
         A4LugarId = obj2.gxTpr_Lugarid;
         Z4LugarId = obj2.gxTpr_Lugarid_Z;
         Z5LugarName = obj2.gxTpr_Lugarname_Z;
         Z3PaisId = obj2.gxTpr_Paisid_Z;
         Z6PaisName = obj2.gxTpr_Paisname_Z;
         Gx_mode = obj2.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow11( SdtLugar_Sector obj11 )
      {
         obj11.gxTpr_Mode = Gx_mode;
         obj11.gxTpr_Lugarsectorname = A28LugarSectorName;
         obj11.gxTpr_Lugarsectorcantidad = A29LugarSectorCantidad;
         obj11.gxTpr_Lugarsectorprecio = A30LugarSectorPrecio;
         obj11.gxTpr_Lugarsectorid = A27LugarSectorId;
         obj11.gxTpr_Lugarsectorid_Z = Z27LugarSectorId;
         obj11.gxTpr_Lugarsectorname_Z = Z28LugarSectorName;
         obj11.gxTpr_Lugarsectorcantidad_Z = Z29LugarSectorCantidad;
         obj11.gxTpr_Lugarsectorprecio_Z = Z30LugarSectorPrecio;
         obj11.gxTpr_Modified = nIsMod_11;
         return  ;
      }

      public void KeyVarsToRow11( SdtLugar_Sector obj11 )
      {
         obj11.gxTpr_Lugarsectorid = A27LugarSectorId;
         return  ;
      }

      public void RowToVars11( SdtLugar_Sector obj11 ,
                               int forceLoad )
      {
         Gx_mode = obj11.gxTpr_Mode;
         A28LugarSectorName = obj11.gxTpr_Lugarsectorname;
         A29LugarSectorCantidad = obj11.gxTpr_Lugarsectorcantidad;
         A30LugarSectorPrecio = obj11.gxTpr_Lugarsectorprecio;
         A27LugarSectorId = obj11.gxTpr_Lugarsectorid;
         Z27LugarSectorId = obj11.gxTpr_Lugarsectorid_Z;
         Z28LugarSectorName = obj11.gxTpr_Lugarsectorname_Z;
         Z29LugarSectorCantidad = obj11.gxTpr_Lugarsectorcantidad_Z;
         Z30LugarSectorPrecio = obj11.gxTpr_Lugarsectorprecio_Z;
         nIsMod_11 = obj11.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A4LugarId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey022( ) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z4LugarId = A4LugarId;
         }
         ZM022( -1) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         bcLugar.gxTpr_Sector.ClearCollection();
         if ( RcdFound2 == 1 )
         {
            ScanKeyStart0211( ) ;
            nGXsfl_11_idx = 1;
            while ( RcdFound11 != 0 )
            {
               Z4LugarId = A4LugarId;
               Z27LugarSectorId = A27LugarSectorId;
               ZM0211( -3) ;
               OnLoadActions0211( ) ;
               nRcdExists_11 = 1;
               nIsMod_11 = 0;
               AddRow0211( ) ;
               nGXsfl_11_idx = (int)(nGXsfl_11_idx+1);
               ScanKeyNext0211( ) ;
            }
            ScanKeyEnd0211( ) ;
         }
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars2( bcLugar, 0) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z4LugarId = A4LugarId;
         }
         ZM022( -1) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         bcLugar.gxTpr_Sector.ClearCollection();
         if ( RcdFound2 == 1 )
         {
            ScanKeyStart0211( ) ;
            nGXsfl_11_idx = 1;
            while ( RcdFound11 != 0 )
            {
               Z4LugarId = A4LugarId;
               Z27LugarSectorId = A27LugarSectorId;
               ZM0211( -3) ;
               OnLoadActions0211( ) ;
               nRcdExists_11 = 1;
               nIsMod_11 = 0;
               AddRow0211( ) ;
               nGXsfl_11_idx = (int)(nGXsfl_11_idx+1);
               ScanKeyNext0211( ) ;
            }
            ScanKeyEnd0211( ) ;
         }
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert022( ) ;
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A4LugarId != Z4LugarId )
               {
                  A4LugarId = Z4LugarId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update022( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A4LugarId != Z4LugarId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert022( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert022( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars2( bcLugar, 1) ;
         SaveImpl( ) ;
         VarsToRow2( bcLugar) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars2( bcLugar, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
         AfterTrn( ) ;
         VarsToRow2( bcLugar) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
         }
         else
         {
            SdtLugar auxBC = new SdtLugar(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A4LugarId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcLugar);
               auxBC.Save();
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars2( bcLugar, 1) ;
         UpdateImpl( ) ;
         VarsToRow2( bcLugar) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars2( bcLugar, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
         }
         else
         {
            AfterTrn( ) ;
         }
         VarsToRow2( bcLugar) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars2( bcLugar, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey022( ) ;
         if ( RcdFound2 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A4LugarId != Z4LugarId )
            {
               A4LugarId = Z4LugarId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A4LugarId != Z4LugarId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(3);
         pr_default.close(1);
         pr_default.close(10);
         context.RollbackDataStores("lugar_bc",pr_default);
         VarsToRow2( bcLugar) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcLugar.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcLugar.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcLugar )
         {
            bcLugar = (SdtLugar)(sdt);
            if ( StringUtil.StrCmp(bcLugar.gxTpr_Mode, "") == 0 )
            {
               bcLugar.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow2( bcLugar) ;
            }
            else
            {
               RowToVars2( bcLugar, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcLugar.gxTpr_Mode, "") == 0 )
            {
               bcLugar.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars2( bcLugar, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtLugar Lugar_BC
      {
         get {
            return bcLugar ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected override void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(3);
         pr_default.close(10);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode2 = "";
         Z5LugarName = "";
         A5LugarName = "";
         Z6PaisName = "";
         A6PaisName = "";
         BC00027_A4LugarId = new short[1] ;
         BC00027_A5LugarName = new string[] {""} ;
         BC00027_A6PaisName = new string[] {""} ;
         BC00027_A3PaisId = new short[1] ;
         BC00026_A6PaisName = new string[] {""} ;
         BC00028_A4LugarId = new short[1] ;
         BC00025_A4LugarId = new short[1] ;
         BC00025_A5LugarName = new string[] {""} ;
         BC00025_A3PaisId = new short[1] ;
         BC00024_A4LugarId = new short[1] ;
         BC00024_A5LugarName = new string[] {""} ;
         BC00024_A3PaisId = new short[1] ;
         BC00029_A4LugarId = new short[1] ;
         BC000212_A6PaisName = new string[] {""} ;
         BC000213_A1EspectaculoId = new short[1] ;
         BC000214_A4LugarId = new short[1] ;
         BC000214_A5LugarName = new string[] {""} ;
         BC000214_A6PaisName = new string[] {""} ;
         BC000214_A3PaisId = new short[1] ;
         Z28LugarSectorName = "";
         A28LugarSectorName = "";
         BC000215_A4LugarId = new short[1] ;
         BC000215_A27LugarSectorId = new short[1] ;
         BC000215_A28LugarSectorName = new string[] {""} ;
         BC000215_A29LugarSectorCantidad = new short[1] ;
         BC000215_A30LugarSectorPrecio = new short[1] ;
         BC000216_A4LugarId = new short[1] ;
         BC000216_A27LugarSectorId = new short[1] ;
         BC00023_A4LugarId = new short[1] ;
         BC00023_A27LugarSectorId = new short[1] ;
         BC00023_A28LugarSectorName = new string[] {""} ;
         BC00023_A29LugarSectorCantidad = new short[1] ;
         BC00023_A30LugarSectorPrecio = new short[1] ;
         sMode11 = "";
         BC00022_A4LugarId = new short[1] ;
         BC00022_A27LugarSectorId = new short[1] ;
         BC00022_A28LugarSectorName = new string[] {""} ;
         BC00022_A29LugarSectorCantidad = new short[1] ;
         BC00022_A30LugarSectorPrecio = new short[1] ;
         BC000220_A4LugarId = new short[1] ;
         BC000220_A27LugarSectorId = new short[1] ;
         BC000220_A28LugarSectorName = new string[] {""} ;
         BC000220_A29LugarSectorCantidad = new short[1] ;
         BC000220_A30LugarSectorPrecio = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.lugar_bc__default(),
            new Object[][] {
                new Object[] {
               BC00022_A4LugarId, BC00022_A27LugarSectorId, BC00022_A28LugarSectorName, BC00022_A29LugarSectorCantidad, BC00022_A30LugarSectorPrecio
               }
               , new Object[] {
               BC00023_A4LugarId, BC00023_A27LugarSectorId, BC00023_A28LugarSectorName, BC00023_A29LugarSectorCantidad, BC00023_A30LugarSectorPrecio
               }
               , new Object[] {
               BC00024_A4LugarId, BC00024_A5LugarName, BC00024_A3PaisId
               }
               , new Object[] {
               BC00025_A4LugarId, BC00025_A5LugarName, BC00025_A3PaisId
               }
               , new Object[] {
               BC00026_A6PaisName
               }
               , new Object[] {
               BC00027_A4LugarId, BC00027_A5LugarName, BC00027_A6PaisName, BC00027_A3PaisId
               }
               , new Object[] {
               BC00028_A4LugarId
               }
               , new Object[] {
               BC00029_A4LugarId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000212_A6PaisName
               }
               , new Object[] {
               BC000213_A1EspectaculoId
               }
               , new Object[] {
               BC000214_A4LugarId, BC000214_A5LugarName, BC000214_A6PaisName, BC000214_A3PaisId
               }
               , new Object[] {
               BC000215_A4LugarId, BC000215_A27LugarSectorId, BC000215_A28LugarSectorName, BC000215_A29LugarSectorCantidad, BC000215_A30LugarSectorPrecio
               }
               , new Object[] {
               BC000216_A4LugarId, BC000216_A27LugarSectorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000220_A4LugarId, BC000220_A27LugarSectorId, BC000220_A28LugarSectorName, BC000220_A29LugarSectorCantidad, BC000220_A30LugarSectorPrecio
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12022 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z4LugarId ;
      private short A4LugarId ;
      private short nIsMod_11 ;
      private short RcdFound11 ;
      private short GX_JID ;
      private short Z3PaisId ;
      private short A3PaisId ;
      private short RcdFound2 ;
      private short nIsDirty_2 ;
      private short nRcdExists_11 ;
      private short Gxremove11 ;
      private short Z29LugarSectorCantidad ;
      private short A29LugarSectorCantidad ;
      private short Z30LugarSectorPrecio ;
      private short A30LugarSectorPrecio ;
      private short Z27LugarSectorId ;
      private short A27LugarSectorId ;
      private short nIsDirty_11 ;
      private short Gx_BScreen ;
      private int trnEnded ;
      private int nGXsfl_11_idx=1 ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode2 ;
      private string sMode11 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z5LugarName ;
      private string A5LugarName ;
      private string Z6PaisName ;
      private string A6PaisName ;
      private string Z28LugarSectorName ;
      private string A28LugarSectorName ;
      private SdtLugar bcLugar ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00027_A4LugarId ;
      private string[] BC00027_A5LugarName ;
      private string[] BC00027_A6PaisName ;
      private short[] BC00027_A3PaisId ;
      private string[] BC00026_A6PaisName ;
      private short[] BC00028_A4LugarId ;
      private short[] BC00025_A4LugarId ;
      private string[] BC00025_A5LugarName ;
      private short[] BC00025_A3PaisId ;
      private short[] BC00024_A4LugarId ;
      private string[] BC00024_A5LugarName ;
      private short[] BC00024_A3PaisId ;
      private short[] BC00029_A4LugarId ;
      private string[] BC000212_A6PaisName ;
      private short[] BC000213_A1EspectaculoId ;
      private short[] BC000214_A4LugarId ;
      private string[] BC000214_A5LugarName ;
      private string[] BC000214_A6PaisName ;
      private short[] BC000214_A3PaisId ;
      private short[] BC000215_A4LugarId ;
      private short[] BC000215_A27LugarSectorId ;
      private string[] BC000215_A28LugarSectorName ;
      private short[] BC000215_A29LugarSectorCantidad ;
      private short[] BC000215_A30LugarSectorPrecio ;
      private short[] BC000216_A4LugarId ;
      private short[] BC000216_A27LugarSectorId ;
      private short[] BC00023_A4LugarId ;
      private short[] BC00023_A27LugarSectorId ;
      private string[] BC00023_A28LugarSectorName ;
      private short[] BC00023_A29LugarSectorCantidad ;
      private short[] BC00023_A30LugarSectorPrecio ;
      private short[] BC00022_A4LugarId ;
      private short[] BC00022_A27LugarSectorId ;
      private string[] BC00022_A28LugarSectorName ;
      private short[] BC00022_A29LugarSectorCantidad ;
      private short[] BC00022_A30LugarSectorPrecio ;
      private short[] BC000220_A4LugarId ;
      private short[] BC000220_A27LugarSectorId ;
      private string[] BC000220_A28LugarSectorName ;
      private short[] BC000220_A29LugarSectorCantidad ;
      private short[] BC000220_A30LugarSectorPrecio ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class lugar_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00027;
          prmBC00027 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC00026;
          prmBC00026 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00028;
          prmBC00028 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC00025;
          prmBC00025 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC00024;
          prmBC00024 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC00029;
          prmBC00029 = new Object[] {
          new ParDef("@LugarName",GXType.NVarChar,40,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000210;
          prmBC000210 = new Object[] {
          new ParDef("@LugarName",GXType.NVarChar,40,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000211;
          prmBC000211 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000212;
          prmBC000212 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000213;
          prmBC000213 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000214;
          prmBC000214 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000215;
          prmBC000215 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000216;
          prmBC000216 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC00023;
          prmBC00023 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC00022;
          prmBC00022 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000217;
          prmBC000217 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorName",GXType.NVarChar,40,0) ,
          new ParDef("@LugarSectorCantidad",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorPrecio",GXType.Int16,4,0)
          };
          Object[] prmBC000218;
          prmBC000218 = new Object[] {
          new ParDef("@LugarSectorName",GXType.NVarChar,40,0) ,
          new ParDef("@LugarSectorCantidad",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorPrecio",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000219;
          prmBC000219 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000220;
          prmBC000220 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00022", "SELECT [LugarId], [LugarSectorId], [LugarSectorName], [LugarSectorCantidad], [LugarSectorPrecio] FROM [LugarSector] WITH (UPDLOCK) WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00023", "SELECT [LugarId], [LugarSectorId], [LugarSectorName], [LugarSectorCantidad], [LugarSectorPrecio] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00024", "SELECT [LugarId], [LugarName], [PaisId] FROM [Lugar] WITH (UPDLOCK) WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00024,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00025", "SELECT [LugarId], [LugarName], [PaisId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00026", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00027", "SELECT TM1.[LugarId], TM1.[LugarName], T2.[PaisName], TM1.[PaisId] FROM ([Lugar] TM1 INNER JOIN [Pais] T2 ON T2.[PaisId] = TM1.[PaisId]) WHERE TM1.[LugarId] = @LugarId ORDER BY TM1.[LugarId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00027,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00028", "SELECT [LugarId] FROM [Lugar] WHERE [LugarId] = @LugarId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00028,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00029", "INSERT INTO [Lugar]([LugarName], [PaisId]) VALUES(@LugarName, @PaisId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00029,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000210", "UPDATE [Lugar] SET [LugarName]=@LugarName, [PaisId]=@PaisId  WHERE [LugarId] = @LugarId", GxErrorMask.GX_NOMASK,prmBC000210)
             ,new CursorDef("BC000211", "DELETE FROM [Lugar]  WHERE [LugarId] = @LugarId", GxErrorMask.GX_NOMASK,prmBC000211)
             ,new CursorDef("BC000212", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000212,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000213", "SELECT TOP 1 [EspectaculoId] FROM [Espectaculo] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000213,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000214", "SELECT TM1.[LugarId], TM1.[LugarName], T2.[PaisName], TM1.[PaisId] FROM ([Lugar] TM1 INNER JOIN [Pais] T2 ON T2.[PaisId] = TM1.[PaisId]) WHERE TM1.[LugarId] = @LugarId ORDER BY TM1.[LugarId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000214,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000215", "SELECT [LugarId], [LugarSectorId], [LugarSectorName], [LugarSectorCantidad], [LugarSectorPrecio] FROM [LugarSector] WHERE [LugarId] = @LugarId and [LugarSectorId] = @LugarSectorId ORDER BY [LugarId], [LugarSectorId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000215,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000216", "SELECT [LugarId], [LugarSectorId] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000216,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000217", "INSERT INTO [LugarSector]([LugarId], [LugarSectorId], [LugarSectorName], [LugarSectorCantidad], [LugarSectorPrecio]) VALUES(@LugarId, @LugarSectorId, @LugarSectorName, @LugarSectorCantidad, @LugarSectorPrecio)", GxErrorMask.GX_NOMASK,prmBC000217)
             ,new CursorDef("BC000218", "UPDATE [LugarSector] SET [LugarSectorName]=@LugarSectorName, [LugarSectorCantidad]=@LugarSectorCantidad, [LugarSectorPrecio]=@LugarSectorPrecio  WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId", GxErrorMask.GX_NOMASK,prmBC000218)
             ,new CursorDef("BC000219", "DELETE FROM [LugarSector]  WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId", GxErrorMask.GX_NOMASK,prmBC000219)
             ,new CursorDef("BC000220", "SELECT [LugarId], [LugarSectorId], [LugarSectorName], [LugarSectorCantidad], [LugarSectorPrecio] FROM [LugarSector] WHERE [LugarId] = @LugarId ORDER BY [LugarId], [LugarSectorId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000220,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
