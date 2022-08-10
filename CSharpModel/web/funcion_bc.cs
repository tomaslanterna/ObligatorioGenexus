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
   public class funcion_bc : GXHttpHandler, IGxSilentTrn
   {
      public funcion_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public funcion_bc( IGxContext context )
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
         ReadRow077( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey077( ) ;
         standaloneModal( ) ;
         AddRow077( ) ;
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
            E11072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z15FuncionId = A15FuncionId;
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

      protected void CONFIRM_070( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls077( ) ;
            }
            else
            {
               CheckExtendedTable077( ) ;
               if ( AnyError == 0 )
               {
                  ZM077( 3) ;
               }
               CloseExtendedTableCursors077( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12072( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11072( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM077( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z22FuncionName = A22FuncionName;
            Z21PrecioFuncion = A21PrecioFuncion;
            Z1EspectaculoId = A1EspectaculoId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z2EspectaculoName = A2EspectaculoName;
         }
         if ( GX_JID == -2 )
         {
            Z15FuncionId = A15FuncionId;
            Z22FuncionName = A22FuncionName;
            Z21PrecioFuncion = A21PrecioFuncion;
            Z1EspectaculoId = A1EspectaculoId;
            Z2EspectaculoName = A2EspectaculoName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load077( )
      {
         /* Using cursor BC00075 */
         pr_default.execute(3, new Object[] {A15FuncionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound7 = 1;
            A22FuncionName = BC00075_A22FuncionName[0];
            A21PrecioFuncion = BC00075_A21PrecioFuncion[0];
            A2EspectaculoName = BC00075_A2EspectaculoName[0];
            A1EspectaculoId = BC00075_A1EspectaculoId[0];
            ZM077( -2) ;
         }
         pr_default.close(3);
         OnLoadActions077( ) ;
      }

      protected void OnLoadActions077( )
      {
      }

      protected void CheckExtendedTable077( )
      {
         nIsDirty_7 = 0;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A22FuncionName)) )
         {
            GX_msglist.addItem("Debe ingresar un nombre", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00074 */
         pr_default.execute(2, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
         }
         A2EspectaculoName = BC00074_A2EspectaculoName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors077( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey077( )
      {
         /* Using cursor BC00076 */
         pr_default.execute(4, new Object[] {A15FuncionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00073 */
         pr_default.execute(1, new Object[] {A15FuncionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM077( 2) ;
            RcdFound7 = 1;
            A15FuncionId = BC00073_A15FuncionId[0];
            A22FuncionName = BC00073_A22FuncionName[0];
            A21PrecioFuncion = BC00073_A21PrecioFuncion[0];
            A1EspectaculoId = BC00073_A1EspectaculoId[0];
            Z15FuncionId = A15FuncionId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load077( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey077( ) ;
            }
            Gx_mode = sMode7;
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey077( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode7;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey077( ) ;
         if ( RcdFound7 == 0 )
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
         CONFIRM_070( ) ;
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

      protected void CheckOptimisticConcurrency077( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00072 */
            pr_default.execute(0, new Object[] {A15FuncionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Funcion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z22FuncionName, BC00072_A22FuncionName[0]) != 0 ) || ( Z21PrecioFuncion != BC00072_A21PrecioFuncion[0] ) || ( Z1EspectaculoId != BC00072_A1EspectaculoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Funcion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM077( 0) ;
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00077 */
                     pr_default.execute(5, new Object[] {A22FuncionName, A21PrecioFuncion, A1EspectaculoId});
                     A15FuncionId = BC00077_A15FuncionId[0];
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Funcion");
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
               Load077( ) ;
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void Update077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00078 */
                     pr_default.execute(6, new Object[] {A22FuncionName, A21PrecioFuncion, A1EspectaculoId, A15FuncionId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Funcion");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Funcion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate077( ) ;
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
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void DeferredUpdate077( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls077( ) ;
            AfterConfirm077( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete077( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00079 */
                  pr_default.execute(7, new Object[] {A15FuncionId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("Funcion");
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel077( ) ;
         Gx_mode = sMode7;
      }

      protected void OnDeleteControls077( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000710 */
            pr_default.execute(8, new Object[] {A1EspectaculoId});
            A2EspectaculoName = BC000710_A2EspectaculoName[0];
            pr_default.close(8);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000711 */
            pr_default.execute(9, new Object[] {A15FuncionId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Invitacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel077( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete077( ) ;
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

      public void ScanKeyStart077( )
      {
         /* Scan By routine */
         /* Using cursor BC000712 */
         pr_default.execute(10, new Object[] {A15FuncionId});
         RcdFound7 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound7 = 1;
            A15FuncionId = BC000712_A15FuncionId[0];
            A22FuncionName = BC000712_A22FuncionName[0];
            A21PrecioFuncion = BC000712_A21PrecioFuncion[0];
            A2EspectaculoName = BC000712_A2EspectaculoName[0];
            A1EspectaculoId = BC000712_A1EspectaculoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext077( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound7 = 0;
         ScanKeyLoad077( ) ;
      }

      protected void ScanKeyLoad077( )
      {
         sMode7 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound7 = 1;
            A15FuncionId = BC000712_A15FuncionId[0];
            A22FuncionName = BC000712_A22FuncionName[0];
            A21PrecioFuncion = BC000712_A21PrecioFuncion[0];
            A2EspectaculoName = BC000712_A2EspectaculoName[0];
            A1EspectaculoId = BC000712_A1EspectaculoId[0];
         }
         Gx_mode = sMode7;
      }

      protected void ScanKeyEnd077( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm077( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert077( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate077( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete077( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete077( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate077( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes077( )
      {
      }

      protected void send_integrity_lvl_hashes077( )
      {
      }

      protected void AddRow077( )
      {
         VarsToRow7( bcFuncion) ;
      }

      protected void ReadRow077( )
      {
         RowToVars7( bcFuncion, 1) ;
      }

      protected void InitializeNonKey077( )
      {
         A22FuncionName = "";
         A21PrecioFuncion = 0;
         A1EspectaculoId = 0;
         A2EspectaculoName = "";
         Z22FuncionName = "";
         Z21PrecioFuncion = 0;
         Z1EspectaculoId = 0;
      }

      protected void InitAll077( )
      {
         A15FuncionId = 0;
         InitializeNonKey077( ) ;
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

      public void VarsToRow7( SdtFuncion obj7 )
      {
         obj7.gxTpr_Mode = Gx_mode;
         obj7.gxTpr_Funcionname = A22FuncionName;
         obj7.gxTpr_Preciofuncion = A21PrecioFuncion;
         obj7.gxTpr_Espectaculoid = A1EspectaculoId;
         obj7.gxTpr_Espectaculoname = A2EspectaculoName;
         obj7.gxTpr_Funcionid = A15FuncionId;
         obj7.gxTpr_Funcionid_Z = Z15FuncionId;
         obj7.gxTpr_Funcionname_Z = Z22FuncionName;
         obj7.gxTpr_Preciofuncion_Z = Z21PrecioFuncion;
         obj7.gxTpr_Espectaculoid_Z = Z1EspectaculoId;
         obj7.gxTpr_Espectaculoname_Z = Z2EspectaculoName;
         obj7.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow7( SdtFuncion obj7 )
      {
         obj7.gxTpr_Funcionid = A15FuncionId;
         return  ;
      }

      public void RowToVars7( SdtFuncion obj7 ,
                              int forceLoad )
      {
         Gx_mode = obj7.gxTpr_Mode;
         A22FuncionName = obj7.gxTpr_Funcionname;
         A21PrecioFuncion = obj7.gxTpr_Preciofuncion;
         A1EspectaculoId = obj7.gxTpr_Espectaculoid;
         A2EspectaculoName = obj7.gxTpr_Espectaculoname;
         A15FuncionId = obj7.gxTpr_Funcionid;
         Z15FuncionId = obj7.gxTpr_Funcionid_Z;
         Z22FuncionName = obj7.gxTpr_Funcionname_Z;
         Z21PrecioFuncion = obj7.gxTpr_Preciofuncion_Z;
         Z1EspectaculoId = obj7.gxTpr_Espectaculoid_Z;
         Z2EspectaculoName = obj7.gxTpr_Espectaculoname_Z;
         Gx_mode = obj7.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A15FuncionId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey077( ) ;
         ScanKeyStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z15FuncionId = A15FuncionId;
         }
         ZM077( -2) ;
         OnLoadActions077( ) ;
         AddRow077( ) ;
         ScanKeyEnd077( ) ;
         if ( RcdFound7 == 0 )
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
         RowToVars7( bcFuncion, 0) ;
         ScanKeyStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z15FuncionId = A15FuncionId;
         }
         ZM077( -2) ;
         OnLoadActions077( ) ;
         AddRow077( ) ;
         ScanKeyEnd077( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey077( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert077( ) ;
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A15FuncionId != Z15FuncionId )
               {
                  A15FuncionId = Z15FuncionId;
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
                  Update077( ) ;
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
                  if ( A15FuncionId != Z15FuncionId )
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
                        Insert077( ) ;
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
                        Insert077( ) ;
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
         RowToVars7( bcFuncion, 1) ;
         SaveImpl( ) ;
         VarsToRow7( bcFuncion) ;
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
         RowToVars7( bcFuncion, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert077( ) ;
         AfterTrn( ) ;
         VarsToRow7( bcFuncion) ;
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
            SdtFuncion auxBC = new SdtFuncion(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A15FuncionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcFuncion);
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
         RowToVars7( bcFuncion, 1) ;
         UpdateImpl( ) ;
         VarsToRow7( bcFuncion) ;
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
         RowToVars7( bcFuncion, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert077( ) ;
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
         VarsToRow7( bcFuncion) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars7( bcFuncion, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey077( ) ;
         if ( RcdFound7 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A15FuncionId != Z15FuncionId )
            {
               A15FuncionId = Z15FuncionId;
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
            if ( A15FuncionId != Z15FuncionId )
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
         pr_default.close(8);
         context.RollbackDataStores("funcion_bc",pr_default);
         VarsToRow7( bcFuncion) ;
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
         Gx_mode = bcFuncion.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcFuncion.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcFuncion )
         {
            bcFuncion = (SdtFuncion)(sdt);
            if ( StringUtil.StrCmp(bcFuncion.gxTpr_Mode, "") == 0 )
            {
               bcFuncion.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow7( bcFuncion) ;
            }
            else
            {
               RowToVars7( bcFuncion, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcFuncion.gxTpr_Mode, "") == 0 )
            {
               bcFuncion.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars7( bcFuncion, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtFuncion Funcion_BC
      {
         get {
            return bcFuncion ;
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
         pr_default.close(8);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z22FuncionName = "";
         A22FuncionName = "";
         Z2EspectaculoName = "";
         A2EspectaculoName = "";
         BC00075_A15FuncionId = new short[1] ;
         BC00075_A22FuncionName = new string[] {""} ;
         BC00075_A21PrecioFuncion = new short[1] ;
         BC00075_A2EspectaculoName = new string[] {""} ;
         BC00075_A1EspectaculoId = new short[1] ;
         BC00074_A2EspectaculoName = new string[] {""} ;
         BC00076_A15FuncionId = new short[1] ;
         BC00073_A15FuncionId = new short[1] ;
         BC00073_A22FuncionName = new string[] {""} ;
         BC00073_A21PrecioFuncion = new short[1] ;
         BC00073_A1EspectaculoId = new short[1] ;
         sMode7 = "";
         BC00072_A15FuncionId = new short[1] ;
         BC00072_A22FuncionName = new string[] {""} ;
         BC00072_A21PrecioFuncion = new short[1] ;
         BC00072_A1EspectaculoId = new short[1] ;
         BC00077_A15FuncionId = new short[1] ;
         BC000710_A2EspectaculoName = new string[] {""} ;
         BC000711_A24InvitacionId = new short[1] ;
         BC000712_A15FuncionId = new short[1] ;
         BC000712_A22FuncionName = new string[] {""} ;
         BC000712_A21PrecioFuncion = new short[1] ;
         BC000712_A2EspectaculoName = new string[] {""} ;
         BC000712_A1EspectaculoId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.funcion_bc__default(),
            new Object[][] {
                new Object[] {
               BC00072_A15FuncionId, BC00072_A22FuncionName, BC00072_A21PrecioFuncion, BC00072_A1EspectaculoId
               }
               , new Object[] {
               BC00073_A15FuncionId, BC00073_A22FuncionName, BC00073_A21PrecioFuncion, BC00073_A1EspectaculoId
               }
               , new Object[] {
               BC00074_A2EspectaculoName
               }
               , new Object[] {
               BC00075_A15FuncionId, BC00075_A22FuncionName, BC00075_A21PrecioFuncion, BC00075_A2EspectaculoName, BC00075_A1EspectaculoId
               }
               , new Object[] {
               BC00076_A15FuncionId
               }
               , new Object[] {
               BC00077_A15FuncionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000710_A2EspectaculoName
               }
               , new Object[] {
               BC000711_A24InvitacionId
               }
               , new Object[] {
               BC000712_A15FuncionId, BC000712_A22FuncionName, BC000712_A21PrecioFuncion, BC000712_A2EspectaculoName, BC000712_A1EspectaculoId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12072 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z15FuncionId ;
      private short A15FuncionId ;
      private short GX_JID ;
      private short Z21PrecioFuncion ;
      private short A21PrecioFuncion ;
      private short Z1EspectaculoId ;
      private short A1EspectaculoId ;
      private short RcdFound7 ;
      private short nIsDirty_7 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode7 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z22FuncionName ;
      private string A22FuncionName ;
      private string Z2EspectaculoName ;
      private string A2EspectaculoName ;
      private SdtFuncion bcFuncion ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00075_A15FuncionId ;
      private string[] BC00075_A22FuncionName ;
      private short[] BC00075_A21PrecioFuncion ;
      private string[] BC00075_A2EspectaculoName ;
      private short[] BC00075_A1EspectaculoId ;
      private string[] BC00074_A2EspectaculoName ;
      private short[] BC00076_A15FuncionId ;
      private short[] BC00073_A15FuncionId ;
      private string[] BC00073_A22FuncionName ;
      private short[] BC00073_A21PrecioFuncion ;
      private short[] BC00073_A1EspectaculoId ;
      private short[] BC00072_A15FuncionId ;
      private string[] BC00072_A22FuncionName ;
      private short[] BC00072_A21PrecioFuncion ;
      private short[] BC00072_A1EspectaculoId ;
      private short[] BC00077_A15FuncionId ;
      private string[] BC000710_A2EspectaculoName ;
      private short[] BC000711_A24InvitacionId ;
      private short[] BC000712_A15FuncionId ;
      private string[] BC000712_A22FuncionName ;
      private short[] BC000712_A21PrecioFuncion ;
      private string[] BC000712_A2EspectaculoName ;
      private short[] BC000712_A1EspectaculoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class funcion_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00075;
          prmBC00075 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmBC00074;
          prmBC00074 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00076;
          prmBC00076 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmBC00073;
          prmBC00073 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmBC00072;
          prmBC00072 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmBC00077;
          prmBC00077 = new Object[] {
          new ParDef("@FuncionName",GXType.NVarChar,40,0) ,
          new ParDef("@PrecioFuncion",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC00078;
          prmBC00078 = new Object[] {
          new ParDef("@FuncionName",GXType.NVarChar,40,0) ,
          new ParDef("@PrecioFuncion",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmBC00079;
          prmBC00079 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmBC000710;
          prmBC000710 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmBC000711;
          prmBC000711 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmBC000712;
          prmBC000712 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00072", "SELECT [FuncionId], [FuncionName], [PrecioFuncion], [EspectaculoId] FROM [Funcion] WITH (UPDLOCK) WHERE [FuncionId] = @FuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00073", "SELECT [FuncionId], [FuncionName], [PrecioFuncion], [EspectaculoId] FROM [Funcion] WHERE [FuncionId] = @FuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00074", "SELECT [EspectaculoName] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00074,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00075", "SELECT TM1.[FuncionId], TM1.[FuncionName], TM1.[PrecioFuncion], T2.[EspectaculoName], TM1.[EspectaculoId] FROM ([Funcion] TM1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = TM1.[EspectaculoId]) WHERE TM1.[FuncionId] = @FuncionId ORDER BY TM1.[FuncionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00075,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00076", "SELECT [FuncionId] FROM [Funcion] WHERE [FuncionId] = @FuncionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00076,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00077", "INSERT INTO [Funcion]([FuncionName], [PrecioFuncion], [EspectaculoId]) VALUES(@FuncionName, @PrecioFuncion, @EspectaculoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00077,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00078", "UPDATE [Funcion] SET [FuncionName]=@FuncionName, [PrecioFuncion]=@PrecioFuncion, [EspectaculoId]=@EspectaculoId  WHERE [FuncionId] = @FuncionId", GxErrorMask.GX_NOMASK,prmBC00078)
             ,new CursorDef("BC00079", "DELETE FROM [Funcion]  WHERE [FuncionId] = @FuncionId", GxErrorMask.GX_NOMASK,prmBC00079)
             ,new CursorDef("BC000710", "SELECT [EspectaculoName] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000710,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000711", "SELECT TOP 1 [InvitacionId] FROM [Invitacion] WHERE [FuncionId] = @FuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000711,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000712", "SELECT TM1.[FuncionId], TM1.[FuncionName], TM1.[PrecioFuncion], T2.[EspectaculoName], TM1.[EspectaculoId] FROM ([Funcion] TM1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = TM1.[EspectaculoId]) WHERE TM1.[FuncionId] = @FuncionId ORDER BY TM1.[FuncionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000712,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
