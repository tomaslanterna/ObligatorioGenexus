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
   public class cliente_bc : GXHttpHandler, IGxSilentTrn
   {
      public cliente_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public cliente_bc( IGxContext context )
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
         ReadRow055( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey055( ) ;
         standaloneModal( ) ;
         AddRow055( ) ;
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
            E11052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z9ClienteId = A9ClienteId;
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

      protected void CONFIRM_050( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls055( ) ;
            }
            else
            {
               CheckExtendedTable055( ) ;
               if ( AnyError == 0 )
               {
                  ZM055( 3) ;
               }
               CloseExtendedTableCursors055( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12052( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11052( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z10ClienteName = A10ClienteName;
            Z3PaisId = A3PaisId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z6PaisName = A6PaisName;
         }
         if ( GX_JID == -2 )
         {
            Z9ClienteId = A9ClienteId;
            Z10ClienteName = A10ClienteName;
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

      protected void Load055( )
      {
         /* Using cursor BC00055 */
         pr_default.execute(3, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound5 = 1;
            A10ClienteName = BC00055_A10ClienteName[0];
            A6PaisName = BC00055_A6PaisName[0];
            A3PaisId = BC00055_A3PaisId[0];
            ZM055( -2) ;
         }
         pr_default.close(3);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
      }

      protected void CheckExtendedTable055( )
      {
         nIsDirty_5 = 0;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A10ClienteName)) )
         {
            GX_msglist.addItem("Se debe ingresar un nombre", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00054 */
         pr_default.execute(2, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = BC00054_A6PaisName[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors055( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey055( )
      {
         /* Using cursor BC00056 */
         pr_default.execute(4, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00053 */
         pr_default.execute(1, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 2) ;
            RcdFound5 = 1;
            A9ClienteId = BC00053_A9ClienteId[0];
            A10ClienteName = BC00053_A10ClienteName[0];
            A3PaisId = BC00053_A3PaisId[0];
            Z9ClienteId = A9ClienteId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode5;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
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
         CONFIRM_050( ) ;
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

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00052 */
            pr_default.execute(0, new Object[] {A9ClienteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cliente"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z10ClienteName, BC00052_A10ClienteName[0]) != 0 ) || ( Z3PaisId != BC00052_A3PaisId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Cliente"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00057 */
                     pr_default.execute(5, new Object[] {A10ClienteName, A3PaisId});
                     A9ClienteId = BC00057_A9ClienteId[0];
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Cliente");
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
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00058 */
                     pr_default.execute(6, new Object[] {A10ClienteName, A3PaisId, A9ClienteId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Cliente");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cliente"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
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
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00059 */
                  pr_default.execute(7, new Object[] {A9ClienteId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("Cliente");
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel055( ) ;
         Gx_mode = sMode5;
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000510 */
            pr_default.execute(8, new Object[] {A3PaisId});
            A6PaisName = BC000510_A6PaisName[0];
            pr_default.close(8);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000511 */
            pr_default.execute(9, new Object[] {A9ClienteId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Entrada"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel055( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
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

      public void ScanKeyStart055( )
      {
         /* Scan By routine */
         /* Using cursor BC000512 */
         pr_default.execute(10, new Object[] {A9ClienteId});
         RcdFound5 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound5 = 1;
            A9ClienteId = BC000512_A9ClienteId[0];
            A10ClienteName = BC000512_A10ClienteName[0];
            A6PaisName = BC000512_A6PaisName[0];
            A3PaisId = BC000512_A3PaisId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound5 = 0;
         ScanKeyLoad055( ) ;
      }

      protected void ScanKeyLoad055( )
      {
         sMode5 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound5 = 1;
            A9ClienteId = BC000512_A9ClienteId[0];
            A10ClienteName = BC000512_A10ClienteName[0];
            A6PaisName = BC000512_A6PaisName[0];
            A3PaisId = BC000512_A3PaisId[0];
         }
         Gx_mode = sMode5;
      }

      protected void ScanKeyEnd055( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes055( )
      {
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void AddRow055( )
      {
         VarsToRow5( bcCliente) ;
      }

      protected void ReadRow055( )
      {
         RowToVars5( bcCliente, 1) ;
      }

      protected void InitializeNonKey055( )
      {
         A10ClienteName = "";
         A3PaisId = 0;
         A6PaisName = "";
         Z10ClienteName = "";
         Z3PaisId = 0;
      }

      protected void InitAll055( )
      {
         A9ClienteId = 0;
         InitializeNonKey055( ) ;
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

      public void VarsToRow5( SdtCliente obj5 )
      {
         obj5.gxTpr_Mode = Gx_mode;
         obj5.gxTpr_Clientename = A10ClienteName;
         obj5.gxTpr_Paisid = A3PaisId;
         obj5.gxTpr_Paisname = A6PaisName;
         obj5.gxTpr_Clienteid = A9ClienteId;
         obj5.gxTpr_Clienteid_Z = Z9ClienteId;
         obj5.gxTpr_Clientename_Z = Z10ClienteName;
         obj5.gxTpr_Paisid_Z = Z3PaisId;
         obj5.gxTpr_Paisname_Z = Z6PaisName;
         obj5.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow5( SdtCliente obj5 )
      {
         obj5.gxTpr_Clienteid = A9ClienteId;
         return  ;
      }

      public void RowToVars5( SdtCliente obj5 ,
                              int forceLoad )
      {
         Gx_mode = obj5.gxTpr_Mode;
         A10ClienteName = obj5.gxTpr_Clientename;
         A3PaisId = obj5.gxTpr_Paisid;
         A6PaisName = obj5.gxTpr_Paisname;
         A9ClienteId = obj5.gxTpr_Clienteid;
         Z9ClienteId = obj5.gxTpr_Clienteid_Z;
         Z10ClienteName = obj5.gxTpr_Clientename_Z;
         Z3PaisId = obj5.gxTpr_Paisid_Z;
         Z6PaisName = obj5.gxTpr_Paisname_Z;
         Gx_mode = obj5.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A9ClienteId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey055( ) ;
         ScanKeyStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z9ClienteId = A9ClienteId;
         }
         ZM055( -2) ;
         OnLoadActions055( ) ;
         AddRow055( ) ;
         ScanKeyEnd055( ) ;
         if ( RcdFound5 == 0 )
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
         RowToVars5( bcCliente, 0) ;
         ScanKeyStart055( ) ;
         if ( RcdFound5 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z9ClienteId = A9ClienteId;
         }
         ZM055( -2) ;
         OnLoadActions055( ) ;
         AddRow055( ) ;
         ScanKeyEnd055( ) ;
         if ( RcdFound5 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert055( ) ;
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A9ClienteId != Z9ClienteId )
               {
                  A9ClienteId = Z9ClienteId;
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
                  Update055( ) ;
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
                  if ( A9ClienteId != Z9ClienteId )
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
                        Insert055( ) ;
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
                        Insert055( ) ;
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
         RowToVars5( bcCliente, 1) ;
         SaveImpl( ) ;
         VarsToRow5( bcCliente) ;
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
         RowToVars5( bcCliente, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert055( ) ;
         AfterTrn( ) ;
         VarsToRow5( bcCliente) ;
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
            SdtCliente auxBC = new SdtCliente(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A9ClienteId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCliente);
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
         RowToVars5( bcCliente, 1) ;
         UpdateImpl( ) ;
         VarsToRow5( bcCliente) ;
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
         RowToVars5( bcCliente, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert055( ) ;
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
         VarsToRow5( bcCliente) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars5( bcCliente, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey055( ) ;
         if ( RcdFound5 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A9ClienteId != Z9ClienteId )
            {
               A9ClienteId = Z9ClienteId;
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
            if ( A9ClienteId != Z9ClienteId )
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
         context.RollbackDataStores("cliente_bc",pr_default);
         VarsToRow5( bcCliente) ;
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
         Gx_mode = bcCliente.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCliente.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCliente )
         {
            bcCliente = (SdtCliente)(sdt);
            if ( StringUtil.StrCmp(bcCliente.gxTpr_Mode, "") == 0 )
            {
               bcCliente.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow5( bcCliente) ;
            }
            else
            {
               RowToVars5( bcCliente, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCliente.gxTpr_Mode, "") == 0 )
            {
               bcCliente.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars5( bcCliente, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtCliente Cliente_BC
      {
         get {
            return bcCliente ;
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
         Z10ClienteName = "";
         A10ClienteName = "";
         Z6PaisName = "";
         A6PaisName = "";
         BC00055_A9ClienteId = new short[1] ;
         BC00055_A10ClienteName = new string[] {""} ;
         BC00055_A6PaisName = new string[] {""} ;
         BC00055_A3PaisId = new short[1] ;
         BC00054_A6PaisName = new string[] {""} ;
         BC00056_A9ClienteId = new short[1] ;
         BC00053_A9ClienteId = new short[1] ;
         BC00053_A10ClienteName = new string[] {""} ;
         BC00053_A3PaisId = new short[1] ;
         sMode5 = "";
         BC00052_A9ClienteId = new short[1] ;
         BC00052_A10ClienteName = new string[] {""} ;
         BC00052_A3PaisId = new short[1] ;
         BC00057_A9ClienteId = new short[1] ;
         BC000510_A6PaisName = new string[] {""} ;
         BC000511_A23EntradaId = new short[1] ;
         BC000512_A9ClienteId = new short[1] ;
         BC000512_A10ClienteName = new string[] {""} ;
         BC000512_A6PaisName = new string[] {""} ;
         BC000512_A3PaisId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cliente_bc__default(),
            new Object[][] {
                new Object[] {
               BC00052_A9ClienteId, BC00052_A10ClienteName, BC00052_A3PaisId
               }
               , new Object[] {
               BC00053_A9ClienteId, BC00053_A10ClienteName, BC00053_A3PaisId
               }
               , new Object[] {
               BC00054_A6PaisName
               }
               , new Object[] {
               BC00055_A9ClienteId, BC00055_A10ClienteName, BC00055_A6PaisName, BC00055_A3PaisId
               }
               , new Object[] {
               BC00056_A9ClienteId
               }
               , new Object[] {
               BC00057_A9ClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000510_A6PaisName
               }
               , new Object[] {
               BC000511_A23EntradaId
               }
               , new Object[] {
               BC000512_A9ClienteId, BC000512_A10ClienteName, BC000512_A6PaisName, BC000512_A3PaisId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12052 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z9ClienteId ;
      private short A9ClienteId ;
      private short GX_JID ;
      private short Z3PaisId ;
      private short A3PaisId ;
      private short RcdFound5 ;
      private short nIsDirty_5 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode5 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z10ClienteName ;
      private string A10ClienteName ;
      private string Z6PaisName ;
      private string A6PaisName ;
      private SdtCliente bcCliente ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00055_A9ClienteId ;
      private string[] BC00055_A10ClienteName ;
      private string[] BC00055_A6PaisName ;
      private short[] BC00055_A3PaisId ;
      private string[] BC00054_A6PaisName ;
      private short[] BC00056_A9ClienteId ;
      private short[] BC00053_A9ClienteId ;
      private string[] BC00053_A10ClienteName ;
      private short[] BC00053_A3PaisId ;
      private short[] BC00052_A9ClienteId ;
      private string[] BC00052_A10ClienteName ;
      private short[] BC00052_A3PaisId ;
      private short[] BC00057_A9ClienteId ;
      private string[] BC000510_A6PaisName ;
      private short[] BC000511_A23EntradaId ;
      private short[] BC000512_A9ClienteId ;
      private string[] BC000512_A10ClienteName ;
      private string[] BC000512_A6PaisName ;
      private short[] BC000512_A3PaisId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class cliente_bc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmBC00055;
          prmBC00055 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmBC00054;
          prmBC00054 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00056;
          prmBC00056 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmBC00053;
          prmBC00053 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmBC00052;
          prmBC00052 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmBC00057;
          prmBC00057 = new Object[] {
          new ParDef("@ClienteName",GXType.NVarChar,40,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00058;
          prmBC00058 = new Object[] {
          new ParDef("@ClienteName",GXType.NVarChar,40,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmBC00059;
          prmBC00059 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmBC000510;
          prmBC000510 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000511;
          prmBC000511 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmBC000512;
          prmBC000512 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00052", "SELECT [ClienteId], [ClienteName], [PaisId] FROM [Cliente] WITH (UPDLOCK) WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00053", "SELECT [ClienteId], [ClienteName], [PaisId] FROM [Cliente] WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00054", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00054,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00055", "SELECT TM1.[ClienteId], TM1.[ClienteName], T2.[PaisName], TM1.[PaisId] FROM ([Cliente] TM1 INNER JOIN [Pais] T2 ON T2.[PaisId] = TM1.[PaisId]) WHERE TM1.[ClienteId] = @ClienteId ORDER BY TM1.[ClienteId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00055,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00056", "SELECT [ClienteId] FROM [Cliente] WHERE [ClienteId] = @ClienteId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00056,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00057", "INSERT INTO [Cliente]([ClienteName], [PaisId]) VALUES(@ClienteName, @PaisId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00057,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00058", "UPDATE [Cliente] SET [ClienteName]=@ClienteName, [PaisId]=@PaisId  WHERE [ClienteId] = @ClienteId", GxErrorMask.GX_NOMASK,prmBC00058)
             ,new CursorDef("BC00059", "DELETE FROM [Cliente]  WHERE [ClienteId] = @ClienteId", GxErrorMask.GX_NOMASK,prmBC00059)
             ,new CursorDef("BC000510", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000510,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000511", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000511,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000512", "SELECT TM1.[ClienteId], TM1.[ClienteName], T2.[PaisName], TM1.[PaisId] FROM ([Cliente] TM1 INNER JOIN [Pais] T2 ON T2.[PaisId] = TM1.[PaisId]) WHERE TM1.[ClienteId] = @ClienteId ORDER BY TM1.[ClienteId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000512,100, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
