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
   public class espectaculo_bc : GXHttpHandler, IGxSilentTrn
   {
      public espectaculo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public espectaculo_bc( IGxContext context )
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
         ReadRow0A15( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0A15( ) ;
         standaloneModal( ) ;
         AddRow0A15( ) ;
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
            E110A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1EspectaculoId = A1EspectaculoId;
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

      protected void CONFIRM_0A0( )
      {
         BeforeValidate0A15( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0A15( ) ;
            }
            else
            {
               CheckExtendedTable0A15( ) ;
               if ( AnyError == 0 )
               {
                  ZM0A15( 4) ;
                  ZM0A15( 5) ;
                  ZM0A15( 6) ;
               }
               CloseExtendedTableCursors0A15( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode15 = Gx_mode;
            CONFIRM_0A16( ) ;
            if ( AnyError == 0 )
            {
               CONFIRM_0A18( ) ;
               if ( AnyError == 0 )
               {
                  /* Restore parent mode. */
                  Gx_mode = sMode15;
                  IsConfirmed = 1;
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode15;
         }
      }

      protected void CONFIRM_0A18( )
      {
         nGXsfl_18_idx = 0;
         while ( nGXsfl_18_idx < bcEspectaculo.gxTpr_Espectaculofuncion.Count )
         {
            ReadRow0A18( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound18 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_18 != 0 ) )
            {
               GetKey0A18( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound18 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0A18( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0A18( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0A18( ) ;
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
                  if ( RcdFound18 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0A18( ) ;
                        Load0A18( ) ;
                        BeforeValidate0A18( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0A18( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_18 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0A18( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0A18( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0A18( ) ;
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
               VarsToRow18( ((SdtEspectaculo_EspectaculoFuncion)bcEspectaculo.gxTpr_Espectaculofuncion.Item(nGXsfl_18_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0A16( )
      {
         nGXsfl_16_idx = 0;
         while ( nGXsfl_16_idx < bcEspectaculo.gxTpr_Lugarsector.Count )
         {
            ReadRow0A16( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound16 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_16 != 0 ) )
            {
               GetKey0A16( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound16 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0A16( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0A16( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0A16( 8) ;
                           ZM0A16( 9) ;
                        }
                        CloseExtendedTableCursors0A16( ) ;
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
                  if ( RcdFound16 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0A16( ) ;
                        Load0A16( ) ;
                        BeforeValidate0A16( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0A16( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_16 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0A16( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0A16( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0A16( 8) ;
                                 ZM0A16( 9) ;
                              }
                              CloseExtendedTableCursors0A16( ) ;
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
               VarsToRow16( ((SdtEspectaculo_LugarSector)bcEspectaculo.gxTpr_Lugarsector.Item(nGXsfl_16_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120A2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E110A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0A15( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z2EspectaculoName = A2EspectaculoName;
            Z16EspectaculoFecha = A16EspectaculoFecha;
            Z4LugarId = A4LugarId;
            Z7TipoEspectaculoId = A7TipoEspectaculoId;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z5LugarName = A5LugarName;
            Z3PaisId = A3PaisId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z8TipoEspectaculoName = A8TipoEspectaculoName;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z6PaisName = A6PaisName;
         }
         if ( GX_JID == -3 )
         {
            Z1EspectaculoId = A1EspectaculoId;
            Z2EspectaculoName = A2EspectaculoName;
            Z16EspectaculoFecha = A16EspectaculoFecha;
            Z26EspectaculoImagen = A26EspectaculoImagen;
            Z40000EspectaculoImagen_GXI = A40000EspectaculoImagen_GXI;
            Z4LugarId = A4LugarId;
            Z7TipoEspectaculoId = A7TipoEspectaculoId;
            Z5LugarName = A5LugarName;
            Z3PaisId = A3PaisId;
            Z6PaisName = A6PaisName;
            Z8TipoEspectaculoName = A8TipoEspectaculoName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0A15( )
      {
         /* Using cursor BC000A14 */
         pr_default.execute(11, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound15 = 1;
            A2EspectaculoName = BC000A14_A2EspectaculoName[0];
            A16EspectaculoFecha = BC000A14_A16EspectaculoFecha[0];
            A6PaisName = BC000A14_A6PaisName[0];
            A5LugarName = BC000A14_A5LugarName[0];
            A8TipoEspectaculoName = BC000A14_A8TipoEspectaculoName[0];
            A40000EspectaculoImagen_GXI = BC000A14_A40000EspectaculoImagen_GXI[0];
            A4LugarId = BC000A14_A4LugarId[0];
            A7TipoEspectaculoId = BC000A14_A7TipoEspectaculoId[0];
            A3PaisId = BC000A14_A3PaisId[0];
            A26EspectaculoImagen = BC000A14_A26EspectaculoImagen[0];
            ZM0A15( -3) ;
         }
         pr_default.close(11);
         OnLoadActions0A15( ) ;
      }

      protected void OnLoadActions0A15( )
      {
      }

      protected void CheckExtendedTable0A15( )
      {
         nIsDirty_15 = 0;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A16EspectaculoFecha) || ( DateTimeUtil.ResetTime ( A16EspectaculoFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Espectaculo Fecha fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000A11 */
         pr_default.execute(8, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
         }
         A5LugarName = BC000A11_A5LugarName[0];
         A3PaisId = BC000A11_A3PaisId[0];
         pr_default.close(8);
         /* Using cursor BC000A13 */
         pr_default.execute(10, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = BC000A13_A6PaisName[0];
         pr_default.close(10);
         /* Using cursor BC000A12 */
         pr_default.execute(9, new Object[] {A7TipoEspectaculoId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
         }
         A8TipoEspectaculoName = BC000A12_A8TipoEspectaculoName[0];
         pr_default.close(9);
      }

      protected void CloseExtendedTableCursors0A15( )
      {
         pr_default.close(8);
         pr_default.close(10);
         pr_default.close(9);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0A15( )
      {
         /* Using cursor BC000A15 */
         pr_default.execute(12, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(12);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000A10 */
         pr_default.execute(7, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            ZM0A15( 3) ;
            RcdFound15 = 1;
            A1EspectaculoId = BC000A10_A1EspectaculoId[0];
            A2EspectaculoName = BC000A10_A2EspectaculoName[0];
            A16EspectaculoFecha = BC000A10_A16EspectaculoFecha[0];
            A40000EspectaculoImagen_GXI = BC000A10_A40000EspectaculoImagen_GXI[0];
            A4LugarId = BC000A10_A4LugarId[0];
            A7TipoEspectaculoId = BC000A10_A7TipoEspectaculoId[0];
            A26EspectaculoImagen = BC000A10_A26EspectaculoImagen[0];
            Z1EspectaculoId = A1EspectaculoId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0A15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0A15( ) ;
            }
            Gx_mode = sMode15;
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0A15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode15;
         }
         pr_default.close(7);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A15( ) ;
         if ( RcdFound15 == 0 )
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
         CONFIRM_0A0( ) ;
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

      protected void CheckOptimisticConcurrency0A15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000A9 */
            pr_default.execute(6, new Object[] {A1EspectaculoId});
            if ( (pr_default.getStatus(6) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Espectaculo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(6) == 101) || ( StringUtil.StrCmp(Z2EspectaculoName, BC000A9_A2EspectaculoName[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z16EspectaculoFecha ) != DateTimeUtil.ResetTime ( BC000A9_A16EspectaculoFecha[0] ) ) || ( Z4LugarId != BC000A9_A4LugarId[0] ) || ( Z7TipoEspectaculoId != BC000A9_A7TipoEspectaculoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Espectaculo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A15( )
      {
         BeforeValidate0A15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A15( 0) ;
            CheckOptimisticConcurrency0A15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A16 */
                     pr_default.execute(13, new Object[] {A2EspectaculoName, A16EspectaculoFecha, A26EspectaculoImagen, A40000EspectaculoImagen_GXI, A4LugarId, A7TipoEspectaculoId});
                     A1EspectaculoId = BC000A16_A1EspectaculoId[0];
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("Espectaculo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0A15( ) ;
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
               Load0A15( ) ;
            }
            EndLevel0A15( ) ;
         }
         CloseExtendedTableCursors0A15( ) ;
      }

      protected void Update0A15( )
      {
         BeforeValidate0A15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A17 */
                     pr_default.execute(14, new Object[] {A2EspectaculoName, A16EspectaculoFecha, A4LugarId, A7TipoEspectaculoId, A1EspectaculoId});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("Espectaculo");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Espectaculo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A15( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0A15( ) ;
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
            EndLevel0A15( ) ;
         }
         CloseExtendedTableCursors0A15( ) ;
      }

      protected void DeferredUpdate0A15( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000A18 */
            pr_default.execute(15, new Object[] {A26EspectaculoImagen, A40000EspectaculoImagen_GXI, A1EspectaculoId});
            pr_default.close(15);
            dsDefault.SmartCacheProvider.SetUpdated("Espectaculo");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0A15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A15( ) ;
            AfterConfirm0A15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A15( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0A18( ) ;
                  while ( RcdFound18 != 0 )
                  {
                     getByPrimaryKey0A18( ) ;
                     Delete0A18( ) ;
                     ScanKeyNext0A18( ) ;
                  }
                  ScanKeyEnd0A18( ) ;
                  ScanKeyStart0A16( ) ;
                  while ( RcdFound16 != 0 )
                  {
                     getByPrimaryKey0A16( ) ;
                     Delete0A16( ) ;
                     ScanKeyNext0A16( ) ;
                  }
                  ScanKeyEnd0A16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A19 */
                     pr_default.execute(16, new Object[] {A1EspectaculoId});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("Espectaculo");
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0A15( ) ;
         Gx_mode = sMode15;
      }

      protected void OnDeleteControls0A15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000A20 */
            pr_default.execute(17, new Object[] {A4LugarId});
            A5LugarName = BC000A20_A5LugarName[0];
            A3PaisId = BC000A20_A3PaisId[0];
            pr_default.close(17);
            /* Using cursor BC000A21 */
            pr_default.execute(18, new Object[] {A3PaisId});
            A6PaisName = BC000A21_A6PaisName[0];
            pr_default.close(18);
            /* Using cursor BC000A22 */
            pr_default.execute(19, new Object[] {A7TipoEspectaculoId});
            A8TipoEspectaculoName = BC000A22_A8TipoEspectaculoName[0];
            pr_default.close(19);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000A23 */
            pr_default.execute(20, new Object[] {A1EspectaculoId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Entrada"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor BC000A24 */
            pr_default.execute(21, new Object[] {A1EspectaculoId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Entrada"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
         }
      }

      protected void ProcessNestedLevel0A16( )
      {
         nGXsfl_16_idx = 0;
         while ( nGXsfl_16_idx < bcEspectaculo.gxTpr_Lugarsector.Count )
         {
            ReadRow0A16( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound16 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_16 != 0 ) )
            {
               standaloneNotModal0A16( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0A16( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0A16( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0A16( ) ;
                  }
               }
            }
            KeyVarsToRow16( ((SdtEspectaculo_LugarSector)bcEspectaculo.gxTpr_Lugarsector.Item(nGXsfl_16_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_16_idx = 0;
            while ( nGXsfl_16_idx < bcEspectaculo.gxTpr_Lugarsector.Count )
            {
               ReadRow0A16( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound16 == 0 )
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
                  bcEspectaculo.gxTpr_Lugarsector.RemoveElement(nGXsfl_16_idx);
                  nGXsfl_16_idx = (int)(nGXsfl_16_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0A16( ) ;
                  VarsToRow16( ((SdtEspectaculo_LugarSector)bcEspectaculo.gxTpr_Lugarsector.Item(nGXsfl_16_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0A16( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_16 = 0;
         nIsMod_16 = 0;
         Gxremove16 = 0;
      }

      protected void ProcessNestedLevel0A18( )
      {
         nGXsfl_18_idx = 0;
         while ( nGXsfl_18_idx < bcEspectaculo.gxTpr_Espectaculofuncion.Count )
         {
            ReadRow0A18( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound18 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_18 != 0 ) )
            {
               standaloneNotModal0A18( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0A18( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0A18( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0A18( ) ;
                  }
               }
            }
            KeyVarsToRow18( ((SdtEspectaculo_EspectaculoFuncion)bcEspectaculo.gxTpr_Espectaculofuncion.Item(nGXsfl_18_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_18_idx = 0;
            while ( nGXsfl_18_idx < bcEspectaculo.gxTpr_Espectaculofuncion.Count )
            {
               ReadRow0A18( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound18 == 0 )
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
                  bcEspectaculo.gxTpr_Espectaculofuncion.RemoveElement(nGXsfl_18_idx);
                  nGXsfl_18_idx = (int)(nGXsfl_18_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0A18( ) ;
                  VarsToRow18( ((SdtEspectaculo_EspectaculoFuncion)bcEspectaculo.gxTpr_Espectaculofuncion.Item(nGXsfl_18_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0A18( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_18 = 0;
         nIsMod_18 = 0;
         Gxremove18 = 0;
      }

      protected void ProcessLevel0A15( )
      {
         /* Save parent mode. */
         sMode15 = Gx_mode;
         ProcessNestedLevel0A16( ) ;
         ProcessNestedLevel0A18( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode15;
         /* ' Update level parameters */
      }

      protected void EndLevel0A15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(6);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A15( ) ;
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

      public void ScanKeyStart0A15( )
      {
         /* Scan By routine */
         /* Using cursor BC000A25 */
         pr_default.execute(22, new Object[] {A1EspectaculoId});
         RcdFound15 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound15 = 1;
            A1EspectaculoId = BC000A25_A1EspectaculoId[0];
            A2EspectaculoName = BC000A25_A2EspectaculoName[0];
            A16EspectaculoFecha = BC000A25_A16EspectaculoFecha[0];
            A6PaisName = BC000A25_A6PaisName[0];
            A5LugarName = BC000A25_A5LugarName[0];
            A8TipoEspectaculoName = BC000A25_A8TipoEspectaculoName[0];
            A40000EspectaculoImagen_GXI = BC000A25_A40000EspectaculoImagen_GXI[0];
            A4LugarId = BC000A25_A4LugarId[0];
            A7TipoEspectaculoId = BC000A25_A7TipoEspectaculoId[0];
            A3PaisId = BC000A25_A3PaisId[0];
            A26EspectaculoImagen = BC000A25_A26EspectaculoImagen[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0A15( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound15 = 0;
         ScanKeyLoad0A15( ) ;
      }

      protected void ScanKeyLoad0A15( )
      {
         sMode15 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound15 = 1;
            A1EspectaculoId = BC000A25_A1EspectaculoId[0];
            A2EspectaculoName = BC000A25_A2EspectaculoName[0];
            A16EspectaculoFecha = BC000A25_A16EspectaculoFecha[0];
            A6PaisName = BC000A25_A6PaisName[0];
            A5LugarName = BC000A25_A5LugarName[0];
            A8TipoEspectaculoName = BC000A25_A8TipoEspectaculoName[0];
            A40000EspectaculoImagen_GXI = BC000A25_A40000EspectaculoImagen_GXI[0];
            A4LugarId = BC000A25_A4LugarId[0];
            A7TipoEspectaculoId = BC000A25_A7TipoEspectaculoId[0];
            A3PaisId = BC000A25_A3PaisId[0];
            A26EspectaculoImagen = BC000A25_A26EspectaculoImagen[0];
         }
         Gx_mode = sMode15;
      }

      protected void ScanKeyEnd0A15( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm0A15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A15( )
      {
      }

      protected void ZM0A16( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z41LugarSectorEstadoSector = A41LugarSectorEstadoSector;
            Z37LugarSectorVendidas = A37LugarSectorVendidas;
            Z38LugarSectorDisponibles = A38LugarSectorDisponibles;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z28LugarSectorName = A28LugarSectorName;
            Z29LugarSectorCantidad = A29LugarSectorCantidad;
            Z30LugarSectorPrecio = A30LugarSectorPrecio;
            Z37LugarSectorVendidas = A37LugarSectorVendidas;
            Z38LugarSectorDisponibles = A38LugarSectorDisponibles;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z37LugarSectorVendidas = A37LugarSectorVendidas;
            Z38LugarSectorDisponibles = A38LugarSectorDisponibles;
         }
         if ( GX_JID == -7 )
         {
            Z1EspectaculoId = A1EspectaculoId;
            Z41LugarSectorEstadoSector = A41LugarSectorEstadoSector;
            Z27LugarSectorId = A27LugarSectorId;
            Z28LugarSectorName = A28LugarSectorName;
            Z29LugarSectorCantidad = A29LugarSectorCantidad;
            Z30LugarSectorPrecio = A30LugarSectorPrecio;
            Z37LugarSectorVendidas = A37LugarSectorVendidas;
         }
      }

      protected void standaloneNotModal0A16( )
      {
      }

      protected void standaloneModal0A16( )
      {
      }

      protected void Load0A16( )
      {
         /* Using cursor BC000A27 */
         pr_default.execute(23, new Object[] {A4LugarId, A1EspectaculoId, A27LugarSectorId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound16 = 1;
            A28LugarSectorName = BC000A27_A28LugarSectorName[0];
            A29LugarSectorCantidad = BC000A27_A29LugarSectorCantidad[0];
            A41LugarSectorEstadoSector = BC000A27_A41LugarSectorEstadoSector[0];
            A30LugarSectorPrecio = BC000A27_A30LugarSectorPrecio[0];
            A37LugarSectorVendidas = BC000A27_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = BC000A27_n37LugarSectorVendidas[0];
            ZM0A16( -7) ;
         }
         pr_default.close(23);
         OnLoadActions0A16( ) ;
      }

      protected void OnLoadActions0A16( )
      {
         A38LugarSectorDisponibles = (short)(A29LugarSectorCantidad-A37LugarSectorVendidas);
      }

      protected void CheckExtendedTable0A16( )
      {
         nIsDirty_16 = 0;
         Gx_BScreen = 1;
         standaloneModal0A16( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000A6 */
         pr_default.execute(4, new Object[] {A4LugarId, A27LugarSectorId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "LUGARSECTORID");
            AnyError = 1;
         }
         A28LugarSectorName = BC000A6_A28LugarSectorName[0];
         A29LugarSectorCantidad = BC000A6_A29LugarSectorCantidad[0];
         A30LugarSectorPrecio = BC000A6_A30LugarSectorPrecio[0];
         pr_default.close(4);
         /* Using cursor BC000A8 */
         pr_default.execute(5, new Object[] {A1EspectaculoId, A27LugarSectorId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A37LugarSectorVendidas = BC000A8_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = BC000A8_n37LugarSectorVendidas[0];
         }
         else
         {
            nIsDirty_16 = 1;
            A37LugarSectorVendidas = 0;
            n37LugarSectorVendidas = false;
         }
         pr_default.close(5);
         nIsDirty_16 = 1;
         A38LugarSectorDisponibles = (short)(A29LugarSectorCantidad-A37LugarSectorVendidas);
      }

      protected void CloseExtendedTableCursors0A16( )
      {
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable0A16( )
      {
      }

      protected void GetKey0A16( )
      {
         /* Using cursor BC000A28 */
         pr_default.execute(24, new Object[] {A1EspectaculoId, A27LugarSectorId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(24);
      }

      protected void getByPrimaryKey0A16( )
      {
         /* Using cursor BC000A5 */
         pr_default.execute(3, new Object[] {A1EspectaculoId, A27LugarSectorId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0A16( 7) ;
            RcdFound16 = 1;
            InitializeNonKey0A16( ) ;
            A41LugarSectorEstadoSector = BC000A5_A41LugarSectorEstadoSector[0];
            A27LugarSectorId = BC000A5_A27LugarSectorId[0];
            Z1EspectaculoId = A1EspectaculoId;
            Z27LugarSectorId = A27LugarSectorId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0A16( ) ;
            Load0A16( ) ;
            Gx_mode = sMode16;
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0A16( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0A16( ) ;
            Gx_mode = sMode16;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0A16( ) ;
         }
         pr_default.close(3);
      }

      protected void CheckOptimisticConcurrency0A16( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000A4 */
            pr_default.execute(2, new Object[] {A1EspectaculoId, A27LugarSectorId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EspectaculoLugarSector"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( Z41LugarSectorEstadoSector != BC000A4_A41LugarSectorEstadoSector[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EspectaculoLugarSector"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A16( )
      {
         BeforeValidate0A16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A16( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A16( 0) ;
            CheckOptimisticConcurrency0A16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A29 */
                     pr_default.execute(25, new Object[] {A1EspectaculoId, A41LugarSectorEstadoSector, A27LugarSectorId});
                     pr_default.close(25);
                     dsDefault.SmartCacheProvider.SetUpdated("EspectaculoLugarSector");
                     if ( (pr_default.getStatus(25) == 1) )
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
               Load0A16( ) ;
            }
            EndLevel0A16( ) ;
         }
         CloseExtendedTableCursors0A16( ) ;
      }

      protected void Update0A16( )
      {
         BeforeValidate0A16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A16( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A30 */
                     pr_default.execute(26, new Object[] {A41LugarSectorEstadoSector, A1EspectaculoId, A27LugarSectorId});
                     pr_default.close(26);
                     dsDefault.SmartCacheProvider.SetUpdated("EspectaculoLugarSector");
                     if ( (pr_default.getStatus(26) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EspectaculoLugarSector"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A16( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0A16( ) ;
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
            EndLevel0A16( ) ;
         }
         CloseExtendedTableCursors0A16( ) ;
      }

      protected void DeferredUpdate0A16( )
      {
      }

      protected void Delete0A16( )
      {
         Gx_mode = "DLT";
         BeforeValidate0A16( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A16( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A16( ) ;
            AfterConfirm0A16( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A16( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000A31 */
                  pr_default.execute(27, new Object[] {A1EspectaculoId, A27LugarSectorId});
                  pr_default.close(27);
                  dsDefault.SmartCacheProvider.SetUpdated("EspectaculoLugarSector");
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
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0A16( ) ;
         Gx_mode = sMode16;
      }

      protected void OnDeleteControls0A16( )
      {
         standaloneModal0A16( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000A32 */
            pr_default.execute(28, new Object[] {A4LugarId, A27LugarSectorId});
            A28LugarSectorName = BC000A32_A28LugarSectorName[0];
            A29LugarSectorCantidad = BC000A32_A29LugarSectorCantidad[0];
            A30LugarSectorPrecio = BC000A32_A30LugarSectorPrecio[0];
            pr_default.close(28);
            /* Using cursor BC000A34 */
            pr_default.execute(29, new Object[] {A1EspectaculoId, A27LugarSectorId});
            if ( (pr_default.getStatus(29) != 101) )
            {
               A37LugarSectorVendidas = BC000A34_A37LugarSectorVendidas[0];
               n37LugarSectorVendidas = BC000A34_n37LugarSectorVendidas[0];
            }
            else
            {
               A37LugarSectorVendidas = 0;
               n37LugarSectorVendidas = false;
            }
            pr_default.close(29);
            A38LugarSectorDisponibles = (short)(A29LugarSectorCantidad-A37LugarSectorVendidas);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000A35 */
            pr_default.execute(30, new Object[] {A1EspectaculoId, A27LugarSectorId});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Invitacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor BC000A36 */
            pr_default.execute(31, new Object[] {A1EspectaculoId, A27LugarSectorId});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Entrada"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
         }
      }

      protected void EndLevel0A16( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0A16( )
      {
         /* Scan By routine */
         /* Using cursor BC000A38 */
         pr_default.execute(32, new Object[] {A4LugarId, A1EspectaculoId});
         RcdFound16 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound16 = 1;
            A28LugarSectorName = BC000A38_A28LugarSectorName[0];
            A29LugarSectorCantidad = BC000A38_A29LugarSectorCantidad[0];
            A41LugarSectorEstadoSector = BC000A38_A41LugarSectorEstadoSector[0];
            A30LugarSectorPrecio = BC000A38_A30LugarSectorPrecio[0];
            A27LugarSectorId = BC000A38_A27LugarSectorId[0];
            A37LugarSectorVendidas = BC000A38_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = BC000A38_n37LugarSectorVendidas[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0A16( )
      {
         /* Scan next routine */
         pr_default.readNext(32);
         RcdFound16 = 0;
         ScanKeyLoad0A16( ) ;
      }

      protected void ScanKeyLoad0A16( )
      {
         sMode16 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound16 = 1;
            A28LugarSectorName = BC000A38_A28LugarSectorName[0];
            A29LugarSectorCantidad = BC000A38_A29LugarSectorCantidad[0];
            A41LugarSectorEstadoSector = BC000A38_A41LugarSectorEstadoSector[0];
            A30LugarSectorPrecio = BC000A38_A30LugarSectorPrecio[0];
            A27LugarSectorId = BC000A38_A27LugarSectorId[0];
            A37LugarSectorVendidas = BC000A38_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = BC000A38_n37LugarSectorVendidas[0];
         }
         Gx_mode = sMode16;
      }

      protected void ScanKeyEnd0A16( )
      {
         pr_default.close(32);
      }

      protected void AfterConfirm0A16( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A16( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A16( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A16( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A16( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A16( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A16( )
      {
      }

      protected void send_integrity_lvl_hashes0A16( )
      {
      }

      protected void ZM0A18( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z48EspectaculoFuncionName = A48EspectaculoFuncionName;
            Z49EspectaculoFuncionPrecio = A49EspectaculoFuncionPrecio;
         }
         if ( GX_JID == -10 )
         {
            Z1EspectaculoId = A1EspectaculoId;
            Z47EspectaculoFuncionId = A47EspectaculoFuncionId;
            Z48EspectaculoFuncionName = A48EspectaculoFuncionName;
            Z49EspectaculoFuncionPrecio = A49EspectaculoFuncionPrecio;
         }
      }

      protected void standaloneNotModal0A18( )
      {
      }

      protected void standaloneModal0A18( )
      {
      }

      protected void Load0A18( )
      {
         /* Using cursor BC000A39 */
         pr_default.execute(33, new Object[] {A1EspectaculoId, A47EspectaculoFuncionId});
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound18 = 1;
            A48EspectaculoFuncionName = BC000A39_A48EspectaculoFuncionName[0];
            A49EspectaculoFuncionPrecio = BC000A39_A49EspectaculoFuncionPrecio[0];
            ZM0A18( -10) ;
         }
         pr_default.close(33);
         OnLoadActions0A18( ) ;
      }

      protected void OnLoadActions0A18( )
      {
      }

      protected void CheckExtendedTable0A18( )
      {
         nIsDirty_18 = 0;
         Gx_BScreen = 1;
         standaloneModal0A18( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors0A18( )
      {
      }

      protected void enableDisable0A18( )
      {
      }

      protected void GetKey0A18( )
      {
         /* Using cursor BC000A40 */
         pr_default.execute(34, new Object[] {A1EspectaculoId, A47EspectaculoFuncionId});
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(34);
      }

      protected void getByPrimaryKey0A18( )
      {
         /* Using cursor BC000A3 */
         pr_default.execute(1, new Object[] {A1EspectaculoId, A47EspectaculoFuncionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A18( 10) ;
            RcdFound18 = 1;
            InitializeNonKey0A18( ) ;
            A47EspectaculoFuncionId = BC000A3_A47EspectaculoFuncionId[0];
            A48EspectaculoFuncionName = BC000A3_A48EspectaculoFuncionName[0];
            A49EspectaculoFuncionPrecio = BC000A3_A49EspectaculoFuncionPrecio[0];
            Z1EspectaculoId = A1EspectaculoId;
            Z47EspectaculoFuncionId = A47EspectaculoFuncionId;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0A18( ) ;
            Load0A18( ) ;
            Gx_mode = sMode18;
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0A18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0A18( ) ;
            Gx_mode = sMode18;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0A18( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0A18( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000A2 */
            pr_default.execute(0, new Object[] {A1EspectaculoId, A47EspectaculoFuncionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EspectaculoFuncion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z48EspectaculoFuncionName, BC000A2_A48EspectaculoFuncionName[0]) != 0 ) || ( Z49EspectaculoFuncionPrecio != BC000A2_A49EspectaculoFuncionPrecio[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EspectaculoFuncion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A18( )
      {
         BeforeValidate0A18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A18( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A18( 0) ;
            CheckOptimisticConcurrency0A18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A41 */
                     pr_default.execute(35, new Object[] {A1EspectaculoId, A47EspectaculoFuncionId, A48EspectaculoFuncionName, A49EspectaculoFuncionPrecio});
                     pr_default.close(35);
                     dsDefault.SmartCacheProvider.SetUpdated("EspectaculoFuncion");
                     if ( (pr_default.getStatus(35) == 1) )
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
               Load0A18( ) ;
            }
            EndLevel0A18( ) ;
         }
         CloseExtendedTableCursors0A18( ) ;
      }

      protected void Update0A18( )
      {
         BeforeValidate0A18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A18( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A42 */
                     pr_default.execute(36, new Object[] {A48EspectaculoFuncionName, A49EspectaculoFuncionPrecio, A1EspectaculoId, A47EspectaculoFuncionId});
                     pr_default.close(36);
                     dsDefault.SmartCacheProvider.SetUpdated("EspectaculoFuncion");
                     if ( (pr_default.getStatus(36) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EspectaculoFuncion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A18( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0A18( ) ;
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
            EndLevel0A18( ) ;
         }
         CloseExtendedTableCursors0A18( ) ;
      }

      protected void DeferredUpdate0A18( )
      {
      }

      protected void Delete0A18( )
      {
         Gx_mode = "DLT";
         BeforeValidate0A18( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A18( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A18( ) ;
            AfterConfirm0A18( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A18( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000A43 */
                  pr_default.execute(37, new Object[] {A1EspectaculoId, A47EspectaculoFuncionId});
                  pr_default.close(37);
                  dsDefault.SmartCacheProvider.SetUpdated("EspectaculoFuncion");
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
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0A18( ) ;
         Gx_mode = sMode18;
      }

      protected void OnDeleteControls0A18( )
      {
         standaloneModal0A18( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000A44 */
            pr_default.execute(38, new Object[] {A1EspectaculoId, A47EspectaculoFuncionId});
            if ( (pr_default.getStatus(38) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Entrada"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(38);
         }
      }

      protected void EndLevel0A18( )
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

      public void ScanKeyStart0A18( )
      {
         /* Scan By routine */
         /* Using cursor BC000A45 */
         pr_default.execute(39, new Object[] {A1EspectaculoId});
         RcdFound18 = 0;
         if ( (pr_default.getStatus(39) != 101) )
         {
            RcdFound18 = 1;
            A47EspectaculoFuncionId = BC000A45_A47EspectaculoFuncionId[0];
            A48EspectaculoFuncionName = BC000A45_A48EspectaculoFuncionName[0];
            A49EspectaculoFuncionPrecio = BC000A45_A49EspectaculoFuncionPrecio[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0A18( )
      {
         /* Scan next routine */
         pr_default.readNext(39);
         RcdFound18 = 0;
         ScanKeyLoad0A18( ) ;
      }

      protected void ScanKeyLoad0A18( )
      {
         sMode18 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(39) != 101) )
         {
            RcdFound18 = 1;
            A47EspectaculoFuncionId = BC000A45_A47EspectaculoFuncionId[0];
            A48EspectaculoFuncionName = BC000A45_A48EspectaculoFuncionName[0];
            A49EspectaculoFuncionPrecio = BC000A45_A49EspectaculoFuncionPrecio[0];
         }
         Gx_mode = sMode18;
      }

      protected void ScanKeyEnd0A18( )
      {
         pr_default.close(39);
      }

      protected void AfterConfirm0A18( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A18( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A18( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A18( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A18( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A18( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A18( )
      {
      }

      protected void send_integrity_lvl_hashes0A18( )
      {
      }

      protected void send_integrity_lvl_hashes0A15( )
      {
      }

      protected void AddRow0A15( )
      {
         VarsToRow15( bcEspectaculo) ;
      }

      protected void ReadRow0A15( )
      {
         RowToVars15( bcEspectaculo, 1) ;
      }

      protected void AddRow0A16( )
      {
         SdtEspectaculo_LugarSector obj16;
         obj16 = new SdtEspectaculo_LugarSector(context);
         VarsToRow16( obj16) ;
         bcEspectaculo.gxTpr_Lugarsector.Add(obj16, 0);
         obj16.gxTpr_Mode = "UPD";
         obj16.gxTpr_Modified = 0;
      }

      protected void ReadRow0A16( )
      {
         nGXsfl_16_idx = (int)(nGXsfl_16_idx+1);
         RowToVars16( ((SdtEspectaculo_LugarSector)bcEspectaculo.gxTpr_Lugarsector.Item(nGXsfl_16_idx)), 1) ;
      }

      protected void AddRow0A18( )
      {
         SdtEspectaculo_EspectaculoFuncion obj18;
         obj18 = new SdtEspectaculo_EspectaculoFuncion(context);
         VarsToRow18( obj18) ;
         bcEspectaculo.gxTpr_Espectaculofuncion.Add(obj18, 0);
         obj18.gxTpr_Mode = "UPD";
         obj18.gxTpr_Modified = 0;
      }

      protected void ReadRow0A18( )
      {
         nGXsfl_18_idx = (int)(nGXsfl_18_idx+1);
         RowToVars18( ((SdtEspectaculo_EspectaculoFuncion)bcEspectaculo.gxTpr_Espectaculofuncion.Item(nGXsfl_18_idx)), 1) ;
      }

      protected void InitializeNonKey0A15( )
      {
         A2EspectaculoName = "";
         A16EspectaculoFecha = DateTime.MinValue;
         A3PaisId = 0;
         A6PaisName = "";
         A4LugarId = 0;
         A5LugarName = "";
         A7TipoEspectaculoId = 0;
         A8TipoEspectaculoName = "";
         A26EspectaculoImagen = "";
         A40000EspectaculoImagen_GXI = "";
         Z2EspectaculoName = "";
         Z16EspectaculoFecha = DateTime.MinValue;
         Z4LugarId = 0;
         Z7TipoEspectaculoId = 0;
      }

      protected void InitAll0A15( )
      {
         A1EspectaculoId = 0;
         InitializeNonKey0A15( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0A16( )
      {
         A38LugarSectorDisponibles = 0;
         A28LugarSectorName = "";
         A29LugarSectorCantidad = 0;
         A41LugarSectorEstadoSector = false;
         A30LugarSectorPrecio = 0;
         A37LugarSectorVendidas = 0;
         n37LugarSectorVendidas = false;
         Z41LugarSectorEstadoSector = false;
      }

      protected void InitAll0A16( )
      {
         A27LugarSectorId = 0;
         InitializeNonKey0A16( ) ;
      }

      protected void StandaloneModalInsert0A16( )
      {
      }

      protected void InitializeNonKey0A18( )
      {
         A48EspectaculoFuncionName = "";
         A49EspectaculoFuncionPrecio = 0;
         Z48EspectaculoFuncionName = "";
         Z49EspectaculoFuncionPrecio = 0;
      }

      protected void InitAll0A18( )
      {
         A47EspectaculoFuncionId = 0;
         InitializeNonKey0A18( ) ;
      }

      protected void StandaloneModalInsert0A18( )
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

      public void VarsToRow15( SdtEspectaculo obj15 )
      {
         obj15.gxTpr_Mode = Gx_mode;
         obj15.gxTpr_Espectaculoname = A2EspectaculoName;
         obj15.gxTpr_Espectaculofecha = A16EspectaculoFecha;
         obj15.gxTpr_Paisid = A3PaisId;
         obj15.gxTpr_Paisname = A6PaisName;
         obj15.gxTpr_Lugarid = A4LugarId;
         obj15.gxTpr_Lugarname = A5LugarName;
         obj15.gxTpr_Tipoespectaculoid = A7TipoEspectaculoId;
         obj15.gxTpr_Tipoespectaculoname = A8TipoEspectaculoName;
         obj15.gxTpr_Espectaculoimagen = A26EspectaculoImagen;
         obj15.gxTpr_Espectaculoimagen_gxi = A40000EspectaculoImagen_GXI;
         obj15.gxTpr_Espectaculoid = A1EspectaculoId;
         obj15.gxTpr_Espectaculoid_Z = Z1EspectaculoId;
         obj15.gxTpr_Espectaculoname_Z = Z2EspectaculoName;
         obj15.gxTpr_Espectaculofecha_Z = Z16EspectaculoFecha;
         obj15.gxTpr_Paisid_Z = Z3PaisId;
         obj15.gxTpr_Paisname_Z = Z6PaisName;
         obj15.gxTpr_Lugarid_Z = Z4LugarId;
         obj15.gxTpr_Lugarname_Z = Z5LugarName;
         obj15.gxTpr_Tipoespectaculoid_Z = Z7TipoEspectaculoId;
         obj15.gxTpr_Tipoespectaculoname_Z = Z8TipoEspectaculoName;
         obj15.gxTpr_Espectaculoimagen_gxi_Z = Z40000EspectaculoImagen_GXI;
         obj15.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow15( SdtEspectaculo obj15 )
      {
         obj15.gxTpr_Espectaculoid = A1EspectaculoId;
         return  ;
      }

      public void RowToVars15( SdtEspectaculo obj15 ,
                               int forceLoad )
      {
         Gx_mode = obj15.gxTpr_Mode;
         A2EspectaculoName = obj15.gxTpr_Espectaculoname;
         A16EspectaculoFecha = obj15.gxTpr_Espectaculofecha;
         A3PaisId = obj15.gxTpr_Paisid;
         A6PaisName = obj15.gxTpr_Paisname;
         A4LugarId = obj15.gxTpr_Lugarid;
         A5LugarName = obj15.gxTpr_Lugarname;
         A7TipoEspectaculoId = obj15.gxTpr_Tipoespectaculoid;
         A8TipoEspectaculoName = obj15.gxTpr_Tipoespectaculoname;
         A26EspectaculoImagen = obj15.gxTpr_Espectaculoimagen;
         A40000EspectaculoImagen_GXI = obj15.gxTpr_Espectaculoimagen_gxi;
         A1EspectaculoId = obj15.gxTpr_Espectaculoid;
         Z1EspectaculoId = obj15.gxTpr_Espectaculoid_Z;
         Z2EspectaculoName = obj15.gxTpr_Espectaculoname_Z;
         Z16EspectaculoFecha = obj15.gxTpr_Espectaculofecha_Z;
         Z3PaisId = obj15.gxTpr_Paisid_Z;
         Z6PaisName = obj15.gxTpr_Paisname_Z;
         Z4LugarId = obj15.gxTpr_Lugarid_Z;
         Z5LugarName = obj15.gxTpr_Lugarname_Z;
         Z7TipoEspectaculoId = obj15.gxTpr_Tipoespectaculoid_Z;
         Z8TipoEspectaculoName = obj15.gxTpr_Tipoespectaculoname_Z;
         Z40000EspectaculoImagen_GXI = obj15.gxTpr_Espectaculoimagen_gxi_Z;
         Gx_mode = obj15.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow16( SdtEspectaculo_LugarSector obj16 )
      {
         obj16.gxTpr_Mode = Gx_mode;
         obj16.gxTpr_Lugarsectordisponibles = A38LugarSectorDisponibles;
         obj16.gxTpr_Lugarsectorname = A28LugarSectorName;
         obj16.gxTpr_Lugarsectorcantidad = A29LugarSectorCantidad;
         obj16.gxTpr_Lugarsectorestadosector = A41LugarSectorEstadoSector;
         obj16.gxTpr_Lugarsectorprecio = A30LugarSectorPrecio;
         obj16.gxTpr_Lugarsectorvendidas = A37LugarSectorVendidas;
         obj16.gxTpr_Lugarsectorid = A27LugarSectorId;
         obj16.gxTpr_Lugarsectorid_Z = Z27LugarSectorId;
         obj16.gxTpr_Lugarsectorname_Z = Z28LugarSectorName;
         obj16.gxTpr_Lugarsectorcantidad_Z = Z29LugarSectorCantidad;
         obj16.gxTpr_Lugarsectorestadosector_Z = Z41LugarSectorEstadoSector;
         obj16.gxTpr_Lugarsectorprecio_Z = Z30LugarSectorPrecio;
         obj16.gxTpr_Lugarsectorvendidas_Z = Z37LugarSectorVendidas;
         obj16.gxTpr_Lugarsectordisponibles_Z = Z38LugarSectorDisponibles;
         obj16.gxTpr_Lugarsectorvendidas_N = (short)(Convert.ToInt16(n37LugarSectorVendidas));
         obj16.gxTpr_Modified = nIsMod_16;
         return  ;
      }

      public void KeyVarsToRow16( SdtEspectaculo_LugarSector obj16 )
      {
         obj16.gxTpr_Lugarsectorid = A27LugarSectorId;
         return  ;
      }

      public void RowToVars16( SdtEspectaculo_LugarSector obj16 ,
                               int forceLoad )
      {
         Gx_mode = obj16.gxTpr_Mode;
         A38LugarSectorDisponibles = obj16.gxTpr_Lugarsectordisponibles;
         A28LugarSectorName = obj16.gxTpr_Lugarsectorname;
         A29LugarSectorCantidad = obj16.gxTpr_Lugarsectorcantidad;
         A41LugarSectorEstadoSector = obj16.gxTpr_Lugarsectorestadosector;
         A30LugarSectorPrecio = obj16.gxTpr_Lugarsectorprecio;
         A37LugarSectorVendidas = obj16.gxTpr_Lugarsectorvendidas;
         n37LugarSectorVendidas = false;
         A27LugarSectorId = obj16.gxTpr_Lugarsectorid;
         Z27LugarSectorId = obj16.gxTpr_Lugarsectorid_Z;
         Z28LugarSectorName = obj16.gxTpr_Lugarsectorname_Z;
         Z29LugarSectorCantidad = obj16.gxTpr_Lugarsectorcantidad_Z;
         Z41LugarSectorEstadoSector = obj16.gxTpr_Lugarsectorestadosector_Z;
         Z30LugarSectorPrecio = obj16.gxTpr_Lugarsectorprecio_Z;
         Z37LugarSectorVendidas = obj16.gxTpr_Lugarsectorvendidas_Z;
         Z38LugarSectorDisponibles = obj16.gxTpr_Lugarsectordisponibles_Z;
         n37LugarSectorVendidas = (bool)(Convert.ToBoolean(obj16.gxTpr_Lugarsectorvendidas_N));
         nIsMod_16 = obj16.gxTpr_Modified;
         return  ;
      }

      public void VarsToRow18( SdtEspectaculo_EspectaculoFuncion obj18 )
      {
         obj18.gxTpr_Mode = Gx_mode;
         obj18.gxTpr_Espectaculofuncionname = A48EspectaculoFuncionName;
         obj18.gxTpr_Espectaculofuncionprecio = A49EspectaculoFuncionPrecio;
         obj18.gxTpr_Espectaculofuncionid = A47EspectaculoFuncionId;
         obj18.gxTpr_Espectaculofuncionid_Z = Z47EspectaculoFuncionId;
         obj18.gxTpr_Espectaculofuncionname_Z = Z48EspectaculoFuncionName;
         obj18.gxTpr_Espectaculofuncionprecio_Z = Z49EspectaculoFuncionPrecio;
         obj18.gxTpr_Modified = nIsMod_18;
         return  ;
      }

      public void KeyVarsToRow18( SdtEspectaculo_EspectaculoFuncion obj18 )
      {
         obj18.gxTpr_Espectaculofuncionid = A47EspectaculoFuncionId;
         return  ;
      }

      public void RowToVars18( SdtEspectaculo_EspectaculoFuncion obj18 ,
                               int forceLoad )
      {
         Gx_mode = obj18.gxTpr_Mode;
         A48EspectaculoFuncionName = obj18.gxTpr_Espectaculofuncionname;
         A49EspectaculoFuncionPrecio = obj18.gxTpr_Espectaculofuncionprecio;
         A47EspectaculoFuncionId = obj18.gxTpr_Espectaculofuncionid;
         Z47EspectaculoFuncionId = obj18.gxTpr_Espectaculofuncionid_Z;
         Z48EspectaculoFuncionName = obj18.gxTpr_Espectaculofuncionname_Z;
         Z49EspectaculoFuncionPrecio = obj18.gxTpr_Espectaculofuncionprecio_Z;
         nIsMod_18 = obj18.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1EspectaculoId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0A15( ) ;
         ScanKeyStart0A15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1EspectaculoId = A1EspectaculoId;
         }
         ZM0A15( -3) ;
         OnLoadActions0A15( ) ;
         AddRow0A15( ) ;
         bcEspectaculo.gxTpr_Lugarsector.ClearCollection();
         if ( RcdFound15 == 1 )
         {
            ScanKeyStart0A16( ) ;
            nGXsfl_16_idx = 1;
            while ( RcdFound16 != 0 )
            {
               Z1EspectaculoId = A1EspectaculoId;
               Z27LugarSectorId = A27LugarSectorId;
               ZM0A16( -7) ;
               OnLoadActions0A16( ) ;
               nRcdExists_16 = 1;
               nIsMod_16 = 0;
               AddRow0A16( ) ;
               nGXsfl_16_idx = (int)(nGXsfl_16_idx+1);
               ScanKeyNext0A16( ) ;
            }
            ScanKeyEnd0A16( ) ;
         }
         bcEspectaculo.gxTpr_Espectaculofuncion.ClearCollection();
         if ( RcdFound15 == 1 )
         {
            ScanKeyStart0A18( ) ;
            nGXsfl_18_idx = 1;
            while ( RcdFound18 != 0 )
            {
               Z1EspectaculoId = A1EspectaculoId;
               Z47EspectaculoFuncionId = A47EspectaculoFuncionId;
               ZM0A18( -10) ;
               OnLoadActions0A18( ) ;
               nRcdExists_18 = 1;
               nIsMod_18 = 0;
               AddRow0A18( ) ;
               nGXsfl_18_idx = (int)(nGXsfl_18_idx+1);
               ScanKeyNext0A18( ) ;
            }
            ScanKeyEnd0A18( ) ;
         }
         ScanKeyEnd0A15( ) ;
         if ( RcdFound15 == 0 )
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
         RowToVars15( bcEspectaculo, 0) ;
         ScanKeyStart0A15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1EspectaculoId = A1EspectaculoId;
         }
         ZM0A15( -3) ;
         OnLoadActions0A15( ) ;
         AddRow0A15( ) ;
         bcEspectaculo.gxTpr_Lugarsector.ClearCollection();
         if ( RcdFound15 == 1 )
         {
            ScanKeyStart0A16( ) ;
            nGXsfl_16_idx = 1;
            while ( RcdFound16 != 0 )
            {
               Z1EspectaculoId = A1EspectaculoId;
               Z27LugarSectorId = A27LugarSectorId;
               ZM0A16( -7) ;
               OnLoadActions0A16( ) ;
               nRcdExists_16 = 1;
               nIsMod_16 = 0;
               AddRow0A16( ) ;
               nGXsfl_16_idx = (int)(nGXsfl_16_idx+1);
               ScanKeyNext0A16( ) ;
            }
            ScanKeyEnd0A16( ) ;
         }
         bcEspectaculo.gxTpr_Espectaculofuncion.ClearCollection();
         if ( RcdFound15 == 1 )
         {
            ScanKeyStart0A18( ) ;
            nGXsfl_18_idx = 1;
            while ( RcdFound18 != 0 )
            {
               Z1EspectaculoId = A1EspectaculoId;
               Z47EspectaculoFuncionId = A47EspectaculoFuncionId;
               ZM0A18( -10) ;
               OnLoadActions0A18( ) ;
               nRcdExists_18 = 1;
               nIsMod_18 = 0;
               AddRow0A18( ) ;
               nGXsfl_18_idx = (int)(nGXsfl_18_idx+1);
               ScanKeyNext0A18( ) ;
            }
            ScanKeyEnd0A18( ) ;
         }
         ScanKeyEnd0A15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0A15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0A15( ) ;
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A1EspectaculoId != Z1EspectaculoId )
               {
                  A1EspectaculoId = Z1EspectaculoId;
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
                  Update0A15( ) ;
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
                  if ( A1EspectaculoId != Z1EspectaculoId )
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
                        Insert0A15( ) ;
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
                        Insert0A15( ) ;
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
         RowToVars15( bcEspectaculo, 1) ;
         SaveImpl( ) ;
         VarsToRow15( bcEspectaculo) ;
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
         RowToVars15( bcEspectaculo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A15( ) ;
         AfterTrn( ) ;
         VarsToRow15( bcEspectaculo) ;
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
            SdtEspectaculo auxBC = new SdtEspectaculo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1EspectaculoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcEspectaculo);
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
         RowToVars15( bcEspectaculo, 1) ;
         UpdateImpl( ) ;
         VarsToRow15( bcEspectaculo) ;
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
         RowToVars15( bcEspectaculo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A15( ) ;
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
         VarsToRow15( bcEspectaculo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars15( bcEspectaculo, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0A15( ) ;
         if ( RcdFound15 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1EspectaculoId != Z1EspectaculoId )
            {
               A1EspectaculoId = Z1EspectaculoId;
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
            if ( A1EspectaculoId != Z1EspectaculoId )
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
         pr_default.close(7);
         pr_default.close(3);
         pr_default.close(1);
         pr_default.close(17);
         pr_default.close(19);
         pr_default.close(18);
         pr_default.close(28);
         pr_default.close(29);
         context.RollbackDataStores("espectaculo_bc",pr_default);
         VarsToRow15( bcEspectaculo) ;
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
         Gx_mode = bcEspectaculo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcEspectaculo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcEspectaculo )
         {
            bcEspectaculo = (SdtEspectaculo)(sdt);
            if ( StringUtil.StrCmp(bcEspectaculo.gxTpr_Mode, "") == 0 )
            {
               bcEspectaculo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow15( bcEspectaculo) ;
            }
            else
            {
               RowToVars15( bcEspectaculo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcEspectaculo.gxTpr_Mode, "") == 0 )
            {
               bcEspectaculo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars15( bcEspectaculo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtEspectaculo Espectaculo_BC
      {
         get {
            return bcEspectaculo ;
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
         pr_default.close(28);
         pr_default.close(29);
         pr_default.close(7);
         pr_default.close(17);
         pr_default.close(19);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode15 = "";
         Z2EspectaculoName = "";
         A2EspectaculoName = "";
         Z16EspectaculoFecha = DateTime.MinValue;
         A16EspectaculoFecha = DateTime.MinValue;
         Z5LugarName = "";
         A5LugarName = "";
         Z8TipoEspectaculoName = "";
         A8TipoEspectaculoName = "";
         Z6PaisName = "";
         A6PaisName = "";
         Z26EspectaculoImagen = "";
         A26EspectaculoImagen = "";
         Z40000EspectaculoImagen_GXI = "";
         A40000EspectaculoImagen_GXI = "";
         BC000A14_A1EspectaculoId = new short[1] ;
         BC000A14_A2EspectaculoName = new string[] {""} ;
         BC000A14_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         BC000A14_A6PaisName = new string[] {""} ;
         BC000A14_A5LugarName = new string[] {""} ;
         BC000A14_A8TipoEspectaculoName = new string[] {""} ;
         BC000A14_A40000EspectaculoImagen_GXI = new string[] {""} ;
         BC000A14_A4LugarId = new short[1] ;
         BC000A14_A7TipoEspectaculoId = new short[1] ;
         BC000A14_A3PaisId = new short[1] ;
         BC000A14_A26EspectaculoImagen = new string[] {""} ;
         BC000A11_A5LugarName = new string[] {""} ;
         BC000A11_A3PaisId = new short[1] ;
         BC000A13_A6PaisName = new string[] {""} ;
         BC000A12_A8TipoEspectaculoName = new string[] {""} ;
         BC000A15_A1EspectaculoId = new short[1] ;
         BC000A10_A1EspectaculoId = new short[1] ;
         BC000A10_A2EspectaculoName = new string[] {""} ;
         BC000A10_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         BC000A10_A40000EspectaculoImagen_GXI = new string[] {""} ;
         BC000A10_A4LugarId = new short[1] ;
         BC000A10_A7TipoEspectaculoId = new short[1] ;
         BC000A10_A26EspectaculoImagen = new string[] {""} ;
         BC000A9_A1EspectaculoId = new short[1] ;
         BC000A9_A2EspectaculoName = new string[] {""} ;
         BC000A9_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         BC000A9_A40000EspectaculoImagen_GXI = new string[] {""} ;
         BC000A9_A4LugarId = new short[1] ;
         BC000A9_A7TipoEspectaculoId = new short[1] ;
         BC000A9_A26EspectaculoImagen = new string[] {""} ;
         BC000A16_A1EspectaculoId = new short[1] ;
         BC000A20_A5LugarName = new string[] {""} ;
         BC000A20_A3PaisId = new short[1] ;
         BC000A21_A6PaisName = new string[] {""} ;
         BC000A22_A8TipoEspectaculoName = new string[] {""} ;
         BC000A23_A23EntradaId = new short[1] ;
         BC000A24_A23EntradaId = new short[1] ;
         BC000A25_A1EspectaculoId = new short[1] ;
         BC000A25_A2EspectaculoName = new string[] {""} ;
         BC000A25_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         BC000A25_A6PaisName = new string[] {""} ;
         BC000A25_A5LugarName = new string[] {""} ;
         BC000A25_A8TipoEspectaculoName = new string[] {""} ;
         BC000A25_A40000EspectaculoImagen_GXI = new string[] {""} ;
         BC000A25_A4LugarId = new short[1] ;
         BC000A25_A7TipoEspectaculoId = new short[1] ;
         BC000A25_A3PaisId = new short[1] ;
         BC000A25_A26EspectaculoImagen = new string[] {""} ;
         Z28LugarSectorName = "";
         A28LugarSectorName = "";
         BC000A27_A4LugarId = new short[1] ;
         BC000A27_A1EspectaculoId = new short[1] ;
         BC000A27_A28LugarSectorName = new string[] {""} ;
         BC000A27_A29LugarSectorCantidad = new short[1] ;
         BC000A27_A41LugarSectorEstadoSector = new bool[] {false} ;
         BC000A27_A30LugarSectorPrecio = new short[1] ;
         BC000A27_A27LugarSectorId = new short[1] ;
         BC000A27_A37LugarSectorVendidas = new short[1] ;
         BC000A27_n37LugarSectorVendidas = new bool[] {false} ;
         BC000A6_A28LugarSectorName = new string[] {""} ;
         BC000A6_A29LugarSectorCantidad = new short[1] ;
         BC000A6_A30LugarSectorPrecio = new short[1] ;
         BC000A8_A37LugarSectorVendidas = new short[1] ;
         BC000A8_n37LugarSectorVendidas = new bool[] {false} ;
         BC000A28_A1EspectaculoId = new short[1] ;
         BC000A28_A27LugarSectorId = new short[1] ;
         BC000A5_A1EspectaculoId = new short[1] ;
         BC000A5_A41LugarSectorEstadoSector = new bool[] {false} ;
         BC000A5_A27LugarSectorId = new short[1] ;
         sMode16 = "";
         BC000A4_A1EspectaculoId = new short[1] ;
         BC000A4_A41LugarSectorEstadoSector = new bool[] {false} ;
         BC000A4_A27LugarSectorId = new short[1] ;
         BC000A32_A28LugarSectorName = new string[] {""} ;
         BC000A32_A29LugarSectorCantidad = new short[1] ;
         BC000A32_A30LugarSectorPrecio = new short[1] ;
         BC000A34_A37LugarSectorVendidas = new short[1] ;
         BC000A34_n37LugarSectorVendidas = new bool[] {false} ;
         BC000A35_A24InvitacionId = new short[1] ;
         BC000A36_A23EntradaId = new short[1] ;
         BC000A38_A4LugarId = new short[1] ;
         BC000A38_A1EspectaculoId = new short[1] ;
         BC000A38_A28LugarSectorName = new string[] {""} ;
         BC000A38_A29LugarSectorCantidad = new short[1] ;
         BC000A38_A41LugarSectorEstadoSector = new bool[] {false} ;
         BC000A38_A30LugarSectorPrecio = new short[1] ;
         BC000A38_A27LugarSectorId = new short[1] ;
         BC000A38_A37LugarSectorVendidas = new short[1] ;
         BC000A38_n37LugarSectorVendidas = new bool[] {false} ;
         Z48EspectaculoFuncionName = "";
         A48EspectaculoFuncionName = "";
         BC000A39_A1EspectaculoId = new short[1] ;
         BC000A39_A47EspectaculoFuncionId = new short[1] ;
         BC000A39_A48EspectaculoFuncionName = new string[] {""} ;
         BC000A39_A49EspectaculoFuncionPrecio = new short[1] ;
         BC000A40_A1EspectaculoId = new short[1] ;
         BC000A40_A47EspectaculoFuncionId = new short[1] ;
         BC000A3_A1EspectaculoId = new short[1] ;
         BC000A3_A47EspectaculoFuncionId = new short[1] ;
         BC000A3_A48EspectaculoFuncionName = new string[] {""} ;
         BC000A3_A49EspectaculoFuncionPrecio = new short[1] ;
         sMode18 = "";
         BC000A2_A1EspectaculoId = new short[1] ;
         BC000A2_A47EspectaculoFuncionId = new short[1] ;
         BC000A2_A48EspectaculoFuncionName = new string[] {""} ;
         BC000A2_A49EspectaculoFuncionPrecio = new short[1] ;
         BC000A44_A23EntradaId = new short[1] ;
         BC000A45_A1EspectaculoId = new short[1] ;
         BC000A45_A47EspectaculoFuncionId = new short[1] ;
         BC000A45_A48EspectaculoFuncionName = new string[] {""} ;
         BC000A45_A49EspectaculoFuncionPrecio = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.espectaculo_bc__default(),
            new Object[][] {
                new Object[] {
               BC000A2_A1EspectaculoId, BC000A2_A47EspectaculoFuncionId, BC000A2_A48EspectaculoFuncionName, BC000A2_A49EspectaculoFuncionPrecio
               }
               , new Object[] {
               BC000A3_A1EspectaculoId, BC000A3_A47EspectaculoFuncionId, BC000A3_A48EspectaculoFuncionName, BC000A3_A49EspectaculoFuncionPrecio
               }
               , new Object[] {
               BC000A4_A1EspectaculoId, BC000A4_A41LugarSectorEstadoSector, BC000A4_A27LugarSectorId
               }
               , new Object[] {
               BC000A5_A1EspectaculoId, BC000A5_A41LugarSectorEstadoSector, BC000A5_A27LugarSectorId
               }
               , new Object[] {
               BC000A6_A28LugarSectorName, BC000A6_A29LugarSectorCantidad, BC000A6_A30LugarSectorPrecio
               }
               , new Object[] {
               BC000A8_A37LugarSectorVendidas, BC000A8_n37LugarSectorVendidas
               }
               , new Object[] {
               BC000A9_A1EspectaculoId, BC000A9_A2EspectaculoName, BC000A9_A16EspectaculoFecha, BC000A9_A40000EspectaculoImagen_GXI, BC000A9_A4LugarId, BC000A9_A7TipoEspectaculoId, BC000A9_A26EspectaculoImagen
               }
               , new Object[] {
               BC000A10_A1EspectaculoId, BC000A10_A2EspectaculoName, BC000A10_A16EspectaculoFecha, BC000A10_A40000EspectaculoImagen_GXI, BC000A10_A4LugarId, BC000A10_A7TipoEspectaculoId, BC000A10_A26EspectaculoImagen
               }
               , new Object[] {
               BC000A11_A5LugarName, BC000A11_A3PaisId
               }
               , new Object[] {
               BC000A12_A8TipoEspectaculoName
               }
               , new Object[] {
               BC000A13_A6PaisName
               }
               , new Object[] {
               BC000A14_A1EspectaculoId, BC000A14_A2EspectaculoName, BC000A14_A16EspectaculoFecha, BC000A14_A6PaisName, BC000A14_A5LugarName, BC000A14_A8TipoEspectaculoName, BC000A14_A40000EspectaculoImagen_GXI, BC000A14_A4LugarId, BC000A14_A7TipoEspectaculoId, BC000A14_A3PaisId,
               BC000A14_A26EspectaculoImagen
               }
               , new Object[] {
               BC000A15_A1EspectaculoId
               }
               , new Object[] {
               BC000A16_A1EspectaculoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000A20_A5LugarName, BC000A20_A3PaisId
               }
               , new Object[] {
               BC000A21_A6PaisName
               }
               , new Object[] {
               BC000A22_A8TipoEspectaculoName
               }
               , new Object[] {
               BC000A23_A23EntradaId
               }
               , new Object[] {
               BC000A24_A23EntradaId
               }
               , new Object[] {
               BC000A25_A1EspectaculoId, BC000A25_A2EspectaculoName, BC000A25_A16EspectaculoFecha, BC000A25_A6PaisName, BC000A25_A5LugarName, BC000A25_A8TipoEspectaculoName, BC000A25_A40000EspectaculoImagen_GXI, BC000A25_A4LugarId, BC000A25_A7TipoEspectaculoId, BC000A25_A3PaisId,
               BC000A25_A26EspectaculoImagen
               }
               , new Object[] {
               BC000A27_A4LugarId, BC000A27_A1EspectaculoId, BC000A27_A28LugarSectorName, BC000A27_A29LugarSectorCantidad, BC000A27_A41LugarSectorEstadoSector, BC000A27_A30LugarSectorPrecio, BC000A27_A27LugarSectorId, BC000A27_A37LugarSectorVendidas, BC000A27_n37LugarSectorVendidas
               }
               , new Object[] {
               BC000A28_A1EspectaculoId, BC000A28_A27LugarSectorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000A32_A28LugarSectorName, BC000A32_A29LugarSectorCantidad, BC000A32_A30LugarSectorPrecio
               }
               , new Object[] {
               BC000A34_A37LugarSectorVendidas, BC000A34_n37LugarSectorVendidas
               }
               , new Object[] {
               BC000A35_A24InvitacionId
               }
               , new Object[] {
               BC000A36_A23EntradaId
               }
               , new Object[] {
               BC000A38_A4LugarId, BC000A38_A1EspectaculoId, BC000A38_A28LugarSectorName, BC000A38_A29LugarSectorCantidad, BC000A38_A41LugarSectorEstadoSector, BC000A38_A30LugarSectorPrecio, BC000A38_A27LugarSectorId, BC000A38_A37LugarSectorVendidas, BC000A38_n37LugarSectorVendidas
               }
               , new Object[] {
               BC000A39_A1EspectaculoId, BC000A39_A47EspectaculoFuncionId, BC000A39_A48EspectaculoFuncionName, BC000A39_A49EspectaculoFuncionPrecio
               }
               , new Object[] {
               BC000A40_A1EspectaculoId, BC000A40_A47EspectaculoFuncionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000A44_A23EntradaId
               }
               , new Object[] {
               BC000A45_A1EspectaculoId, BC000A45_A47EspectaculoFuncionId, BC000A45_A48EspectaculoFuncionName, BC000A45_A49EspectaculoFuncionPrecio
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120A2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z1EspectaculoId ;
      private short A1EspectaculoId ;
      private short nIsMod_18 ;
      private short RcdFound18 ;
      private short nIsMod_16 ;
      private short RcdFound16 ;
      private short GX_JID ;
      private short Z4LugarId ;
      private short A4LugarId ;
      private short Z7TipoEspectaculoId ;
      private short A7TipoEspectaculoId ;
      private short Z3PaisId ;
      private short A3PaisId ;
      private short RcdFound15 ;
      private short nIsDirty_15 ;
      private short nRcdExists_16 ;
      private short Gxremove16 ;
      private short nRcdExists_18 ;
      private short Gxremove18 ;
      private short Z37LugarSectorVendidas ;
      private short A37LugarSectorVendidas ;
      private short Z38LugarSectorDisponibles ;
      private short A38LugarSectorDisponibles ;
      private short Z29LugarSectorCantidad ;
      private short A29LugarSectorCantidad ;
      private short Z30LugarSectorPrecio ;
      private short A30LugarSectorPrecio ;
      private short Z27LugarSectorId ;
      private short A27LugarSectorId ;
      private short nIsDirty_16 ;
      private short Gx_BScreen ;
      private short Z49EspectaculoFuncionPrecio ;
      private short A49EspectaculoFuncionPrecio ;
      private short Z47EspectaculoFuncionId ;
      private short A47EspectaculoFuncionId ;
      private short nIsDirty_18 ;
      private int trnEnded ;
      private int nGXsfl_18_idx=1 ;
      private int nGXsfl_16_idx=1 ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode15 ;
      private string sMode16 ;
      private string sMode18 ;
      private DateTime Z16EspectaculoFecha ;
      private DateTime A16EspectaculoFecha ;
      private bool returnInSub ;
      private bool Z41LugarSectorEstadoSector ;
      private bool A41LugarSectorEstadoSector ;
      private bool n37LugarSectorVendidas ;
      private bool mustCommit ;
      private string Z2EspectaculoName ;
      private string A2EspectaculoName ;
      private string Z5LugarName ;
      private string A5LugarName ;
      private string Z8TipoEspectaculoName ;
      private string A8TipoEspectaculoName ;
      private string Z6PaisName ;
      private string A6PaisName ;
      private string Z40000EspectaculoImagen_GXI ;
      private string A40000EspectaculoImagen_GXI ;
      private string Z28LugarSectorName ;
      private string A28LugarSectorName ;
      private string Z48EspectaculoFuncionName ;
      private string A48EspectaculoFuncionName ;
      private string Z26EspectaculoImagen ;
      private string A26EspectaculoImagen ;
      private SdtEspectaculo bcEspectaculo ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC000A14_A1EspectaculoId ;
      private string[] BC000A14_A2EspectaculoName ;
      private DateTime[] BC000A14_A16EspectaculoFecha ;
      private string[] BC000A14_A6PaisName ;
      private string[] BC000A14_A5LugarName ;
      private string[] BC000A14_A8TipoEspectaculoName ;
      private string[] BC000A14_A40000EspectaculoImagen_GXI ;
      private short[] BC000A14_A4LugarId ;
      private short[] BC000A14_A7TipoEspectaculoId ;
      private short[] BC000A14_A3PaisId ;
      private string[] BC000A14_A26EspectaculoImagen ;
      private string[] BC000A11_A5LugarName ;
      private short[] BC000A11_A3PaisId ;
      private string[] BC000A13_A6PaisName ;
      private string[] BC000A12_A8TipoEspectaculoName ;
      private short[] BC000A15_A1EspectaculoId ;
      private short[] BC000A10_A1EspectaculoId ;
      private string[] BC000A10_A2EspectaculoName ;
      private DateTime[] BC000A10_A16EspectaculoFecha ;
      private string[] BC000A10_A40000EspectaculoImagen_GXI ;
      private short[] BC000A10_A4LugarId ;
      private short[] BC000A10_A7TipoEspectaculoId ;
      private string[] BC000A10_A26EspectaculoImagen ;
      private short[] BC000A9_A1EspectaculoId ;
      private string[] BC000A9_A2EspectaculoName ;
      private DateTime[] BC000A9_A16EspectaculoFecha ;
      private string[] BC000A9_A40000EspectaculoImagen_GXI ;
      private short[] BC000A9_A4LugarId ;
      private short[] BC000A9_A7TipoEspectaculoId ;
      private string[] BC000A9_A26EspectaculoImagen ;
      private short[] BC000A16_A1EspectaculoId ;
      private string[] BC000A20_A5LugarName ;
      private short[] BC000A20_A3PaisId ;
      private string[] BC000A21_A6PaisName ;
      private string[] BC000A22_A8TipoEspectaculoName ;
      private short[] BC000A23_A23EntradaId ;
      private short[] BC000A24_A23EntradaId ;
      private short[] BC000A25_A1EspectaculoId ;
      private string[] BC000A25_A2EspectaculoName ;
      private DateTime[] BC000A25_A16EspectaculoFecha ;
      private string[] BC000A25_A6PaisName ;
      private string[] BC000A25_A5LugarName ;
      private string[] BC000A25_A8TipoEspectaculoName ;
      private string[] BC000A25_A40000EspectaculoImagen_GXI ;
      private short[] BC000A25_A4LugarId ;
      private short[] BC000A25_A7TipoEspectaculoId ;
      private short[] BC000A25_A3PaisId ;
      private string[] BC000A25_A26EspectaculoImagen ;
      private short[] BC000A27_A4LugarId ;
      private short[] BC000A27_A1EspectaculoId ;
      private string[] BC000A27_A28LugarSectorName ;
      private short[] BC000A27_A29LugarSectorCantidad ;
      private bool[] BC000A27_A41LugarSectorEstadoSector ;
      private short[] BC000A27_A30LugarSectorPrecio ;
      private short[] BC000A27_A27LugarSectorId ;
      private short[] BC000A27_A37LugarSectorVendidas ;
      private bool[] BC000A27_n37LugarSectorVendidas ;
      private string[] BC000A6_A28LugarSectorName ;
      private short[] BC000A6_A29LugarSectorCantidad ;
      private short[] BC000A6_A30LugarSectorPrecio ;
      private short[] BC000A8_A37LugarSectorVendidas ;
      private bool[] BC000A8_n37LugarSectorVendidas ;
      private short[] BC000A28_A1EspectaculoId ;
      private short[] BC000A28_A27LugarSectorId ;
      private short[] BC000A5_A1EspectaculoId ;
      private bool[] BC000A5_A41LugarSectorEstadoSector ;
      private short[] BC000A5_A27LugarSectorId ;
      private short[] BC000A4_A1EspectaculoId ;
      private bool[] BC000A4_A41LugarSectorEstadoSector ;
      private short[] BC000A4_A27LugarSectorId ;
      private string[] BC000A32_A28LugarSectorName ;
      private short[] BC000A32_A29LugarSectorCantidad ;
      private short[] BC000A32_A30LugarSectorPrecio ;
      private short[] BC000A34_A37LugarSectorVendidas ;
      private bool[] BC000A34_n37LugarSectorVendidas ;
      private short[] BC000A35_A24InvitacionId ;
      private short[] BC000A36_A23EntradaId ;
      private short[] BC000A38_A4LugarId ;
      private short[] BC000A38_A1EspectaculoId ;
      private string[] BC000A38_A28LugarSectorName ;
      private short[] BC000A38_A29LugarSectorCantidad ;
      private bool[] BC000A38_A41LugarSectorEstadoSector ;
      private short[] BC000A38_A30LugarSectorPrecio ;
      private short[] BC000A38_A27LugarSectorId ;
      private short[] BC000A38_A37LugarSectorVendidas ;
      private bool[] BC000A38_n37LugarSectorVendidas ;
      private short[] BC000A39_A1EspectaculoId ;
      private short[] BC000A39_A47EspectaculoFuncionId ;
      private string[] BC000A39_A48EspectaculoFuncionName ;
      private short[] BC000A39_A49EspectaculoFuncionPrecio ;
      private short[] BC000A40_A1EspectaculoId ;
      private short[] BC000A40_A47EspectaculoFuncionId ;
      private short[] BC000A3_A1EspectaculoId ;
      private short[] BC000A3_A47EspectaculoFuncionId ;
      private string[] BC000A3_A48EspectaculoFuncionName ;
      private short[] BC000A3_A49EspectaculoFuncionPrecio ;
      private short[] BC000A2_A1EspectaculoId ;
      private short[] BC000A2_A47EspectaculoFuncionId ;
      private string[] BC000A2_A48EspectaculoFuncionName ;
      private short[] BC000A2_A49EspectaculoFuncionPrecio ;
      private short[] BC000A44_A23EntradaId ;
      private short[] BC000A45_A1EspectaculoId ;
      private short[] BC000A45_A47EspectaculoFuncionId ;
      private string[] BC000A45_A48EspectaculoFuncionName ;
      private short[] BC000A45_A49EspectaculoFuncionPrecio ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class espectaculo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new UpdateCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new UpdateCursor(def[25])
         ,new UpdateCursor(def[26])
         ,new UpdateCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new UpdateCursor(def[35])
         ,new UpdateCursor(def[36])
         ,new UpdateCursor(def[37])
         ,new ForEachCursor(def[38])
         ,new ForEachCursor(def[39])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000A14;
          prmBC000A14 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000A11;
          prmBC000A11 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000A13;
          prmBC000A13 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000A12;
          prmBC000A12 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000A15;
          prmBC000A15 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000A10;
          prmBC000A10 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000A9;
          prmBC000A9 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000A16;
          prmBC000A16 = new Object[] {
          new ParDef("@EspectaculoName",GXType.NVarChar,40,0) ,
          new ParDef("@EspectaculoFecha",GXType.Date,8,0) ,
          new ParDef("@EspectaculoImagen",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@EspectaculoImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="Espectaculo", Fld="EspectaculoImagen"} ,
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000A17;
          prmBC000A17 = new Object[] {
          new ParDef("@EspectaculoName",GXType.NVarChar,40,0) ,
          new ParDef("@EspectaculoFecha",GXType.Date,8,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000A18;
          prmBC000A18 = new Object[] {
          new ParDef("@EspectaculoImagen",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@EspectaculoImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Espectaculo", Fld="EspectaculoImagen"} ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000A19;
          prmBC000A19 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000A20;
          prmBC000A20 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000A21;
          prmBC000A21 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000A22;
          prmBC000A22 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000A23;
          prmBC000A23 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000A24;
          prmBC000A24 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000A25;
          prmBC000A25 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000A27;
          prmBC000A27 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000A6;
          prmBC000A6 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000A8;
          prmBC000A8 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000A28;
          prmBC000A28 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000A5;
          prmBC000A5 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000A4;
          prmBC000A4 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000A29;
          prmBC000A29 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorEstadoSector",GXType.Boolean,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000A30;
          prmBC000A30 = new Object[] {
          new ParDef("@LugarSectorEstadoSector",GXType.Boolean,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000A31;
          prmBC000A31 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000A32;
          prmBC000A32 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000A34;
          prmBC000A34 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000A35;
          prmBC000A35 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000A36;
          prmBC000A36 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmBC000A38;
          prmBC000A38 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000A39;
          prmBC000A39 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmBC000A40;
          prmBC000A40 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmBC000A3;
          prmBC000A3 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmBC000A2;
          prmBC000A2 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmBC000A41;
          prmBC000A41 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionName",GXType.NVarChar,40,0) ,
          new ParDef("@EspectaculoFuncionPrecio",GXType.Int16,4,0)
          };
          Object[] prmBC000A42;
          prmBC000A42 = new Object[] {
          new ParDef("@EspectaculoFuncionName",GXType.NVarChar,40,0) ,
          new ParDef("@EspectaculoFuncionPrecio",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmBC000A43;
          prmBC000A43 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmBC000A44;
          prmBC000A44 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmBC000A45;
          prmBC000A45 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000A2", "SELECT [EspectaculoId], [EspectaculoFuncionId], [EspectaculoFuncionName], [EspectaculoFuncionPrecio] FROM [EspectaculoFuncion] WITH (UPDLOCK) WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoFuncionId] = @EspectaculoFuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A3", "SELECT [EspectaculoId], [EspectaculoFuncionId], [EspectaculoFuncionName], [EspectaculoFuncionPrecio] FROM [EspectaculoFuncion] WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoFuncionId] = @EspectaculoFuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A4", "SELECT [EspectaculoId], [LugarSectorEstadoSector], [LugarSectorId] FROM [EspectaculoLugarSector] WITH (UPDLOCK) WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A5", "SELECT [EspectaculoId], [LugarSectorEstadoSector], [LugarSectorId] FROM [EspectaculoLugarSector] WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A6", "SELECT [LugarSectorName], [LugarSectorCantidad], [LugarSectorPrecio] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A8", "SELECT COALESCE( T1.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (SELECT COUNT(*) AS LugarSectorVendidas, [EspectaculoId], [LugarSectorId] FROM [Entrada] GROUP BY [EspectaculoId], [LugarSectorId] ) T1 WHERE T1.[EspectaculoId] = @EspectaculoId AND T1.[LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A9", "SELECT [EspectaculoId], [EspectaculoName], [EspectaculoFecha], [EspectaculoImagen_GXI], [LugarId], [TipoEspectaculoId], [EspectaculoImagen] FROM [Espectaculo] WITH (UPDLOCK) WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A10", "SELECT [EspectaculoId], [EspectaculoName], [EspectaculoFecha], [EspectaculoImagen_GXI], [LugarId], [TipoEspectaculoId], [EspectaculoImagen] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A11", "SELECT [LugarName], [PaisId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A12", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A13", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A14", "SELECT TM1.[EspectaculoId], TM1.[EspectaculoName], TM1.[EspectaculoFecha], T3.[PaisName], T2.[LugarName], T4.[TipoEspectaculoName], TM1.[EspectaculoImagen_GXI], TM1.[LugarId], TM1.[TipoEspectaculoId], T2.[PaisId], TM1.[EspectaculoImagen] FROM ((([Espectaculo] TM1 INNER JOIN [Lugar] T2 ON T2.[LugarId] = TM1.[LugarId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = T2.[PaisId]) INNER JOIN [TipoEspectaculo] T4 ON T4.[TipoEspectaculoId] = TM1.[TipoEspectaculoId]) WHERE TM1.[EspectaculoId] = @EspectaculoId ORDER BY TM1.[EspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A15", "SELECT [EspectaculoId] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A16", "INSERT INTO [Espectaculo]([EspectaculoName], [EspectaculoFecha], [EspectaculoImagen], [EspectaculoImagen_GXI], [LugarId], [TipoEspectaculoId]) VALUES(@EspectaculoName, @EspectaculoFecha, @EspectaculoImagen, @EspectaculoImagen_GXI, @LugarId, @TipoEspectaculoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A16,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000A17", "UPDATE [Espectaculo] SET [EspectaculoName]=@EspectaculoName, [EspectaculoFecha]=@EspectaculoFecha, [LugarId]=@LugarId, [TipoEspectaculoId]=@TipoEspectaculoId  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmBC000A17)
             ,new CursorDef("BC000A18", "UPDATE [Espectaculo] SET [EspectaculoImagen]=@EspectaculoImagen, [EspectaculoImagen_GXI]=@EspectaculoImagen_GXI  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmBC000A18)
             ,new CursorDef("BC000A19", "DELETE FROM [Espectaculo]  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmBC000A19)
             ,new CursorDef("BC000A20", "SELECT [LugarName], [PaisId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A21", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A22", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A22,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A23", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A23,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000A24", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A24,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000A25", "SELECT TM1.[EspectaculoId], TM1.[EspectaculoName], TM1.[EspectaculoFecha], T3.[PaisName], T2.[LugarName], T4.[TipoEspectaculoName], TM1.[EspectaculoImagen_GXI], TM1.[LugarId], TM1.[TipoEspectaculoId], T2.[PaisId], TM1.[EspectaculoImagen] FROM ((([Espectaculo] TM1 INNER JOIN [Lugar] T2 ON T2.[LugarId] = TM1.[LugarId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = T2.[PaisId]) INNER JOIN [TipoEspectaculo] T4 ON T4.[TipoEspectaculoId] = TM1.[TipoEspectaculoId]) WHERE TM1.[EspectaculoId] = @EspectaculoId ORDER BY TM1.[EspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A25,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A27", "SELECT T2.[LugarId], T1.[EspectaculoId], T2.[LugarSectorName], T2.[LugarSectorCantidad], T1.[LugarSectorEstadoSector], T2.[LugarSectorPrecio], T1.[LugarSectorId], COALESCE( T3.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (([EspectaculoLugarSector] T1 LEFT JOIN [LugarSector] T2 ON T2.[LugarId] = @LugarId AND T2.[LugarSectorId] = T1.[LugarSectorId]) LEFT JOIN (SELECT COUNT(*) AS LugarSectorVendidas, [EspectaculoId], [LugarSectorId] FROM [Entrada] GROUP BY [EspectaculoId], [LugarSectorId] ) T3 ON T3.[EspectaculoId] = T1.[EspectaculoId] AND T3.[LugarSectorId] = T1.[LugarSectorId]) WHERE T1.[EspectaculoId] = @EspectaculoId and T1.[LugarSectorId] = @LugarSectorId ORDER BY T1.[EspectaculoId], T1.[LugarSectorId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A27,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A28", "SELECT [EspectaculoId], [LugarSectorId] FROM [EspectaculoLugarSector] WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A28,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A29", "INSERT INTO [EspectaculoLugarSector]([EspectaculoId], [LugarSectorEstadoSector], [LugarSectorId]) VALUES(@EspectaculoId, @LugarSectorEstadoSector, @LugarSectorId)", GxErrorMask.GX_NOMASK,prmBC000A29)
             ,new CursorDef("BC000A30", "UPDATE [EspectaculoLugarSector] SET [LugarSectorEstadoSector]=@LugarSectorEstadoSector  WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId", GxErrorMask.GX_NOMASK,prmBC000A30)
             ,new CursorDef("BC000A31", "DELETE FROM [EspectaculoLugarSector]  WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId", GxErrorMask.GX_NOMASK,prmBC000A31)
             ,new CursorDef("BC000A32", "SELECT [LugarSectorName], [LugarSectorCantidad], [LugarSectorPrecio] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A32,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A34", "SELECT COALESCE( T1.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (SELECT COUNT(*) AS LugarSectorVendidas, [EspectaculoId], [LugarSectorId] FROM [Entrada] GROUP BY [EspectaculoId], [LugarSectorId] ) T1 WHERE T1.[EspectaculoId] = @EspectaculoId AND T1.[LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A34,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A35", "SELECT TOP 1 [InvitacionId] FROM [Invitacion] WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A35,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000A36", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A36,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000A38", "SELECT T2.[LugarId], T1.[EspectaculoId], T2.[LugarSectorName], T2.[LugarSectorCantidad], T1.[LugarSectorEstadoSector], T2.[LugarSectorPrecio], T1.[LugarSectorId], COALESCE( T3.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (([EspectaculoLugarSector] T1 LEFT JOIN [LugarSector] T2 ON T2.[LugarId] = @LugarId AND T2.[LugarSectorId] = T1.[LugarSectorId]) LEFT JOIN (SELECT COUNT(*) AS LugarSectorVendidas, [EspectaculoId], [LugarSectorId] FROM [Entrada] GROUP BY [EspectaculoId], [LugarSectorId] ) T3 ON T3.[EspectaculoId] = T1.[EspectaculoId] AND T3.[LugarSectorId] = T1.[LugarSectorId]) WHERE T1.[EspectaculoId] = @EspectaculoId ORDER BY T1.[EspectaculoId], T1.[LugarSectorId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A38,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A39", "SELECT [EspectaculoId], [EspectaculoFuncionId], [EspectaculoFuncionName], [EspectaculoFuncionPrecio] FROM [EspectaculoFuncion] WHERE [EspectaculoId] = @EspectaculoId and [EspectaculoFuncionId] = @EspectaculoFuncionId ORDER BY [EspectaculoId], [EspectaculoFuncionId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A39,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A40", "SELECT [EspectaculoId], [EspectaculoFuncionId] FROM [EspectaculoFuncion] WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoFuncionId] = @EspectaculoFuncionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A40,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000A41", "INSERT INTO [EspectaculoFuncion]([EspectaculoId], [EspectaculoFuncionId], [EspectaculoFuncionName], [EspectaculoFuncionPrecio]) VALUES(@EspectaculoId, @EspectaculoFuncionId, @EspectaculoFuncionName, @EspectaculoFuncionPrecio)", GxErrorMask.GX_NOMASK,prmBC000A41)
             ,new CursorDef("BC000A42", "UPDATE [EspectaculoFuncion] SET [EspectaculoFuncionName]=@EspectaculoFuncionName, [EspectaculoFuncionPrecio]=@EspectaculoFuncionPrecio  WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoFuncionId] = @EspectaculoFuncionId", GxErrorMask.GX_NOMASK,prmBC000A42)
             ,new CursorDef("BC000A43", "DELETE FROM [EspectaculoFuncion]  WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoFuncionId] = @EspectaculoFuncionId", GxErrorMask.GX_NOMASK,prmBC000A43)
             ,new CursorDef("BC000A44", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoFuncionId] = @EspectaculoFuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A44,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000A45", "SELECT [EspectaculoId], [EspectaculoFuncionId], [EspectaculoFuncionName], [EspectaculoFuncionPrecio] FROM [EspectaculoFuncion] WHERE [EspectaculoId] = @EspectaculoId ORDER BY [EspectaculoId], [EspectaculoFuncionId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A45,11, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(4));
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(4));
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(7));
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(7));
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 28 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 29 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 31 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 32 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 33 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 34 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 38 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 39 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
