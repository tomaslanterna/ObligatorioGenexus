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
   public class entrada_bc : GXHttpHandler, IGxSilentTrn
   {
      public entrada_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public entrada_bc( IGxContext context )
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
         ReadRow089( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey089( ) ;
         standaloneModal( ) ;
         AddRow089( ) ;
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
            E11082 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z23EntradaId = A23EntradaId;
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

      protected void CONFIRM_080( )
      {
         BeforeValidate089( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls089( ) ;
            }
            else
            {
               CheckExtendedTable089( ) ;
               if ( AnyError == 0 )
               {
                  ZM089( 7) ;
                  ZM089( 8) ;
                  ZM089( 9) ;
                  ZM089( 10) ;
                  ZM089( 11) ;
                  ZM089( 12) ;
                  ZM089( 13) ;
                  ZM089( 14) ;
                  ZM089( 15) ;
               }
               CloseExtendedTableCursors089( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12082( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11082( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM089( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z42EntradaFecha = A42EntradaFecha;
            Z50EspectaculoPaisName = A50EspectaculoPaisName;
            Z9ClienteId = A9ClienteId;
            Z1EspectaculoId = A1EspectaculoId;
            Z27LugarSectorId = A27LugarSectorId;
            Z47EspectaculoFuncionId = A47EspectaculoFuncionId;
            Z38LugarSectorDisponibles = A38LugarSectorDisponibles;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z10ClienteName = A10ClienteName;
            Z3PaisId = A3PaisId;
            Z38LugarSectorDisponibles = A38LugarSectorDisponibles;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z4LugarId = A4LugarId;
            Z7TipoEspectaculoId = A7TipoEspectaculoId;
            Z2EspectaculoName = A2EspectaculoName;
            Z16EspectaculoFecha = A16EspectaculoFecha;
            Z38LugarSectorDisponibles = A38LugarSectorDisponibles;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z38LugarSectorDisponibles = A38LugarSectorDisponibles;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z48EspectaculoFuncionName = A48EspectaculoFuncionName;
            Z38LugarSectorDisponibles = A38LugarSectorDisponibles;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z6PaisName = A6PaisName;
            Z38LugarSectorDisponibles = A38LugarSectorDisponibles;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z5LugarName = A5LugarName;
            Z38LugarSectorDisponibles = A38LugarSectorDisponibles;
         }
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z8TipoEspectaculoName = A8TipoEspectaculoName;
            Z38LugarSectorDisponibles = A38LugarSectorDisponibles;
         }
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z28LugarSectorName = A28LugarSectorName;
            Z30LugarSectorPrecio = A30LugarSectorPrecio;
            Z29LugarSectorCantidad = A29LugarSectorCantidad;
            Z38LugarSectorDisponibles = A38LugarSectorDisponibles;
         }
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z38LugarSectorDisponibles = A38LugarSectorDisponibles;
         }
         if ( GX_JID == -6 )
         {
            Z23EntradaId = A23EntradaId;
            Z42EntradaFecha = A42EntradaFecha;
            Z50EspectaculoPaisName = A50EspectaculoPaisName;
            Z9ClienteId = A9ClienteId;
            Z1EspectaculoId = A1EspectaculoId;
            Z27LugarSectorId = A27LugarSectorId;
            Z47EspectaculoFuncionId = A47EspectaculoFuncionId;
            Z10ClienteName = A10ClienteName;
            Z3PaisId = A3PaisId;
            Z6PaisName = A6PaisName;
            Z4LugarId = A4LugarId;
            Z7TipoEspectaculoId = A7TipoEspectaculoId;
            Z2EspectaculoName = A2EspectaculoName;
            Z16EspectaculoFecha = A16EspectaculoFecha;
            Z26EspectaculoImagen = A26EspectaculoImagen;
            Z40000EspectaculoImagen_GXI = A40000EspectaculoImagen_GXI;
            Z5LugarName = A5LugarName;
            Z8TipoEspectaculoName = A8TipoEspectaculoName;
            Z48EspectaculoFuncionName = A48EspectaculoFuncionName;
            Z28LugarSectorName = A28LugarSectorName;
            Z30LugarSectorPrecio = A30LugarSectorPrecio;
            Z29LugarSectorCantidad = A29LugarSectorCantidad;
            Z37LugarSectorVendidas = A37LugarSectorVendidas;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load089( )
      {
         /* Using cursor BC000815 */
         pr_default.execute(11, new Object[] {A23EntradaId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound9 = 1;
            A4LugarId = BC000815_A4LugarId[0];
            A7TipoEspectaculoId = BC000815_A7TipoEspectaculoId[0];
            A42EntradaFecha = BC000815_A42EntradaFecha[0];
            A6PaisName = BC000815_A6PaisName[0];
            A10ClienteName = BC000815_A10ClienteName[0];
            A2EspectaculoName = BC000815_A2EspectaculoName[0];
            A16EspectaculoFecha = BC000815_A16EspectaculoFecha[0];
            A48EspectaculoFuncionName = BC000815_A48EspectaculoFuncionName[0];
            A40000EspectaculoImagen_GXI = BC000815_A40000EspectaculoImagen_GXI[0];
            A50EspectaculoPaisName = BC000815_A50EspectaculoPaisName[0];
            A5LugarName = BC000815_A5LugarName[0];
            A28LugarSectorName = BC000815_A28LugarSectorName[0];
            A30LugarSectorPrecio = BC000815_A30LugarSectorPrecio[0];
            A8TipoEspectaculoName = BC000815_A8TipoEspectaculoName[0];
            A29LugarSectorCantidad = BC000815_A29LugarSectorCantidad[0];
            A9ClienteId = BC000815_A9ClienteId[0];
            A1EspectaculoId = BC000815_A1EspectaculoId[0];
            n1EspectaculoId = BC000815_n1EspectaculoId[0];
            A27LugarSectorId = BC000815_A27LugarSectorId[0];
            n27LugarSectorId = BC000815_n27LugarSectorId[0];
            A47EspectaculoFuncionId = BC000815_A47EspectaculoFuncionId[0];
            A3PaisId = BC000815_A3PaisId[0];
            A37LugarSectorVendidas = BC000815_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = BC000815_n37LugarSectorVendidas[0];
            A26EspectaculoImagen = BC000815_A26EspectaculoImagen[0];
            ZM089( -6) ;
         }
         pr_default.close(11);
         OnLoadActions089( ) ;
      }

      protected void OnLoadActions089( )
      {
         A38LugarSectorDisponibles = (short)(A29LugarSectorCantidad-A37LugarSectorVendidas);
      }

      protected void CheckExtendedTable089( )
      {
         nIsDirty_9 = 0;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A42EntradaFecha) || ( DateTimeUtil.ResetTime ( A42EntradaFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Entrada Fecha fuera de rango", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00084 */
         pr_default.execute(2, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
         }
         A10ClienteName = BC00084_A10ClienteName[0];
         A3PaisId = BC00084_A3PaisId[0];
         pr_default.close(2);
         /* Using cursor BC00088 */
         pr_default.execute(6, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = BC00088_A6PaisName[0];
         pr_default.close(6);
         /* Using cursor BC00085 */
         pr_default.execute(3, new Object[] {n1EspectaculoId, A1EspectaculoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
         }
         A4LugarId = BC00085_A4LugarId[0];
         A7TipoEspectaculoId = BC00085_A7TipoEspectaculoId[0];
         A2EspectaculoName = BC00085_A2EspectaculoName[0];
         A16EspectaculoFecha = BC00085_A16EspectaculoFecha[0];
         A40000EspectaculoImagen_GXI = BC00085_A40000EspectaculoImagen_GXI[0];
         A26EspectaculoImagen = BC00085_A26EspectaculoImagen[0];
         pr_default.close(3);
         /* Using cursor BC00089 */
         pr_default.execute(7, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
         }
         A5LugarName = BC00089_A5LugarName[0];
         pr_default.close(7);
         /* Using cursor BC000811 */
         pr_default.execute(9, new Object[] {A4LugarId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "LUGARSECTORID");
            AnyError = 1;
         }
         A28LugarSectorName = BC000811_A28LugarSectorName[0];
         A30LugarSectorPrecio = BC000811_A30LugarSectorPrecio[0];
         A29LugarSectorCantidad = BC000811_A29LugarSectorCantidad[0];
         pr_default.close(9);
         /* Using cursor BC000810 */
         pr_default.execute(8, new Object[] {A7TipoEspectaculoId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
         }
         A8TipoEspectaculoName = BC000810_A8TipoEspectaculoName[0];
         pr_default.close(8);
         if ( DateTimeUtil.ResetTime ( A42EntradaFecha ) > DateTimeUtil.ResetTime ( A16EspectaculoFecha ) )
         {
            GX_msglist.addItem("Fecha invalida", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00086 */
         pr_default.execute(4, new Object[] {n1EspectaculoId, A1EspectaculoId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar Sector'.", "ForeignKeyNotFound", 1, "LUGARSECTORID");
            AnyError = 1;
         }
         pr_default.close(4);
         /* Using cursor BC00087 */
         pr_default.execute(5, new Object[] {n1EspectaculoId, A1EspectaculoId, A47EspectaculoFuncionId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Funcion'.", "ForeignKeyNotFound", 1, "ESPECTACULOFUNCIONID");
            AnyError = 1;
         }
         A48EspectaculoFuncionName = BC00087_A48EspectaculoFuncionName[0];
         pr_default.close(5);
         /* Using cursor BC000813 */
         pr_default.execute(10, new Object[] {n1EspectaculoId, A1EspectaculoId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A37LugarSectorVendidas = BC000813_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = BC000813_n37LugarSectorVendidas[0];
         }
         else
         {
            nIsDirty_9 = 1;
            A37LugarSectorVendidas = 0;
            n37LugarSectorVendidas = false;
         }
         pr_default.close(10);
         nIsDirty_9 = 1;
         A38LugarSectorDisponibles = (short)(A29LugarSectorCantidad-A37LugarSectorVendidas);
         if ( A38LugarSectorDisponibles < 1 )
         {
            GX_msglist.addItem("No hay lugares disponibles", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors089( )
      {
         pr_default.close(2);
         pr_default.close(6);
         pr_default.close(3);
         pr_default.close(7);
         pr_default.close(9);
         pr_default.close(8);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(10);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey089( )
      {
         /* Using cursor BC000816 */
         pr_default.execute(12, new Object[] {A23EntradaId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(12);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00083 */
         pr_default.execute(1, new Object[] {A23EntradaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM089( 6) ;
            RcdFound9 = 1;
            A23EntradaId = BC00083_A23EntradaId[0];
            A42EntradaFecha = BC00083_A42EntradaFecha[0];
            A50EspectaculoPaisName = BC00083_A50EspectaculoPaisName[0];
            A9ClienteId = BC00083_A9ClienteId[0];
            A1EspectaculoId = BC00083_A1EspectaculoId[0];
            n1EspectaculoId = BC00083_n1EspectaculoId[0];
            A27LugarSectorId = BC00083_A27LugarSectorId[0];
            n27LugarSectorId = BC00083_n27LugarSectorId[0];
            A47EspectaculoFuncionId = BC00083_A47EspectaculoFuncionId[0];
            Z23EntradaId = A23EntradaId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load089( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey089( ) ;
            }
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey089( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode9;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey089( ) ;
         if ( RcdFound9 == 0 )
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
         CONFIRM_080( ) ;
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

      protected void CheckOptimisticConcurrency089( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00082 */
            pr_default.execute(0, new Object[] {A23EntradaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Entrada"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z42EntradaFecha ) != DateTimeUtil.ResetTime ( BC00082_A42EntradaFecha[0] ) ) || ( StringUtil.StrCmp(Z50EspectaculoPaisName, BC00082_A50EspectaculoPaisName[0]) != 0 ) || ( Z9ClienteId != BC00082_A9ClienteId[0] ) || ( Z1EspectaculoId != BC00082_A1EspectaculoId[0] ) || ( Z27LugarSectorId != BC00082_A27LugarSectorId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z47EspectaculoFuncionId != BC00082_A47EspectaculoFuncionId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Entrada"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert089( )
      {
         BeforeValidate089( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable089( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM089( 0) ;
            CheckOptimisticConcurrency089( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm089( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert089( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000817 */
                     pr_default.execute(13, new Object[] {A42EntradaFecha, A50EspectaculoPaisName, A9ClienteId, n1EspectaculoId, A1EspectaculoId, n27LugarSectorId, A27LugarSectorId, A47EspectaculoFuncionId});
                     A23EntradaId = BC000817_A23EntradaId[0];
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("Entrada");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
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
               Load089( ) ;
            }
            EndLevel089( ) ;
         }
         CloseExtendedTableCursors089( ) ;
      }

      protected void Update089( )
      {
         BeforeValidate089( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable089( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency089( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm089( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate089( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000818 */
                     pr_default.execute(14, new Object[] {A42EntradaFecha, A50EspectaculoPaisName, A9ClienteId, n1EspectaculoId, A1EspectaculoId, n27LugarSectorId, A27LugarSectorId, A47EspectaculoFuncionId, A23EntradaId});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("Entrada");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Entrada"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate089( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
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
            EndLevel089( ) ;
         }
         CloseExtendedTableCursors089( ) ;
      }

      protected void DeferredUpdate089( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate089( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency089( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls089( ) ;
            AfterConfirm089( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete089( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000819 */
                  pr_default.execute(15, new Object[] {A23EntradaId});
                  pr_default.close(15);
                  dsDefault.SmartCacheProvider.SetUpdated("Entrada");
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel089( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls089( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000820 */
            pr_default.execute(16, new Object[] {A9ClienteId});
            A10ClienteName = BC000820_A10ClienteName[0];
            A3PaisId = BC000820_A3PaisId[0];
            pr_default.close(16);
            /* Using cursor BC000821 */
            pr_default.execute(17, new Object[] {A3PaisId});
            A6PaisName = BC000821_A6PaisName[0];
            pr_default.close(17);
            /* Using cursor BC000822 */
            pr_default.execute(18, new Object[] {n1EspectaculoId, A1EspectaculoId});
            A4LugarId = BC000822_A4LugarId[0];
            A7TipoEspectaculoId = BC000822_A7TipoEspectaculoId[0];
            A2EspectaculoName = BC000822_A2EspectaculoName[0];
            A16EspectaculoFecha = BC000822_A16EspectaculoFecha[0];
            A40000EspectaculoImagen_GXI = BC000822_A40000EspectaculoImagen_GXI[0];
            A26EspectaculoImagen = BC000822_A26EspectaculoImagen[0];
            pr_default.close(18);
            /* Using cursor BC000823 */
            pr_default.execute(19, new Object[] {A4LugarId});
            A5LugarName = BC000823_A5LugarName[0];
            pr_default.close(19);
            /* Using cursor BC000824 */
            pr_default.execute(20, new Object[] {A7TipoEspectaculoId});
            A8TipoEspectaculoName = BC000824_A8TipoEspectaculoName[0];
            pr_default.close(20);
            /* Using cursor BC000825 */
            pr_default.execute(21, new Object[] {n1EspectaculoId, A1EspectaculoId, A47EspectaculoFuncionId});
            A48EspectaculoFuncionName = BC000825_A48EspectaculoFuncionName[0];
            pr_default.close(21);
            /* Using cursor BC000826 */
            pr_default.execute(22, new Object[] {A4LugarId, n27LugarSectorId, A27LugarSectorId});
            A28LugarSectorName = BC000826_A28LugarSectorName[0];
            A30LugarSectorPrecio = BC000826_A30LugarSectorPrecio[0];
            A29LugarSectorCantidad = BC000826_A29LugarSectorCantidad[0];
            pr_default.close(22);
            /* Using cursor BC000828 */
            pr_default.execute(23, new Object[] {n1EspectaculoId, A1EspectaculoId, n27LugarSectorId, A27LugarSectorId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               A37LugarSectorVendidas = BC000828_A37LugarSectorVendidas[0];
               n37LugarSectorVendidas = BC000828_n37LugarSectorVendidas[0];
            }
            else
            {
               A37LugarSectorVendidas = 0;
               n37LugarSectorVendidas = false;
            }
            pr_default.close(23);
            A38LugarSectorDisponibles = (short)(A29LugarSectorCantidad-A37LugarSectorVendidas);
         }
      }

      protected void EndLevel089( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete089( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            if ( IsIns( )  || IsUpd( )  )
            {
               CallWebObject(formatLink("aimpresionentrada.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A23EntradaId,4,0))}, new string[] {"EntradaId"}) );
               context.wjLocDisableFrm = 2;
            }
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

      public void ScanKeyStart089( )
      {
         /* Scan By routine */
         /* Using cursor BC000830 */
         pr_default.execute(24, new Object[] {A23EntradaId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound9 = 1;
            A4LugarId = BC000830_A4LugarId[0];
            A7TipoEspectaculoId = BC000830_A7TipoEspectaculoId[0];
            A23EntradaId = BC000830_A23EntradaId[0];
            A42EntradaFecha = BC000830_A42EntradaFecha[0];
            A6PaisName = BC000830_A6PaisName[0];
            A10ClienteName = BC000830_A10ClienteName[0];
            A2EspectaculoName = BC000830_A2EspectaculoName[0];
            A16EspectaculoFecha = BC000830_A16EspectaculoFecha[0];
            A48EspectaculoFuncionName = BC000830_A48EspectaculoFuncionName[0];
            A40000EspectaculoImagen_GXI = BC000830_A40000EspectaculoImagen_GXI[0];
            A50EspectaculoPaisName = BC000830_A50EspectaculoPaisName[0];
            A5LugarName = BC000830_A5LugarName[0];
            A28LugarSectorName = BC000830_A28LugarSectorName[0];
            A30LugarSectorPrecio = BC000830_A30LugarSectorPrecio[0];
            A8TipoEspectaculoName = BC000830_A8TipoEspectaculoName[0];
            A29LugarSectorCantidad = BC000830_A29LugarSectorCantidad[0];
            A9ClienteId = BC000830_A9ClienteId[0];
            A1EspectaculoId = BC000830_A1EspectaculoId[0];
            n1EspectaculoId = BC000830_n1EspectaculoId[0];
            A27LugarSectorId = BC000830_A27LugarSectorId[0];
            n27LugarSectorId = BC000830_n27LugarSectorId[0];
            A47EspectaculoFuncionId = BC000830_A47EspectaculoFuncionId[0];
            A3PaisId = BC000830_A3PaisId[0];
            A37LugarSectorVendidas = BC000830_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = BC000830_n37LugarSectorVendidas[0];
            A26EspectaculoImagen = BC000830_A26EspectaculoImagen[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext089( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound9 = 0;
         ScanKeyLoad089( ) ;
      }

      protected void ScanKeyLoad089( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound9 = 1;
            A4LugarId = BC000830_A4LugarId[0];
            A7TipoEspectaculoId = BC000830_A7TipoEspectaculoId[0];
            A23EntradaId = BC000830_A23EntradaId[0];
            A42EntradaFecha = BC000830_A42EntradaFecha[0];
            A6PaisName = BC000830_A6PaisName[0];
            A10ClienteName = BC000830_A10ClienteName[0];
            A2EspectaculoName = BC000830_A2EspectaculoName[0];
            A16EspectaculoFecha = BC000830_A16EspectaculoFecha[0];
            A48EspectaculoFuncionName = BC000830_A48EspectaculoFuncionName[0];
            A40000EspectaculoImagen_GXI = BC000830_A40000EspectaculoImagen_GXI[0];
            A50EspectaculoPaisName = BC000830_A50EspectaculoPaisName[0];
            A5LugarName = BC000830_A5LugarName[0];
            A28LugarSectorName = BC000830_A28LugarSectorName[0];
            A30LugarSectorPrecio = BC000830_A30LugarSectorPrecio[0];
            A8TipoEspectaculoName = BC000830_A8TipoEspectaculoName[0];
            A29LugarSectorCantidad = BC000830_A29LugarSectorCantidad[0];
            A9ClienteId = BC000830_A9ClienteId[0];
            A1EspectaculoId = BC000830_A1EspectaculoId[0];
            n1EspectaculoId = BC000830_n1EspectaculoId[0];
            A27LugarSectorId = BC000830_A27LugarSectorId[0];
            n27LugarSectorId = BC000830_n27LugarSectorId[0];
            A47EspectaculoFuncionId = BC000830_A47EspectaculoFuncionId[0];
            A3PaisId = BC000830_A3PaisId[0];
            A37LugarSectorVendidas = BC000830_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = BC000830_n37LugarSectorVendidas[0];
            A26EspectaculoImagen = BC000830_A26EspectaculoImagen[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd089( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm089( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert089( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate089( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete089( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete089( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate089( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes089( )
      {
      }

      protected void send_integrity_lvl_hashes089( )
      {
      }

      protected void AddRow089( )
      {
         VarsToRow9( bcEntrada) ;
      }

      protected void ReadRow089( )
      {
         RowToVars9( bcEntrada, 1) ;
      }

      protected void InitializeNonKey089( )
      {
         A7TipoEspectaculoId = 0;
         A4LugarId = 0;
         A38LugarSectorDisponibles = 0;
         A42EntradaFecha = DateTime.MinValue;
         A3PaisId = 0;
         A6PaisName = "";
         A9ClienteId = 0;
         A10ClienteName = "";
         A1EspectaculoId = 0;
         n1EspectaculoId = false;
         A2EspectaculoName = "";
         A16EspectaculoFecha = DateTime.MinValue;
         A47EspectaculoFuncionId = 0;
         A48EspectaculoFuncionName = "";
         A26EspectaculoImagen = "";
         A40000EspectaculoImagen_GXI = "";
         A50EspectaculoPaisName = "";
         A5LugarName = "";
         A27LugarSectorId = 0;
         n27LugarSectorId = false;
         A28LugarSectorName = "";
         A30LugarSectorPrecio = 0;
         A8TipoEspectaculoName = "";
         A29LugarSectorCantidad = 0;
         A37LugarSectorVendidas = 0;
         n37LugarSectorVendidas = false;
         Z42EntradaFecha = DateTime.MinValue;
         Z50EspectaculoPaisName = "";
         Z9ClienteId = 0;
         Z1EspectaculoId = 0;
         Z27LugarSectorId = 0;
         Z47EspectaculoFuncionId = 0;
      }

      protected void InitAll089( )
      {
         A23EntradaId = 0;
         InitializeNonKey089( ) ;
      }

      protected void StandaloneModalInsert( )
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

      public void VarsToRow9( SdtEntrada obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Lugarsectordisponibles = A38LugarSectorDisponibles;
         obj9.gxTpr_Entradafecha = A42EntradaFecha;
         obj9.gxTpr_Paisid = A3PaisId;
         obj9.gxTpr_Paisname = A6PaisName;
         obj9.gxTpr_Clienteid = A9ClienteId;
         obj9.gxTpr_Clientename = A10ClienteName;
         obj9.gxTpr_Espectaculoid = A1EspectaculoId;
         obj9.gxTpr_Espectaculoname = A2EspectaculoName;
         obj9.gxTpr_Espectaculofecha = A16EspectaculoFecha;
         obj9.gxTpr_Espectaculofuncionid = A47EspectaculoFuncionId;
         obj9.gxTpr_Espectaculofuncionname = A48EspectaculoFuncionName;
         obj9.gxTpr_Espectaculoimagen = A26EspectaculoImagen;
         obj9.gxTpr_Espectaculoimagen_gxi = A40000EspectaculoImagen_GXI;
         obj9.gxTpr_Espectaculopaisname = A50EspectaculoPaisName;
         obj9.gxTpr_Lugarname = A5LugarName;
         obj9.gxTpr_Lugarsectorid = A27LugarSectorId;
         obj9.gxTpr_Lugarsectorname = A28LugarSectorName;
         obj9.gxTpr_Lugarsectorprecio = A30LugarSectorPrecio;
         obj9.gxTpr_Tipoespectaculoname = A8TipoEspectaculoName;
         obj9.gxTpr_Entradaid = A23EntradaId;
         obj9.gxTpr_Entradaid_Z = Z23EntradaId;
         obj9.gxTpr_Entradafecha_Z = Z42EntradaFecha;
         obj9.gxTpr_Paisid_Z = Z3PaisId;
         obj9.gxTpr_Paisname_Z = Z6PaisName;
         obj9.gxTpr_Clienteid_Z = Z9ClienteId;
         obj9.gxTpr_Clientename_Z = Z10ClienteName;
         obj9.gxTpr_Espectaculoid_Z = Z1EspectaculoId;
         obj9.gxTpr_Espectaculoname_Z = Z2EspectaculoName;
         obj9.gxTpr_Espectaculofecha_Z = Z16EspectaculoFecha;
         obj9.gxTpr_Espectaculofuncionid_Z = Z47EspectaculoFuncionId;
         obj9.gxTpr_Espectaculofuncionname_Z = Z48EspectaculoFuncionName;
         obj9.gxTpr_Espectaculopaisname_Z = Z50EspectaculoPaisName;
         obj9.gxTpr_Lugarname_Z = Z5LugarName;
         obj9.gxTpr_Lugarsectorid_Z = Z27LugarSectorId;
         obj9.gxTpr_Lugarsectorname_Z = Z28LugarSectorName;
         obj9.gxTpr_Lugarsectorprecio_Z = Z30LugarSectorPrecio;
         obj9.gxTpr_Lugarsectordisponibles_Z = Z38LugarSectorDisponibles;
         obj9.gxTpr_Tipoespectaculoname_Z = Z8TipoEspectaculoName;
         obj9.gxTpr_Espectaculoimagen_gxi_Z = Z40000EspectaculoImagen_GXI;
         obj9.gxTpr_Espectaculoid_N = (short)(Convert.ToInt16(n1EspectaculoId));
         obj9.gxTpr_Lugarsectorid_N = (short)(Convert.ToInt16(n27LugarSectorId));
         obj9.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow9( SdtEntrada obj9 )
      {
         obj9.gxTpr_Entradaid = A23EntradaId;
         return  ;
      }

      public void RowToVars9( SdtEntrada obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A38LugarSectorDisponibles = obj9.gxTpr_Lugarsectordisponibles;
         A42EntradaFecha = obj9.gxTpr_Entradafecha;
         A3PaisId = obj9.gxTpr_Paisid;
         A6PaisName = obj9.gxTpr_Paisname;
         A9ClienteId = obj9.gxTpr_Clienteid;
         A10ClienteName = obj9.gxTpr_Clientename;
         A1EspectaculoId = obj9.gxTpr_Espectaculoid;
         n1EspectaculoId = false;
         A2EspectaculoName = obj9.gxTpr_Espectaculoname;
         A16EspectaculoFecha = obj9.gxTpr_Espectaculofecha;
         A47EspectaculoFuncionId = obj9.gxTpr_Espectaculofuncionid;
         A48EspectaculoFuncionName = obj9.gxTpr_Espectaculofuncionname;
         A26EspectaculoImagen = obj9.gxTpr_Espectaculoimagen;
         A40000EspectaculoImagen_GXI = obj9.gxTpr_Espectaculoimagen_gxi;
         A50EspectaculoPaisName = obj9.gxTpr_Espectaculopaisname;
         A5LugarName = obj9.gxTpr_Lugarname;
         A27LugarSectorId = obj9.gxTpr_Lugarsectorid;
         n27LugarSectorId = false;
         A28LugarSectorName = obj9.gxTpr_Lugarsectorname;
         A30LugarSectorPrecio = obj9.gxTpr_Lugarsectorprecio;
         A8TipoEspectaculoName = obj9.gxTpr_Tipoespectaculoname;
         A23EntradaId = obj9.gxTpr_Entradaid;
         Z23EntradaId = obj9.gxTpr_Entradaid_Z;
         Z42EntradaFecha = obj9.gxTpr_Entradafecha_Z;
         Z3PaisId = obj9.gxTpr_Paisid_Z;
         Z6PaisName = obj9.gxTpr_Paisname_Z;
         Z9ClienteId = obj9.gxTpr_Clienteid_Z;
         Z10ClienteName = obj9.gxTpr_Clientename_Z;
         Z1EspectaculoId = obj9.gxTpr_Espectaculoid_Z;
         Z2EspectaculoName = obj9.gxTpr_Espectaculoname_Z;
         Z16EspectaculoFecha = obj9.gxTpr_Espectaculofecha_Z;
         Z47EspectaculoFuncionId = obj9.gxTpr_Espectaculofuncionid_Z;
         Z48EspectaculoFuncionName = obj9.gxTpr_Espectaculofuncionname_Z;
         Z50EspectaculoPaisName = obj9.gxTpr_Espectaculopaisname_Z;
         Z5LugarName = obj9.gxTpr_Lugarname_Z;
         Z27LugarSectorId = obj9.gxTpr_Lugarsectorid_Z;
         Z28LugarSectorName = obj9.gxTpr_Lugarsectorname_Z;
         Z30LugarSectorPrecio = obj9.gxTpr_Lugarsectorprecio_Z;
         Z38LugarSectorDisponibles = obj9.gxTpr_Lugarsectordisponibles_Z;
         Z8TipoEspectaculoName = obj9.gxTpr_Tipoespectaculoname_Z;
         Z40000EspectaculoImagen_GXI = obj9.gxTpr_Espectaculoimagen_gxi_Z;
         n1EspectaculoId = (bool)(Convert.ToBoolean(obj9.gxTpr_Espectaculoid_N));
         n27LugarSectorId = (bool)(Convert.ToBoolean(obj9.gxTpr_Lugarsectorid_N));
         Gx_mode = obj9.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A23EntradaId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey089( ) ;
         ScanKeyStart089( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z23EntradaId = A23EntradaId;
         }
         ZM089( -6) ;
         OnLoadActions089( ) ;
         AddRow089( ) ;
         ScanKeyEnd089( ) ;
         if ( RcdFound9 == 0 )
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
         RowToVars9( bcEntrada, 0) ;
         ScanKeyStart089( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z23EntradaId = A23EntradaId;
         }
         ZM089( -6) ;
         OnLoadActions089( ) ;
         AddRow089( ) ;
         ScanKeyEnd089( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey089( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert089( ) ;
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A23EntradaId != Z23EntradaId )
               {
                  A23EntradaId = Z23EntradaId;
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
                  Update089( ) ;
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
                  if ( A23EntradaId != Z23EntradaId )
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
                        Insert089( ) ;
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
                        Insert089( ) ;
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
         RowToVars9( bcEntrada, 1) ;
         SaveImpl( ) ;
         VarsToRow9( bcEntrada) ;
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
         RowToVars9( bcEntrada, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert089( ) ;
         AfterTrn( ) ;
         VarsToRow9( bcEntrada) ;
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
            SdtEntrada auxBC = new SdtEntrada(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A23EntradaId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcEntrada);
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
         RowToVars9( bcEntrada, 1) ;
         UpdateImpl( ) ;
         VarsToRow9( bcEntrada) ;
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
         RowToVars9( bcEntrada, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert089( ) ;
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
         VarsToRow9( bcEntrada) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars9( bcEntrada, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey089( ) ;
         if ( RcdFound9 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A23EntradaId != Z23EntradaId )
            {
               A23EntradaId = Z23EntradaId;
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
            if ( A23EntradaId != Z23EntradaId )
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
         pr_default.close(1);
         pr_default.close(16);
         pr_default.close(18);
         pr_default.close(21);
         pr_default.close(17);
         pr_default.close(19);
         pr_default.close(20);
         pr_default.close(22);
         pr_default.close(23);
         context.RollbackDataStores("entrada_bc",pr_default);
         VarsToRow9( bcEntrada) ;
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
         Gx_mode = bcEntrada.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcEntrada.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcEntrada )
         {
            bcEntrada = (SdtEntrada)(sdt);
            if ( StringUtil.StrCmp(bcEntrada.gxTpr_Mode, "") == 0 )
            {
               bcEntrada.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow9( bcEntrada) ;
            }
            else
            {
               RowToVars9( bcEntrada, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcEntrada.gxTpr_Mode, "") == 0 )
            {
               bcEntrada.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars9( bcEntrada, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtEntrada Entrada_BC
      {
         get {
            return bcEntrada ;
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
         pr_default.close(16);
         pr_default.close(18);
         pr_default.close(21);
         pr_default.close(17);
         pr_default.close(19);
         pr_default.close(20);
         pr_default.close(22);
         pr_default.close(23);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z42EntradaFecha = DateTime.MinValue;
         A42EntradaFecha = DateTime.MinValue;
         Z50EspectaculoPaisName = "";
         A50EspectaculoPaisName = "";
         Z10ClienteName = "";
         A10ClienteName = "";
         Z2EspectaculoName = "";
         A2EspectaculoName = "";
         Z16EspectaculoFecha = DateTime.MinValue;
         A16EspectaculoFecha = DateTime.MinValue;
         Z48EspectaculoFuncionName = "";
         A48EspectaculoFuncionName = "";
         Z6PaisName = "";
         A6PaisName = "";
         Z5LugarName = "";
         A5LugarName = "";
         Z8TipoEspectaculoName = "";
         A8TipoEspectaculoName = "";
         Z28LugarSectorName = "";
         A28LugarSectorName = "";
         Z26EspectaculoImagen = "";
         A26EspectaculoImagen = "";
         Z40000EspectaculoImagen_GXI = "";
         A40000EspectaculoImagen_GXI = "";
         BC000815_A4LugarId = new short[1] ;
         BC000815_A7TipoEspectaculoId = new short[1] ;
         BC000815_A23EntradaId = new short[1] ;
         BC000815_A42EntradaFecha = new DateTime[] {DateTime.MinValue} ;
         BC000815_A6PaisName = new string[] {""} ;
         BC000815_A10ClienteName = new string[] {""} ;
         BC000815_A2EspectaculoName = new string[] {""} ;
         BC000815_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         BC000815_A48EspectaculoFuncionName = new string[] {""} ;
         BC000815_A40000EspectaculoImagen_GXI = new string[] {""} ;
         BC000815_A50EspectaculoPaisName = new string[] {""} ;
         BC000815_A5LugarName = new string[] {""} ;
         BC000815_A28LugarSectorName = new string[] {""} ;
         BC000815_A30LugarSectorPrecio = new short[1] ;
         BC000815_A8TipoEspectaculoName = new string[] {""} ;
         BC000815_A29LugarSectorCantidad = new short[1] ;
         BC000815_A9ClienteId = new short[1] ;
         BC000815_A1EspectaculoId = new short[1] ;
         BC000815_n1EspectaculoId = new bool[] {false} ;
         BC000815_A27LugarSectorId = new short[1] ;
         BC000815_n27LugarSectorId = new bool[] {false} ;
         BC000815_A47EspectaculoFuncionId = new short[1] ;
         BC000815_A3PaisId = new short[1] ;
         BC000815_A37LugarSectorVendidas = new short[1] ;
         BC000815_n37LugarSectorVendidas = new bool[] {false} ;
         BC000815_A26EspectaculoImagen = new string[] {""} ;
         BC00084_A10ClienteName = new string[] {""} ;
         BC00084_A3PaisId = new short[1] ;
         BC00088_A6PaisName = new string[] {""} ;
         BC00085_A4LugarId = new short[1] ;
         BC00085_A7TipoEspectaculoId = new short[1] ;
         BC00085_A2EspectaculoName = new string[] {""} ;
         BC00085_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         BC00085_A40000EspectaculoImagen_GXI = new string[] {""} ;
         BC00085_A26EspectaculoImagen = new string[] {""} ;
         BC00089_A5LugarName = new string[] {""} ;
         BC000811_A28LugarSectorName = new string[] {""} ;
         BC000811_A30LugarSectorPrecio = new short[1] ;
         BC000811_A29LugarSectorCantidad = new short[1] ;
         BC000810_A8TipoEspectaculoName = new string[] {""} ;
         BC00086_A1EspectaculoId = new short[1] ;
         BC00086_n1EspectaculoId = new bool[] {false} ;
         BC00087_A48EspectaculoFuncionName = new string[] {""} ;
         BC000813_A37LugarSectorVendidas = new short[1] ;
         BC000813_n37LugarSectorVendidas = new bool[] {false} ;
         BC000816_A23EntradaId = new short[1] ;
         BC00083_A23EntradaId = new short[1] ;
         BC00083_A42EntradaFecha = new DateTime[] {DateTime.MinValue} ;
         BC00083_A50EspectaculoPaisName = new string[] {""} ;
         BC00083_A9ClienteId = new short[1] ;
         BC00083_A1EspectaculoId = new short[1] ;
         BC00083_n1EspectaculoId = new bool[] {false} ;
         BC00083_A27LugarSectorId = new short[1] ;
         BC00083_n27LugarSectorId = new bool[] {false} ;
         BC00083_A47EspectaculoFuncionId = new short[1] ;
         sMode9 = "";
         BC00082_A23EntradaId = new short[1] ;
         BC00082_A42EntradaFecha = new DateTime[] {DateTime.MinValue} ;
         BC00082_A50EspectaculoPaisName = new string[] {""} ;
         BC00082_A9ClienteId = new short[1] ;
         BC00082_A1EspectaculoId = new short[1] ;
         BC00082_n1EspectaculoId = new bool[] {false} ;
         BC00082_A27LugarSectorId = new short[1] ;
         BC00082_n27LugarSectorId = new bool[] {false} ;
         BC00082_A47EspectaculoFuncionId = new short[1] ;
         BC000817_A23EntradaId = new short[1] ;
         BC000820_A10ClienteName = new string[] {""} ;
         BC000820_A3PaisId = new short[1] ;
         BC000821_A6PaisName = new string[] {""} ;
         BC000822_A4LugarId = new short[1] ;
         BC000822_A7TipoEspectaculoId = new short[1] ;
         BC000822_A2EspectaculoName = new string[] {""} ;
         BC000822_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         BC000822_A40000EspectaculoImagen_GXI = new string[] {""} ;
         BC000822_A26EspectaculoImagen = new string[] {""} ;
         BC000823_A5LugarName = new string[] {""} ;
         BC000824_A8TipoEspectaculoName = new string[] {""} ;
         BC000825_A48EspectaculoFuncionName = new string[] {""} ;
         BC000826_A28LugarSectorName = new string[] {""} ;
         BC000826_A30LugarSectorPrecio = new short[1] ;
         BC000826_A29LugarSectorCantidad = new short[1] ;
         BC000828_A37LugarSectorVendidas = new short[1] ;
         BC000828_n37LugarSectorVendidas = new bool[] {false} ;
         BC000830_A4LugarId = new short[1] ;
         BC000830_A7TipoEspectaculoId = new short[1] ;
         BC000830_A23EntradaId = new short[1] ;
         BC000830_A42EntradaFecha = new DateTime[] {DateTime.MinValue} ;
         BC000830_A6PaisName = new string[] {""} ;
         BC000830_A10ClienteName = new string[] {""} ;
         BC000830_A2EspectaculoName = new string[] {""} ;
         BC000830_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         BC000830_A48EspectaculoFuncionName = new string[] {""} ;
         BC000830_A40000EspectaculoImagen_GXI = new string[] {""} ;
         BC000830_A50EspectaculoPaisName = new string[] {""} ;
         BC000830_A5LugarName = new string[] {""} ;
         BC000830_A28LugarSectorName = new string[] {""} ;
         BC000830_A30LugarSectorPrecio = new short[1] ;
         BC000830_A8TipoEspectaculoName = new string[] {""} ;
         BC000830_A29LugarSectorCantidad = new short[1] ;
         BC000830_A9ClienteId = new short[1] ;
         BC000830_A1EspectaculoId = new short[1] ;
         BC000830_n1EspectaculoId = new bool[] {false} ;
         BC000830_A27LugarSectorId = new short[1] ;
         BC000830_n27LugarSectorId = new bool[] {false} ;
         BC000830_A47EspectaculoFuncionId = new short[1] ;
         BC000830_A3PaisId = new short[1] ;
         BC000830_A37LugarSectorVendidas = new short[1] ;
         BC000830_n37LugarSectorVendidas = new bool[] {false} ;
         BC000830_A26EspectaculoImagen = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.entrada_bc__default(),
            new Object[][] {
                new Object[] {
               BC00082_A23EntradaId, BC00082_A42EntradaFecha, BC00082_A50EspectaculoPaisName, BC00082_A9ClienteId, BC00082_A1EspectaculoId, BC00082_A27LugarSectorId, BC00082_A47EspectaculoFuncionId
               }
               , new Object[] {
               BC00083_A23EntradaId, BC00083_A42EntradaFecha, BC00083_A50EspectaculoPaisName, BC00083_A9ClienteId, BC00083_A1EspectaculoId, BC00083_A27LugarSectorId, BC00083_A47EspectaculoFuncionId
               }
               , new Object[] {
               BC00084_A10ClienteName, BC00084_A3PaisId
               }
               , new Object[] {
               BC00085_A4LugarId, BC00085_A7TipoEspectaculoId, BC00085_A2EspectaculoName, BC00085_A16EspectaculoFecha, BC00085_A40000EspectaculoImagen_GXI, BC00085_A26EspectaculoImagen
               }
               , new Object[] {
               BC00086_A1EspectaculoId
               }
               , new Object[] {
               BC00087_A48EspectaculoFuncionName
               }
               , new Object[] {
               BC00088_A6PaisName
               }
               , new Object[] {
               BC00089_A5LugarName
               }
               , new Object[] {
               BC000810_A8TipoEspectaculoName
               }
               , new Object[] {
               BC000811_A28LugarSectorName, BC000811_A30LugarSectorPrecio, BC000811_A29LugarSectorCantidad
               }
               , new Object[] {
               BC000813_A37LugarSectorVendidas, BC000813_n37LugarSectorVendidas
               }
               , new Object[] {
               BC000815_A4LugarId, BC000815_A7TipoEspectaculoId, BC000815_A23EntradaId, BC000815_A42EntradaFecha, BC000815_A6PaisName, BC000815_A10ClienteName, BC000815_A2EspectaculoName, BC000815_A16EspectaculoFecha, BC000815_A48EspectaculoFuncionName, BC000815_A40000EspectaculoImagen_GXI,
               BC000815_A50EspectaculoPaisName, BC000815_A5LugarName, BC000815_A28LugarSectorName, BC000815_A30LugarSectorPrecio, BC000815_A8TipoEspectaculoName, BC000815_A29LugarSectorCantidad, BC000815_A9ClienteId, BC000815_A1EspectaculoId, BC000815_n1EspectaculoId, BC000815_A27LugarSectorId,
               BC000815_n27LugarSectorId, BC000815_A47EspectaculoFuncionId, BC000815_A3PaisId, BC000815_A37LugarSectorVendidas, BC000815_n37LugarSectorVendidas, BC000815_A26EspectaculoImagen
               }
               , new Object[] {
               BC000816_A23EntradaId
               }
               , new Object[] {
               BC000817_A23EntradaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000820_A10ClienteName, BC000820_A3PaisId
               }
               , new Object[] {
               BC000821_A6PaisName
               }
               , new Object[] {
               BC000822_A4LugarId, BC000822_A7TipoEspectaculoId, BC000822_A2EspectaculoName, BC000822_A16EspectaculoFecha, BC000822_A40000EspectaculoImagen_GXI, BC000822_A26EspectaculoImagen
               }
               , new Object[] {
               BC000823_A5LugarName
               }
               , new Object[] {
               BC000824_A8TipoEspectaculoName
               }
               , new Object[] {
               BC000825_A48EspectaculoFuncionName
               }
               , new Object[] {
               BC000826_A28LugarSectorName, BC000826_A30LugarSectorPrecio, BC000826_A29LugarSectorCantidad
               }
               , new Object[] {
               BC000828_A37LugarSectorVendidas, BC000828_n37LugarSectorVendidas
               }
               , new Object[] {
               BC000830_A4LugarId, BC000830_A7TipoEspectaculoId, BC000830_A23EntradaId, BC000830_A42EntradaFecha, BC000830_A6PaisName, BC000830_A10ClienteName, BC000830_A2EspectaculoName, BC000830_A16EspectaculoFecha, BC000830_A48EspectaculoFuncionName, BC000830_A40000EspectaculoImagen_GXI,
               BC000830_A50EspectaculoPaisName, BC000830_A5LugarName, BC000830_A28LugarSectorName, BC000830_A30LugarSectorPrecio, BC000830_A8TipoEspectaculoName, BC000830_A29LugarSectorCantidad, BC000830_A9ClienteId, BC000830_A1EspectaculoId, BC000830_n1EspectaculoId, BC000830_A27LugarSectorId,
               BC000830_n27LugarSectorId, BC000830_A47EspectaculoFuncionId, BC000830_A3PaisId, BC000830_A37LugarSectorVendidas, BC000830_n37LugarSectorVendidas, BC000830_A26EspectaculoImagen
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12082 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z23EntradaId ;
      private short A23EntradaId ;
      private short GX_JID ;
      private short Z9ClienteId ;
      private short A9ClienteId ;
      private short Z1EspectaculoId ;
      private short A1EspectaculoId ;
      private short Z27LugarSectorId ;
      private short A27LugarSectorId ;
      private short Z47EspectaculoFuncionId ;
      private short A47EspectaculoFuncionId ;
      private short Z38LugarSectorDisponibles ;
      private short A38LugarSectorDisponibles ;
      private short Z3PaisId ;
      private short A3PaisId ;
      private short Z4LugarId ;
      private short A4LugarId ;
      private short Z7TipoEspectaculoId ;
      private short A7TipoEspectaculoId ;
      private short Z30LugarSectorPrecio ;
      private short A30LugarSectorPrecio ;
      private short Z29LugarSectorCantidad ;
      private short A29LugarSectorCantidad ;
      private short Z37LugarSectorVendidas ;
      private short A37LugarSectorVendidas ;
      private short RcdFound9 ;
      private short nIsDirty_9 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode9 ;
      private DateTime Z42EntradaFecha ;
      private DateTime A42EntradaFecha ;
      private DateTime Z16EspectaculoFecha ;
      private DateTime A16EspectaculoFecha ;
      private bool returnInSub ;
      private bool n1EspectaculoId ;
      private bool n27LugarSectorId ;
      private bool n37LugarSectorVendidas ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z50EspectaculoPaisName ;
      private string A50EspectaculoPaisName ;
      private string Z10ClienteName ;
      private string A10ClienteName ;
      private string Z2EspectaculoName ;
      private string A2EspectaculoName ;
      private string Z48EspectaculoFuncionName ;
      private string A48EspectaculoFuncionName ;
      private string Z6PaisName ;
      private string A6PaisName ;
      private string Z5LugarName ;
      private string A5LugarName ;
      private string Z8TipoEspectaculoName ;
      private string A8TipoEspectaculoName ;
      private string Z28LugarSectorName ;
      private string A28LugarSectorName ;
      private string Z40000EspectaculoImagen_GXI ;
      private string A40000EspectaculoImagen_GXI ;
      private string Z26EspectaculoImagen ;
      private string A26EspectaculoImagen ;
      private SdtEntrada bcEntrada ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC000815_A4LugarId ;
      private short[] BC000815_A7TipoEspectaculoId ;
      private short[] BC000815_A23EntradaId ;
      private DateTime[] BC000815_A42EntradaFecha ;
      private string[] BC000815_A6PaisName ;
      private string[] BC000815_A10ClienteName ;
      private string[] BC000815_A2EspectaculoName ;
      private DateTime[] BC000815_A16EspectaculoFecha ;
      private string[] BC000815_A48EspectaculoFuncionName ;
      private string[] BC000815_A40000EspectaculoImagen_GXI ;
      private string[] BC000815_A50EspectaculoPaisName ;
      private string[] BC000815_A5LugarName ;
      private string[] BC000815_A28LugarSectorName ;
      private short[] BC000815_A30LugarSectorPrecio ;
      private string[] BC000815_A8TipoEspectaculoName ;
      private short[] BC000815_A29LugarSectorCantidad ;
      private short[] BC000815_A9ClienteId ;
      private short[] BC000815_A1EspectaculoId ;
      private bool[] BC000815_n1EspectaculoId ;
      private short[] BC000815_A27LugarSectorId ;
      private bool[] BC000815_n27LugarSectorId ;
      private short[] BC000815_A47EspectaculoFuncionId ;
      private short[] BC000815_A3PaisId ;
      private short[] BC000815_A37LugarSectorVendidas ;
      private bool[] BC000815_n37LugarSectorVendidas ;
      private string[] BC000815_A26EspectaculoImagen ;
      private string[] BC00084_A10ClienteName ;
      private short[] BC00084_A3PaisId ;
      private string[] BC00088_A6PaisName ;
      private short[] BC00085_A4LugarId ;
      private short[] BC00085_A7TipoEspectaculoId ;
      private string[] BC00085_A2EspectaculoName ;
      private DateTime[] BC00085_A16EspectaculoFecha ;
      private string[] BC00085_A40000EspectaculoImagen_GXI ;
      private string[] BC00085_A26EspectaculoImagen ;
      private string[] BC00089_A5LugarName ;
      private string[] BC000811_A28LugarSectorName ;
      private short[] BC000811_A30LugarSectorPrecio ;
      private short[] BC000811_A29LugarSectorCantidad ;
      private string[] BC000810_A8TipoEspectaculoName ;
      private short[] BC00086_A1EspectaculoId ;
      private bool[] BC00086_n1EspectaculoId ;
      private string[] BC00087_A48EspectaculoFuncionName ;
      private short[] BC000813_A37LugarSectorVendidas ;
      private bool[] BC000813_n37LugarSectorVendidas ;
      private short[] BC000816_A23EntradaId ;
      private short[] BC00083_A23EntradaId ;
      private DateTime[] BC00083_A42EntradaFecha ;
      private string[] BC00083_A50EspectaculoPaisName ;
      private short[] BC00083_A9ClienteId ;
      private short[] BC00083_A1EspectaculoId ;
      private bool[] BC00083_n1EspectaculoId ;
      private short[] BC00083_A27LugarSectorId ;
      private bool[] BC00083_n27LugarSectorId ;
      private short[] BC00083_A47EspectaculoFuncionId ;
      private short[] BC00082_A23EntradaId ;
      private DateTime[] BC00082_A42EntradaFecha ;
      private string[] BC00082_A50EspectaculoPaisName ;
      private short[] BC00082_A9ClienteId ;
      private short[] BC00082_A1EspectaculoId ;
      private bool[] BC00082_n1EspectaculoId ;
      private short[] BC00082_A27LugarSectorId ;
      private bool[] BC00082_n27LugarSectorId ;
      private short[] BC00082_A47EspectaculoFuncionId ;
      private short[] BC000817_A23EntradaId ;
      private string[] BC000820_A10ClienteName ;
      private short[] BC000820_A3PaisId ;
      private string[] BC000821_A6PaisName ;
      private short[] BC000822_A4LugarId ;
      private short[] BC000822_A7TipoEspectaculoId ;
      private string[] BC000822_A2EspectaculoName ;
      private DateTime[] BC000822_A16EspectaculoFecha ;
      private string[] BC000822_A40000EspectaculoImagen_GXI ;
      private string[] BC000822_A26EspectaculoImagen ;
      private string[] BC000823_A5LugarName ;
      private string[] BC000824_A8TipoEspectaculoName ;
      private string[] BC000825_A48EspectaculoFuncionName ;
      private string[] BC000826_A28LugarSectorName ;
      private short[] BC000826_A30LugarSectorPrecio ;
      private short[] BC000826_A29LugarSectorCantidad ;
      private short[] BC000828_A37LugarSectorVendidas ;
      private bool[] BC000828_n37LugarSectorVendidas ;
      private short[] BC000830_A4LugarId ;
      private short[] BC000830_A7TipoEspectaculoId ;
      private short[] BC000830_A23EntradaId ;
      private DateTime[] BC000830_A42EntradaFecha ;
      private string[] BC000830_A6PaisName ;
      private string[] BC000830_A10ClienteName ;
      private string[] BC000830_A2EspectaculoName ;
      private DateTime[] BC000830_A16EspectaculoFecha ;
      private string[] BC000830_A48EspectaculoFuncionName ;
      private string[] BC000830_A40000EspectaculoImagen_GXI ;
      private string[] BC000830_A50EspectaculoPaisName ;
      private string[] BC000830_A5LugarName ;
      private string[] BC000830_A28LugarSectorName ;
      private short[] BC000830_A30LugarSectorPrecio ;
      private string[] BC000830_A8TipoEspectaculoName ;
      private short[] BC000830_A29LugarSectorCantidad ;
      private short[] BC000830_A9ClienteId ;
      private short[] BC000830_A1EspectaculoId ;
      private bool[] BC000830_n1EspectaculoId ;
      private short[] BC000830_A27LugarSectorId ;
      private bool[] BC000830_n27LugarSectorId ;
      private short[] BC000830_A47EspectaculoFuncionId ;
      private short[] BC000830_A3PaisId ;
      private short[] BC000830_A37LugarSectorVendidas ;
      private bool[] BC000830_n37LugarSectorVendidas ;
      private string[] BC000830_A26EspectaculoImagen ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class entrada_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000815;
          prmBC000815 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmBC00084;
          prmBC00084 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmBC00088;
          prmBC00088 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00085;
          prmBC00085 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00089;
          prmBC00089 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000811;
          prmBC000811 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000810;
          prmBC000810 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00086;
          prmBC00086 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC00087;
          prmBC00087 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmBC000813;
          prmBC000813 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000816;
          prmBC000816 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmBC00083;
          prmBC00083 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmBC00082;
          prmBC00082 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmBC000817;
          prmBC000817 = new Object[] {
          new ParDef("@EntradaFecha",GXType.Date,8,0) ,
          new ParDef("@EspectaculoPaisName",GXType.NVarChar,40,0) ,
          new ParDef("@ClienteId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmBC000818;
          prmBC000818 = new Object[] {
          new ParDef("@EntradaFecha",GXType.Date,8,0) ,
          new ParDef("@EspectaculoPaisName",GXType.NVarChar,40,0) ,
          new ParDef("@ClienteId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0) ,
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmBC000819;
          prmBC000819 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmBC000820;
          prmBC000820 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmBC000821;
          prmBC000821 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000822;
          prmBC000822 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000823;
          prmBC000823 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmBC000824;
          prmBC000824 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000825;
          prmBC000825 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmBC000826;
          prmBC000826 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000828;
          prmBC000828 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmBC000830;
          prmBC000830 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00082", "SELECT [EntradaId], [EntradaFecha], [EspectaculoPaisName], [ClienteId], [EspectaculoId], [LugarSectorId], [EspectaculoFuncionId] FROM [Entrada] WITH (UPDLOCK) WHERE [EntradaId] = @EntradaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00082,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00083", "SELECT [EntradaId], [EntradaFecha], [EspectaculoPaisName], [ClienteId], [EspectaculoId], [LugarSectorId], [EspectaculoFuncionId] FROM [Entrada] WHERE [EntradaId] = @EntradaId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00083,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00084", "SELECT [ClienteName], [PaisId] FROM [Cliente] WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00084,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00085", "SELECT [LugarId], [TipoEspectaculoId], [EspectaculoName], [EspectaculoFecha], [EspectaculoImagen_GXI], [EspectaculoImagen] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00085,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00086", "SELECT [EspectaculoId] FROM [EspectaculoLugarSector] WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00086,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00087", "SELECT [EspectaculoFuncionName] FROM [EspectaculoFuncion] WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoFuncionId] = @EspectaculoFuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00087,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00088", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00088,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00089", "SELECT [LugarName] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00089,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000810", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000810,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000811", "SELECT [LugarSectorName], [LugarSectorPrecio], [LugarSectorCantidad] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000811,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000813", "SELECT COALESCE( T1.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (SELECT COUNT(*) AS LugarSectorVendidas, [EspectaculoId], [LugarSectorId] FROM [Entrada] WITH (UPDLOCK) GROUP BY [EspectaculoId], [LugarSectorId] ) T1 WHERE T1.[EspectaculoId] = @EspectaculoId AND T1.[LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000813,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000815", "SELECT T4.[LugarId], T4.[TipoEspectaculoId], TM1.[EntradaId], TM1.[EntradaFecha], T3.[PaisName], T2.[ClienteName], T4.[EspectaculoName], T4.[EspectaculoFecha], T7.[EspectaculoFuncionName], T4.[EspectaculoImagen_GXI], TM1.[EspectaculoPaisName], T5.[LugarName], T8.[LugarSectorName], T8.[LugarSectorPrecio], T6.[TipoEspectaculoName], T8.[LugarSectorCantidad], TM1.[ClienteId], TM1.[EspectaculoId], TM1.[LugarSectorId], TM1.[EspectaculoFuncionId], T2.[PaisId], COALESCE( T9.[LugarSectorVendidas], 0) AS LugarSectorVendidas, T4.[EspectaculoImagen] FROM (((((((([Entrada] TM1 INNER JOIN [Cliente] T2 ON T2.[ClienteId] = TM1.[ClienteId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = T2.[PaisId]) INNER JOIN [Espectaculo] T4 ON T4.[EspectaculoId] = TM1.[EspectaculoId]) INNER JOIN [Lugar] T5 ON T5.[LugarId] = T4.[LugarId]) INNER JOIN [TipoEspectaculo] T6 ON T6.[TipoEspectaculoId] = T4.[TipoEspectaculoId]) LEFT JOIN [LugarSector] T8 ON T8.[LugarId] = T4.[LugarId] AND T8.[LugarSectorId] = TM1.[LugarSectorId]) INNER JOIN [EspectaculoFuncion] T7 ON T7.[EspectaculoId] = TM1.[EspectaculoId] AND T7.[EspectaculoFuncionId] = TM1.[EspectaculoFuncionId]) LEFT JOIN (SELECT COUNT(*) AS LugarSectorVendidas, TM1.[EspectaculoId], TM1.[LugarSectorId] FROM [Entrada] TM1 GROUP BY TM1.[EspectaculoId], TM1.[LugarSectorId] ) T9 ON T9.[EspectaculoId] = TM1.[EspectaculoId] AND T9.[LugarSectorId] = TM1.[LugarSectorId]) WHERE TM1.[EntradaId] = @EntradaId ORDER BY TM1.[EntradaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000815,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000816", "SELECT [EntradaId] FROM [Entrada] WHERE [EntradaId] = @EntradaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000816,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000817", "INSERT INTO [Entrada]([EntradaFecha], [EspectaculoPaisName], [ClienteId], [EspectaculoId], [LugarSectorId], [EspectaculoFuncionId]) VALUES(@EntradaFecha, @EspectaculoPaisName, @ClienteId, @EspectaculoId, @LugarSectorId, @EspectaculoFuncionId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC000817,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000818", "UPDATE [Entrada] SET [EntradaFecha]=@EntradaFecha, [EspectaculoPaisName]=@EspectaculoPaisName, [ClienteId]=@ClienteId, [EspectaculoId]=@EspectaculoId, [LugarSectorId]=@LugarSectorId, [EspectaculoFuncionId]=@EspectaculoFuncionId  WHERE [EntradaId] = @EntradaId", GxErrorMask.GX_NOMASK,prmBC000818)
             ,new CursorDef("BC000819", "DELETE FROM [Entrada]  WHERE [EntradaId] = @EntradaId", GxErrorMask.GX_NOMASK,prmBC000819)
             ,new CursorDef("BC000820", "SELECT [ClienteName], [PaisId] FROM [Cliente] WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000820,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000821", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000821,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000822", "SELECT [LugarId], [TipoEspectaculoId], [EspectaculoName], [EspectaculoFecha], [EspectaculoImagen_GXI], [EspectaculoImagen] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000822,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000823", "SELECT [LugarName] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000823,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000824", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000824,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000825", "SELECT [EspectaculoFuncionName] FROM [EspectaculoFuncion] WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoFuncionId] = @EspectaculoFuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000825,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000826", "SELECT [LugarSectorName], [LugarSectorPrecio], [LugarSectorCantidad] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000826,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000828", "SELECT COALESCE( T1.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (SELECT COUNT(*) AS LugarSectorVendidas, [EspectaculoId], [LugarSectorId] FROM [Entrada] WITH (UPDLOCK) GROUP BY [EspectaculoId], [LugarSectorId] ) T1 WHERE T1.[EspectaculoId] = @EspectaculoId AND T1.[LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000828,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000830", "SELECT T4.[LugarId], T4.[TipoEspectaculoId], TM1.[EntradaId], TM1.[EntradaFecha], T3.[PaisName], T2.[ClienteName], T4.[EspectaculoName], T4.[EspectaculoFecha], T7.[EspectaculoFuncionName], T4.[EspectaculoImagen_GXI], TM1.[EspectaculoPaisName], T5.[LugarName], T8.[LugarSectorName], T8.[LugarSectorPrecio], T6.[TipoEspectaculoName], T8.[LugarSectorCantidad], TM1.[ClienteId], TM1.[EspectaculoId], TM1.[LugarSectorId], TM1.[EspectaculoFuncionId], T2.[PaisId], COALESCE( T9.[LugarSectorVendidas], 0) AS LugarSectorVendidas, T4.[EspectaculoImagen] FROM (((((((([Entrada] TM1 INNER JOIN [Cliente] T2 ON T2.[ClienteId] = TM1.[ClienteId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = T2.[PaisId]) INNER JOIN [Espectaculo] T4 ON T4.[EspectaculoId] = TM1.[EspectaculoId]) INNER JOIN [Lugar] T5 ON T5.[LugarId] = T4.[LugarId]) INNER JOIN [TipoEspectaculo] T6 ON T6.[TipoEspectaculoId] = T4.[TipoEspectaculoId]) LEFT JOIN [LugarSector] T8 ON T8.[LugarId] = T4.[LugarId] AND T8.[LugarSectorId] = TM1.[LugarSectorId]) INNER JOIN [EspectaculoFuncion] T7 ON T7.[EspectaculoId] = TM1.[EspectaculoId] AND T7.[EspectaculoFuncionId] = TM1.[EspectaculoFuncionId]) LEFT JOIN (SELECT COUNT(*) AS LugarSectorVendidas, TM1.[EspectaculoId], TM1.[LugarSectorId] FROM [Entrada] TM1 GROUP BY TM1.[EspectaculoId], TM1.[LugarSectorId] ) T9 ON T9.[EspectaculoId] = TM1.[EspectaculoId] AND T9.[LugarSectorId] = TM1.[LugarSectorId]) WHERE TM1.[EntradaId] = @EntradaId ORDER BY TM1.[EntradaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000830,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(5));
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((short[]) buf[15])[0] = rslt.getShort(16);
                ((short[]) buf[16])[0] = rslt.getShort(17);
                ((short[]) buf[17])[0] = rslt.getShort(18);
                ((bool[]) buf[18])[0] = rslt.wasNull(18);
                ((short[]) buf[19])[0] = rslt.getShort(19);
                ((bool[]) buf[20])[0] = rslt.wasNull(19);
                ((short[]) buf[21])[0] = rslt.getShort(20);
                ((short[]) buf[22])[0] = rslt.getShort(21);
                ((short[]) buf[23])[0] = rslt.getShort(22);
                ((bool[]) buf[24])[0] = rslt.wasNull(22);
                ((string[]) buf[25])[0] = rslt.getMultimediaFile(23, rslt.getVarchar(10));
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(5));
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaUri(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((short[]) buf[13])[0] = rslt.getShort(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((short[]) buf[15])[0] = rslt.getShort(16);
                ((short[]) buf[16])[0] = rslt.getShort(17);
                ((short[]) buf[17])[0] = rslt.getShort(18);
                ((bool[]) buf[18])[0] = rslt.wasNull(18);
                ((short[]) buf[19])[0] = rslt.getShort(19);
                ((bool[]) buf[20])[0] = rslt.wasNull(19);
                ((short[]) buf[21])[0] = rslt.getShort(20);
                ((short[]) buf[22])[0] = rslt.getShort(21);
                ((short[]) buf[23])[0] = rslt.getShort(22);
                ((bool[]) buf[24])[0] = rslt.wasNull(22);
                ((string[]) buf[25])[0] = rslt.getMultimediaFile(23, rslt.getVarchar(10));
                return;
       }
    }

 }

}
