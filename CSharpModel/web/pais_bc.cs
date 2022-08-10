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
   public class pais_bc : GXHttpHandler, IGxSilentTrn
   {
      public pais_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public pais_bc( IGxContext context )
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
         ReadRow033( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey033( ) ;
         standaloneModal( ) ;
         AddRow033( ) ;
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
            E11032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z3PaisId = A3PaisId;
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

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12032( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11032( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z6PaisName = A6PaisName;
         }
         if ( GX_JID == -2 )
         {
            Z3PaisId = A3PaisId;
            Z6PaisName = A6PaisName;
            Z39PaisFlag = A39PaisFlag;
            Z40000PaisFlag_GXI = A40000PaisFlag_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load033( )
      {
         /* Using cursor BC00034 */
         pr_default.execute(2, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound3 = 1;
            A6PaisName = BC00034_A6PaisName[0];
            A40000PaisFlag_GXI = BC00034_A40000PaisFlag_GXI[0];
            n40000PaisFlag_GXI = BC00034_n40000PaisFlag_GXI[0];
            A39PaisFlag = BC00034_A39PaisFlag[0];
            n39PaisFlag = BC00034_n39PaisFlag[0];
            ZM033( -2) ;
         }
         pr_default.close(2);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
      }

      protected void CheckExtendedTable033( )
      {
         nIsDirty_3 = 0;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A6PaisName)) )
         {
            GX_msglist.addItem("Debe ingresar un nombre", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors033( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey033( )
      {
         /* Using cursor BC00035 */
         pr_default.execute(3, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00033 */
         pr_default.execute(1, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 2) ;
            RcdFound3 = 1;
            A3PaisId = BC00033_A3PaisId[0];
            A6PaisName = BC00033_A6PaisName[0];
            A40000PaisFlag_GXI = BC00033_A40000PaisFlag_GXI[0];
            n40000PaisFlag_GXI = BC00033_n40000PaisFlag_GXI[0];
            A39PaisFlag = BC00033_A39PaisFlag[0];
            n39PaisFlag = BC00033_n39PaisFlag[0];
            Z3PaisId = A3PaisId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode3;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
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
         CONFIRM_030( ) ;
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

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00032 */
            pr_default.execute(0, new Object[] {A3PaisId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Pais"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z6PaisName, BC00032_A6PaisName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Pais"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00036 */
                     pr_default.execute(4, new Object[] {A6PaisName, n39PaisFlag, A39PaisFlag, n40000PaisFlag_GXI, A40000PaisFlag_GXI});
                     A3PaisId = BC00036_A3PaisId[0];
                     pr_default.close(4);
                     dsDefault.SmartCacheProvider.SetUpdated("Pais");
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00037 */
                     pr_default.execute(5, new Object[] {A6PaisName, A3PaisId});
                     pr_default.close(5);
                     dsDefault.SmartCacheProvider.SetUpdated("Pais");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Pais"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
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
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC00038 */
            pr_default.execute(6, new Object[] {n39PaisFlag, A39PaisFlag, n40000PaisFlag_GXI, A40000PaisFlag_GXI, A3PaisId});
            pr_default.close(6);
            dsDefault.SmartCacheProvider.SetUpdated("Pais");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00039 */
                  pr_default.execute(7, new Object[] {A3PaisId});
                  pr_default.close(7);
                  dsDefault.SmartCacheProvider.SetUpdated("Pais");
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel033( ) ;
         Gx_mode = sMode3;
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000310 */
            pr_default.execute(8, new Object[] {A3PaisId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC000311 */
            pr_default.execute(9, new Object[] {A3PaisId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lugar"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
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

      public void ScanKeyStart033( )
      {
         /* Scan By routine */
         /* Using cursor BC000312 */
         pr_default.execute(10, new Object[] {A3PaisId});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound3 = 1;
            A3PaisId = BC000312_A3PaisId[0];
            A6PaisName = BC000312_A6PaisName[0];
            A40000PaisFlag_GXI = BC000312_A40000PaisFlag_GXI[0];
            n40000PaisFlag_GXI = BC000312_n40000PaisFlag_GXI[0];
            A39PaisFlag = BC000312_A39PaisFlag[0];
            n39PaisFlag = BC000312_n39PaisFlag[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound3 = 0;
         ScanKeyLoad033( ) ;
      }

      protected void ScanKeyLoad033( )
      {
         sMode3 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound3 = 1;
            A3PaisId = BC000312_A3PaisId[0];
            A6PaisName = BC000312_A6PaisName[0];
            A40000PaisFlag_GXI = BC000312_A40000PaisFlag_GXI[0];
            n40000PaisFlag_GXI = BC000312_n40000PaisFlag_GXI[0];
            A39PaisFlag = BC000312_A39PaisFlag[0];
            n39PaisFlag = BC000312_n39PaisFlag[0];
         }
         Gx_mode = sMode3;
      }

      protected void ScanKeyEnd033( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void AddRow033( )
      {
         VarsToRow3( bcPais) ;
      }

      protected void ReadRow033( )
      {
         RowToVars3( bcPais, 1) ;
      }

      protected void InitializeNonKey033( )
      {
         A6PaisName = "";
         A39PaisFlag = "";
         n39PaisFlag = false;
         A40000PaisFlag_GXI = "";
         n40000PaisFlag_GXI = false;
         Z6PaisName = "";
      }

      protected void InitAll033( )
      {
         A3PaisId = 0;
         InitializeNonKey033( ) ;
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

      public void VarsToRow3( SdtPais obj3 )
      {
         obj3.gxTpr_Mode = Gx_mode;
         obj3.gxTpr_Paisname = A6PaisName;
         obj3.gxTpr_Paisflag = A39PaisFlag;
         obj3.gxTpr_Paisflag_gxi = A40000PaisFlag_GXI;
         obj3.gxTpr_Paisid = A3PaisId;
         obj3.gxTpr_Paisid_Z = Z3PaisId;
         obj3.gxTpr_Paisname_Z = Z6PaisName;
         obj3.gxTpr_Paisflag_gxi_Z = Z40000PaisFlag_GXI;
         obj3.gxTpr_Paisflag_N = (short)(Convert.ToInt16(n39PaisFlag));
         obj3.gxTpr_Paisflag_gxi_N = (short)(Convert.ToInt16(n40000PaisFlag_GXI));
         obj3.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow3( SdtPais obj3 )
      {
         obj3.gxTpr_Paisid = A3PaisId;
         return  ;
      }

      public void RowToVars3( SdtPais obj3 ,
                              int forceLoad )
      {
         Gx_mode = obj3.gxTpr_Mode;
         A6PaisName = obj3.gxTpr_Paisname;
         A39PaisFlag = obj3.gxTpr_Paisflag;
         n39PaisFlag = false;
         A40000PaisFlag_GXI = obj3.gxTpr_Paisflag_gxi;
         n40000PaisFlag_GXI = false;
         A3PaisId = obj3.gxTpr_Paisid;
         Z3PaisId = obj3.gxTpr_Paisid_Z;
         Z6PaisName = obj3.gxTpr_Paisname_Z;
         Z40000PaisFlag_GXI = obj3.gxTpr_Paisflag_gxi_Z;
         n39PaisFlag = (bool)(Convert.ToBoolean(obj3.gxTpr_Paisflag_N));
         n40000PaisFlag_GXI = (bool)(Convert.ToBoolean(obj3.gxTpr_Paisflag_gxi_N));
         Gx_mode = obj3.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A3PaisId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey033( ) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z3PaisId = A3PaisId;
         }
         ZM033( -2) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
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
         RowToVars3( bcPais, 0) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z3PaisId = A3PaisId;
         }
         ZM033( -2) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert033( ) ;
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A3PaisId != Z3PaisId )
               {
                  A3PaisId = Z3PaisId;
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
                  Update033( ) ;
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
                  if ( A3PaisId != Z3PaisId )
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
                        Insert033( ) ;
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
                        Insert033( ) ;
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
         RowToVars3( bcPais, 1) ;
         SaveImpl( ) ;
         VarsToRow3( bcPais) ;
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
         RowToVars3( bcPais, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
         AfterTrn( ) ;
         VarsToRow3( bcPais) ;
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
            SdtPais auxBC = new SdtPais(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A3PaisId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPais);
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
         RowToVars3( bcPais, 1) ;
         UpdateImpl( ) ;
         VarsToRow3( bcPais) ;
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
         RowToVars3( bcPais, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
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
         VarsToRow3( bcPais) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars3( bcPais, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey033( ) ;
         if ( RcdFound3 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A3PaisId != Z3PaisId )
            {
               A3PaisId = Z3PaisId;
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
            if ( A3PaisId != Z3PaisId )
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
         context.RollbackDataStores("pais_bc",pr_default);
         VarsToRow3( bcPais) ;
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
         Gx_mode = bcPais.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPais.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPais )
         {
            bcPais = (SdtPais)(sdt);
            if ( StringUtil.StrCmp(bcPais.gxTpr_Mode, "") == 0 )
            {
               bcPais.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow3( bcPais) ;
            }
            else
            {
               RowToVars3( bcPais, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPais.gxTpr_Mode, "") == 0 )
            {
               bcPais.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars3( bcPais, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtPais Pais_BC
      {
         get {
            return bcPais ;
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
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z6PaisName = "";
         A6PaisName = "";
         Z39PaisFlag = "";
         A39PaisFlag = "";
         Z40000PaisFlag_GXI = "";
         A40000PaisFlag_GXI = "";
         BC00034_A3PaisId = new short[1] ;
         BC00034_A6PaisName = new string[] {""} ;
         BC00034_A40000PaisFlag_GXI = new string[] {""} ;
         BC00034_n40000PaisFlag_GXI = new bool[] {false} ;
         BC00034_A39PaisFlag = new string[] {""} ;
         BC00034_n39PaisFlag = new bool[] {false} ;
         BC00035_A3PaisId = new short[1] ;
         BC00033_A3PaisId = new short[1] ;
         BC00033_A6PaisName = new string[] {""} ;
         BC00033_A40000PaisFlag_GXI = new string[] {""} ;
         BC00033_n40000PaisFlag_GXI = new bool[] {false} ;
         BC00033_A39PaisFlag = new string[] {""} ;
         BC00033_n39PaisFlag = new bool[] {false} ;
         sMode3 = "";
         BC00032_A3PaisId = new short[1] ;
         BC00032_A6PaisName = new string[] {""} ;
         BC00032_A40000PaisFlag_GXI = new string[] {""} ;
         BC00032_n40000PaisFlag_GXI = new bool[] {false} ;
         BC00032_A39PaisFlag = new string[] {""} ;
         BC00032_n39PaisFlag = new bool[] {false} ;
         BC00036_A3PaisId = new short[1] ;
         BC000310_A9ClienteId = new short[1] ;
         BC000311_A4LugarId = new short[1] ;
         BC000312_A3PaisId = new short[1] ;
         BC000312_A6PaisName = new string[] {""} ;
         BC000312_A40000PaisFlag_GXI = new string[] {""} ;
         BC000312_n40000PaisFlag_GXI = new bool[] {false} ;
         BC000312_A39PaisFlag = new string[] {""} ;
         BC000312_n39PaisFlag = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pais_bc__default(),
            new Object[][] {
                new Object[] {
               BC00032_A3PaisId, BC00032_A6PaisName, BC00032_A40000PaisFlag_GXI, BC00032_n40000PaisFlag_GXI, BC00032_A39PaisFlag, BC00032_n39PaisFlag
               }
               , new Object[] {
               BC00033_A3PaisId, BC00033_A6PaisName, BC00033_A40000PaisFlag_GXI, BC00033_n40000PaisFlag_GXI, BC00033_A39PaisFlag, BC00033_n39PaisFlag
               }
               , new Object[] {
               BC00034_A3PaisId, BC00034_A6PaisName, BC00034_A40000PaisFlag_GXI, BC00034_n40000PaisFlag_GXI, BC00034_A39PaisFlag, BC00034_n39PaisFlag
               }
               , new Object[] {
               BC00035_A3PaisId
               }
               , new Object[] {
               BC00036_A3PaisId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000310_A9ClienteId
               }
               , new Object[] {
               BC000311_A4LugarId
               }
               , new Object[] {
               BC000312_A3PaisId, BC000312_A6PaisName, BC000312_A40000PaisFlag_GXI, BC000312_n40000PaisFlag_GXI, BC000312_A39PaisFlag, BC000312_n39PaisFlag
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12032 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z3PaisId ;
      private short A3PaisId ;
      private short GX_JID ;
      private short RcdFound3 ;
      private short nIsDirty_3 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode3 ;
      private bool returnInSub ;
      private bool n40000PaisFlag_GXI ;
      private bool n39PaisFlag ;
      private bool mustCommit ;
      private string Z6PaisName ;
      private string A6PaisName ;
      private string Z40000PaisFlag_GXI ;
      private string A40000PaisFlag_GXI ;
      private string Z39PaisFlag ;
      private string A39PaisFlag ;
      private SdtPais bcPais ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00034_A3PaisId ;
      private string[] BC00034_A6PaisName ;
      private string[] BC00034_A40000PaisFlag_GXI ;
      private bool[] BC00034_n40000PaisFlag_GXI ;
      private string[] BC00034_A39PaisFlag ;
      private bool[] BC00034_n39PaisFlag ;
      private short[] BC00035_A3PaisId ;
      private short[] BC00033_A3PaisId ;
      private string[] BC00033_A6PaisName ;
      private string[] BC00033_A40000PaisFlag_GXI ;
      private bool[] BC00033_n40000PaisFlag_GXI ;
      private string[] BC00033_A39PaisFlag ;
      private bool[] BC00033_n39PaisFlag ;
      private short[] BC00032_A3PaisId ;
      private string[] BC00032_A6PaisName ;
      private string[] BC00032_A40000PaisFlag_GXI ;
      private bool[] BC00032_n40000PaisFlag_GXI ;
      private string[] BC00032_A39PaisFlag ;
      private bool[] BC00032_n39PaisFlag ;
      private short[] BC00036_A3PaisId ;
      private short[] BC000310_A9ClienteId ;
      private short[] BC000311_A4LugarId ;
      private short[] BC000312_A3PaisId ;
      private string[] BC000312_A6PaisName ;
      private string[] BC000312_A40000PaisFlag_GXI ;
      private bool[] BC000312_n40000PaisFlag_GXI ;
      private string[] BC000312_A39PaisFlag ;
      private bool[] BC000312_n39PaisFlag ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class pais_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[5])
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
          Object[] prmBC00034;
          prmBC00034 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00035;
          prmBC00035 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00033;
          prmBC00033 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00032;
          prmBC00032 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00036;
          prmBC00036 = new Object[] {
          new ParDef("@PaisName",GXType.NVarChar,40,0) ,
          new ParDef("@PaisFlag",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
          new ParDef("@PaisFlag_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=1, Tbl="Pais", Fld="PaisFlag"}
          };
          Object[] prmBC00037;
          prmBC00037 = new Object[] {
          new ParDef("@PaisName",GXType.NVarChar,40,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00038;
          prmBC00038 = new Object[] {
          new ParDef("@PaisFlag",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
          new ParDef("@PaisFlag_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="Pais", Fld="PaisFlag"} ,
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00039;
          prmBC00039 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000310;
          prmBC000310 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000311;
          prmBC000311 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000312;
          prmBC000312 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00032", "SELECT [PaisId], [PaisName], [PaisFlag_GXI], [PaisFlag] FROM [Pais] WITH (UPDLOCK) WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00033", "SELECT [PaisId], [PaisName], [PaisFlag_GXI], [PaisFlag] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00034", "SELECT TM1.[PaisId], TM1.[PaisName], TM1.[PaisFlag_GXI], TM1.[PaisFlag] FROM [Pais] TM1 WHERE TM1.[PaisId] = @PaisId ORDER BY TM1.[PaisId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00034,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00035", "SELECT [PaisId] FROM [Pais] WHERE [PaisId] = @PaisId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00035,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00036", "INSERT INTO [Pais]([PaisName], [PaisFlag], [PaisFlag_GXI]) VALUES(@PaisName, @PaisFlag, @PaisFlag_GXI); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmBC00036,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC00037", "UPDATE [Pais] SET [PaisName]=@PaisName  WHERE [PaisId] = @PaisId", GxErrorMask.GX_NOMASK,prmBC00037)
             ,new CursorDef("BC00038", "UPDATE [Pais] SET [PaisFlag]=@PaisFlag, [PaisFlag_GXI]=@PaisFlag_GXI  WHERE [PaisId] = @PaisId", GxErrorMask.GX_NOMASK,prmBC00038)
             ,new CursorDef("BC00039", "DELETE FROM [Pais]  WHERE [PaisId] = @PaisId", GxErrorMask.GX_NOMASK,prmBC00039)
             ,new CursorDef("BC000310", "SELECT TOP 1 [ClienteId] FROM [Cliente] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000310,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000311", "SELECT TOP 1 [LugarId] FROM [Lugar] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000311,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000312", "SELECT TM1.[PaisId], TM1.[PaisName], TM1.[PaisFlag_GXI], TM1.[PaisFlag] FROM [Pais] TM1 WHERE TM1.[PaisId] = @PaisId ORDER BY TM1.[PaisId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000312,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
