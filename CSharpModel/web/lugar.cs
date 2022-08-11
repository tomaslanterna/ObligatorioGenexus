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
   public class lugar : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A4LugarId = (short)(NumberUtil.Val( GetPar( "LugarId"), "."));
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A4LugarId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A3PaisId = (short)(NumberUtil.Val( GetPar( "PaisId"), "."));
            AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A3PaisId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlugar_sector") == 0 )
         {
            gxnrGridlugar_sector_newrow_invoke( ) ;
            return  ;
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7LugarId = (short)(NumberUtil.Val( GetPar( "LugarId"), "."));
               AssignAttri("", false, "AV7LugarId", StringUtil.LTrimStr( (decimal)(AV7LugarId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vLUGARID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7LugarId), "ZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_10-162473", 0) ;
            }
            Form.Meta.addItem("description", "Lugar", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLugarName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlugar_sector_newrow_invoke( )
      {
         nRC_GXsfl_58 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_58"), "."));
         nGXsfl_58_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_58_idx"), "."));
         sGXsfl_58_idx = GetPar( "sGXsfl_58_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlugar_sector_newrow( ) ;
         /* End function gxnrGridlugar_sector_newrow_invoke */
      }

      public lugar( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public lugar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_LugarId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7LugarId = aP1_LugarId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Lugar", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLugarId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLugarId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ",", "")), StringUtil.LTrim( ((edtLugarId_Enabled!=0) ? context.localUtil.Format( (decimal)(A4LugarId), "ZZZ9") : context.localUtil.Format( (decimal)(A4LugarId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLugarName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLugarName_Internalname, A5LugarName, StringUtil.RTrim( context.localUtil.Format( A5LugarName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaisId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisId_Internalname, "Pais Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A3PaisId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Lugar.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_3_Internalname, sImgUrl, imgprompt_3_Link, "", "", context.GetTheme( ), imgprompt_3_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaisName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisName_Internalname, "Pais Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPaisName_Internalname, A6PaisName, StringUtil.RTrim( context.localUtil.Format( A6PaisName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectortable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlesector_Internalname, "Sector", "", "", lblTitlesector_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridlugar_sector( ) ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Lugar.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridlugar_sector( )
      {
         /*  Grid Control  */
         StartGridControl58( ) ;
         nGXsfl_58_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount11 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_11 = 1;
               ScanStart0211( ) ;
               while ( RcdFound11 != 0 )
               {
                  init_level_properties11( ) ;
                  getByPrimaryKey0211( ) ;
                  AddRow0211( ) ;
                  ScanNext0211( ) ;
               }
               ScanEnd0211( ) ;
               nBlankRcdCount11 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B40000GXC1 = A40000GXC1;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
            standaloneNotModal0211( ) ;
            standaloneModal0211( ) ;
            sMode11 = Gx_mode;
            while ( nGXsfl_58_idx < nRC_GXsfl_58 )
            {
               bGXsfl_58_Refreshing = true;
               ReadRow0211( ) ;
               edtLugarSectorId_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORID_"+sGXsfl_58_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), !bGXsfl_58_Refreshing);
               edtLugarSectorName_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORNAME_"+sGXsfl_58_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtLugarSectorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorName_Enabled), 5, 0), !bGXsfl_58_Refreshing);
               edtLugarSectorCantidad_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORCANTIDAD_"+sGXsfl_58_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtLugarSectorCantidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorCantidad_Enabled), 5, 0), !bGXsfl_58_Refreshing);
               edtLugarSectorPrecio_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORPRECIO_"+sGXsfl_58_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtLugarSectorPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0), !bGXsfl_58_Refreshing);
               if ( ( nRcdExists_11 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0211( ) ;
               }
               SendRow0211( ) ;
               bGXsfl_58_Refreshing = false;
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A40000GXC1 = B40000GXC1;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount11 = 5;
            nRcdExists_11 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0211( ) ;
               while ( RcdFound11 != 0 )
               {
                  sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_5811( ) ;
                  init_level_properties11( ) ;
                  standaloneNotModal0211( ) ;
                  getByPrimaryKey0211( ) ;
                  standaloneModal0211( ) ;
                  AddRow0211( ) ;
                  ScanNext0211( ) ;
               }
               ScanEnd0211( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode11 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx+1), 4, 0), 4, "0");
            SubsflControlProps_5811( ) ;
            InitAll0211( ) ;
            init_level_properties11( ) ;
            B40000GXC1 = A40000GXC1;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
            nRcdExists_11 = 0;
            nIsMod_11 = 0;
            nRcdDeleted_11 = 0;
            nBlankRcdCount11 = (short)(nBlankRcdUsr11+nBlankRcdCount11);
            fRowAdded = 0;
            while ( nBlankRcdCount11 > 0 )
            {
               standaloneNotModal0211( ) ;
               standaloneModal0211( ) ;
               AddRow0211( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtLugarSectorName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount11 = (short)(nBlankRcdCount11-1);
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A40000GXC1 = B40000GXC1;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlugar_sectorContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlugar_sector", Gridlugar_sectorContainer, subGridlugar_sector_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlugar_sectorContainerData", Gridlugar_sectorContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlugar_sectorContainerData"+"V", Gridlugar_sectorContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlugar_sectorContainerData"+"V"+"\" value='"+Gridlugar_sectorContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11022 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z4LugarId = (short)(context.localUtil.CToN( cgiGet( "Z4LugarId"), ",", "."));
               Z5LugarName = cgiGet( "Z5LugarName");
               Z3PaisId = (short)(context.localUtil.CToN( cgiGet( "Z3PaisId"), ",", "."));
               O40000GXC1 = (int)(context.localUtil.CToN( cgiGet( "O40000GXC1"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_58 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_58"), ",", "."));
               N3PaisId = (short)(context.localUtil.CToN( cgiGet( "N3PaisId"), ",", "."));
               AV7LugarId = (short)(context.localUtil.CToN( cgiGet( "vLUGARID"), ",", "."));
               AV11Insert_PaisId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_PAISID"), ",", "."));
               A40000GXC1 = (int)(context.localUtil.CToN( cgiGet( "GXC1"), ",", "."));
               AV13Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A4LugarId = (short)(context.localUtil.CToN( cgiGet( edtLugarId_Internalname), ",", "."));
               AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
               A5LugarName = cgiGet( edtLugarName_Internalname);
               AssignAttri("", false, "A5LugarName", A5LugarName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPaisId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPaisId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAISID");
                  AnyError = 1;
                  GX_FocusControl = edtPaisId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A3PaisId = 0;
                  AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
               }
               else
               {
                  A3PaisId = (short)(context.localUtil.CToN( cgiGet( edtPaisId_Internalname), ",", "."));
                  AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
               }
               A6PaisName = cgiGet( edtPaisName_Internalname);
               AssignAttri("", false, "A6PaisName", A6PaisName);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Lugar");
               A4LugarId = (short)(context.localUtil.CToN( cgiGet( edtLugarId_Internalname), ",", "."));
               AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
               forbiddenHiddens.Add("LugarId", context.localUtil.Format( (decimal)(A4LugarId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A4LugarId != Z4LugarId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("lugar:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusDescription = 403.ToString();
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A4LugarId = (short)(NumberUtil.Val( GetPar( "LugarId"), "."));
                  AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode2 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode2;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound2 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "LUGARID");
                        AnyError = 1;
                        GX_FocusControl = edtLugarId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12022 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
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
            E12022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll022( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
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

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes022( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
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
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0211( )
      {
         s40000GXC1 = O40000GXC1;
         n40000GXC1 = false;
         AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         nGXsfl_58_idx = 0;
         while ( nGXsfl_58_idx < nRC_GXsfl_58 )
         {
            ReadRow0211( ) ;
            if ( ( nRcdExists_11 != 0 ) || ( nIsMod_11 != 0 ) )
            {
               GetKey0211( ) ;
               if ( ( nRcdExists_11 == 0 ) && ( nRcdDeleted_11 == 0 ) )
               {
                  if ( RcdFound11 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0211( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0211( ) ;
                        CloseExtendedTableCursors0211( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O40000GXC1 = A40000GXC1;
                        n40000GXC1 = false;
                        AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
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
                     if ( nRcdDeleted_11 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0211( ) ;
                        Load0211( ) ;
                        BeforeValidate0211( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0211( ) ;
                           O40000GXC1 = A40000GXC1;
                           n40000GXC1 = false;
                           AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_11 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0211( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0211( ) ;
                              CloseExtendedTableCursors0211( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O40000GXC1 = A40000GXC1;
                              n40000GXC1 = false;
                              AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_11 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            ChangePostValue( edtLugarSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A27LugarSectorId), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorName_Internalname, A28LugarSectorName) ;
            ChangePostValue( edtLugarSectorCantidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A29LugarSectorCantidad), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z27LugarSectorId_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z27LugarSectorId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z28LugarSectorName_"+sGXsfl_58_idx, Z28LugarSectorName) ;
            ChangePostValue( "ZT_"+"Z29LugarSectorCantidad_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29LugarSectorCantidad), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z30LugarSectorPrecio_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30LugarSectorPrecio), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_11_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_11), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_11_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_11), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_11_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_11), 4, 0, ",", ""))) ;
            if ( nIsMod_11 != 0 )
            {
               ChangePostValue( "LUGARSECTORID_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORNAME_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORCANTIDAD_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorCantidad_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORPRECIO_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O40000GXC1 = s40000GXC1;
         n40000GXC1 = false;
         AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         /* Start of After( level) rules */
         /* Using cursor T00025 */
         pr_default.execute(2, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A40000GXC1 = T00025_A40000GXC1[0];
            n40000GXC1 = T00025_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         if ( A40000GXC1 < 0 )
         {
            GX_msglist.addItem("El lugar debe tener al menos un sector", 1, "");
            AnyError = 1;
         }
         /* End of After( level) rules */
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_PaisId = 0;
         AssignAttri("", false, "AV11Insert_PaisId", StringUtil.LTrimStr( (decimal)(AV11Insert_PaisId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV13Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV14GXV1 = 1;
            AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            while ( AV14GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV14GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "PaisId") == 0 )
               {
                  AV11Insert_PaisId = (short)(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_PaisId", StringUtil.LTrimStr( (decimal)(AV11Insert_PaisId), 4, 0));
               }
               AV14GXV1 = (int)(AV14GXV1+1);
               AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Eliminar";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwlugar.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(2);
         returnInSub = true;
         if (true) return;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z5LugarName = T00027_A5LugarName[0];
               Z3PaisId = T00027_A3PaisId[0];
            }
            else
            {
               Z5LugarName = A5LugarName;
               Z3PaisId = A3PaisId;
            }
         }
         if ( GX_JID == -13 )
         {
            Z4LugarId = A4LugarId;
            Z5LugarName = A5LugarName;
            Z3PaisId = A3PaisId;
            Z40000GXC1 = A40000GXC1;
            Z6PaisName = A6PaisName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtLugarId_Enabled = 0;
         AssignProp("", false, edtLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarId_Enabled), 5, 0), true);
         imgprompt_3_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISID"+"'), id:'"+"PAISID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtLugarId_Enabled = 0;
         AssignProp("", false, edtLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7LugarId) )
         {
            A4LugarId = AV7LugarId;
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PaisId) )
         {
            edtPaisId_Enabled = 0;
            AssignProp("", false, edtPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisId_Enabled), 5, 0), true);
         }
         else
         {
            edtPaisId_Enabled = 1;
            AssignProp("", false, edtPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PaisId) )
         {
            A3PaisId = AV11Insert_PaisId;
            AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00025 */
            pr_default.execute(2, new Object[] {A4LugarId});
            if ( (pr_default.getStatus(2) != 101) )
            {
               A40000GXC1 = T00025_A40000GXC1[0];
               n40000GXC1 = T00025_n40000GXC1[0];
            }
            else
            {
               A40000GXC1 = 0;
               n40000GXC1 = false;
               AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
            }
            O40000GXC1 = A40000GXC1;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
            pr_default.close(2);
            AV13Pgmname = "Lugar";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T00028 */
            pr_default.execute(5, new Object[] {A3PaisId});
            A6PaisName = T00028_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            pr_default.close(5);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T000210 */
         pr_default.execute(6, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound2 = 1;
            A5LugarName = T000210_A5LugarName[0];
            AssignAttri("", false, "A5LugarName", A5LugarName);
            A6PaisName = T000210_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            A3PaisId = T000210_A3PaisId[0];
            AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            A40000GXC1 = T000210_A40000GXC1[0];
            n40000GXC1 = T000210_n40000GXC1[0];
            ZM022( -13) ;
         }
         pr_default.close(6);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         O40000GXC1 = A40000GXC1;
         n40000GXC1 = false;
         AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         AV13Pgmname = "Lugar";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV13Pgmname = "Lugar";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         /* Using cursor T00025 */
         pr_default.execute(2, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A40000GXC1 = T00025_A40000GXC1[0];
            n40000GXC1 = T00025_n40000GXC1[0];
         }
         else
         {
            nIsDirty_2 = 1;
            A40000GXC1 = 0;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         pr_default.close(2);
         if ( A40000GXC1 < 0 )
         {
            GX_msglist.addItem("El lugar debe tener al menos un sector", 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A5LugarName)) )
         {
            GX_msglist.addItem("Ingrese un nombre.", 1, "LUGARNAME");
            AnyError = 1;
            GX_FocusControl = edtLugarName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00028 */
         pr_default.execute(5, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A6PaisName = T00028_A6PaisName[0];
         AssignAttri("", false, "A6PaisName", A6PaisName);
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( short A4LugarId )
      {
         /* Using cursor T000212 */
         pr_default.execute(7, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A40000GXC1 = T000212_A40000GXC1[0];
            n40000GXC1 = T000212_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A40000GXC1), 9, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_14( short A3PaisId )
      {
         /* Using cursor T000213 */
         pr_default.execute(8, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A6PaisName = T000213_A6PaisName[0];
         AssignAttri("", false, "A6PaisName", A6PaisName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A6PaisName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey022( )
      {
         /* Using cursor T000214 */
         pr_default.execute(9, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00027 */
         pr_default.execute(4, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM022( 13) ;
            RcdFound2 = 1;
            A4LugarId = T00027_A4LugarId[0];
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            A5LugarName = T00027_A5LugarName[0];
            AssignAttri("", false, "A5LugarName", A5LugarName);
            A3PaisId = T00027_A3PaisId[0];
            AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            Z4LugarId = A4LugarId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T000215 */
         pr_default.execute(10, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000215_A4LugarId[0] < A4LugarId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000215_A4LugarId[0] > A4LugarId ) ) )
            {
               A4LugarId = T000215_A4LugarId[0];
               AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T000216 */
         pr_default.execute(11, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000216_A4LugarId[0] > A4LugarId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000216_A4LugarId[0] < A4LugarId ) ) )
            {
               A4LugarId = T000216_A4LugarId[0];
               AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A40000GXC1 = O40000GXC1;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
            GX_FocusControl = edtLugarName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A4LugarId != Z4LugarId )
               {
                  A4LugarId = Z4LugarId;
                  AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LUGARID");
                  AnyError = 1;
                  GX_FocusControl = edtLugarId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A40000GXC1 = O40000GXC1;
                  n40000GXC1 = false;
                  AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLugarName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A40000GXC1 = O40000GXC1;
                  n40000GXC1 = false;
                  AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
                  Update022( ) ;
                  GX_FocusControl = edtLugarName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A4LugarId != Z4LugarId )
               {
                  /* Insert record */
                  A40000GXC1 = O40000GXC1;
                  n40000GXC1 = false;
                  AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
                  GX_FocusControl = edtLugarName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LUGARID");
                     AnyError = 1;
                     GX_FocusControl = edtLugarId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A40000GXC1 = O40000GXC1;
                     n40000GXC1 = false;
                     AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
                     GX_FocusControl = edtLugarName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A4LugarId != Z4LugarId )
         {
            A4LugarId = Z4LugarId;
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LUGARID");
            AnyError = 1;
            GX_FocusControl = edtLugarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A40000GXC1 = O40000GXC1;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLugarName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00026 */
            pr_default.execute(3, new Object[] {A4LugarId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Lugar"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z5LugarName, T00026_A5LugarName[0]) != 0 ) || ( Z3PaisId != T00026_A3PaisId[0] ) )
            {
               if ( StringUtil.StrCmp(Z5LugarName, T00026_A5LugarName[0]) != 0 )
               {
                  GXUtil.WriteLog("lugar:[seudo value changed for attri]"+"LugarName");
                  GXUtil.WriteLogRaw("Old: ",Z5LugarName);
                  GXUtil.WriteLogRaw("Current: ",T00026_A5LugarName[0]);
               }
               if ( Z3PaisId != T00026_A3PaisId[0] )
               {
                  GXUtil.WriteLog("lugar:[seudo value changed for attri]"+"PaisId");
                  GXUtil.WriteLogRaw("Old: ",Z3PaisId);
                  GXUtil.WriteLogRaw("Current: ",T00026_A3PaisId[0]);
               }
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
                     /* Using cursor T000217 */
                     pr_default.execute(12, new Object[] {A5LugarName, A3PaisId});
                     A4LugarId = T000217_A4LugarId[0];
                     AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
                     pr_default.close(12);
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
                              ResetCaption020( ) ;
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
                     /* Using cursor T000218 */
                     pr_default.execute(13, new Object[] {A5LugarName, A3PaisId, A4LugarId});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("Lugar");
                     if ( (pr_default.getStatus(13) == 103) )
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
                              if ( IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
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
                  A40000GXC1 = O40000GXC1;
                  n40000GXC1 = false;
                  AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
                  ScanStart0211( ) ;
                  while ( RcdFound11 != 0 )
                  {
                     getByPrimaryKey0211( ) ;
                     Delete0211( ) ;
                     ScanNext0211( ) ;
                     O40000GXC1 = A40000GXC1;
                     n40000GXC1 = false;
                     AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
                  }
                  ScanEnd0211( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000219 */
                     pr_default.execute(14, new Object[] {A4LugarId});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("Lugar");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
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
            }
         }
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "Lugar";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T000221 */
            pr_default.execute(15, new Object[] {A4LugarId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               A40000GXC1 = T000221_A40000GXC1[0];
               n40000GXC1 = T000221_n40000GXC1[0];
            }
            else
            {
               A40000GXC1 = 0;
               n40000GXC1 = false;
               AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
            }
            pr_default.close(15);
            /* Using cursor T000222 */
            pr_default.execute(16, new Object[] {A3PaisId});
            A6PaisName = T000222_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            pr_default.close(16);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000223 */
            pr_default.execute(17, new Object[] {A4LugarId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Espectaculo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void ProcessNestedLevel0211( )
      {
         s40000GXC1 = O40000GXC1;
         n40000GXC1 = false;
         AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         nGXsfl_58_idx = 0;
         while ( nGXsfl_58_idx < nRC_GXsfl_58 )
         {
            ReadRow0211( ) ;
            if ( ( nRcdExists_11 != 0 ) || ( nIsMod_11 != 0 ) )
            {
               standaloneNotModal0211( ) ;
               GetKey0211( ) ;
               if ( ( nRcdExists_11 == 0 ) && ( nRcdDeleted_11 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0211( ) ;
               }
               else
               {
                  if ( RcdFound11 != 0 )
                  {
                     if ( ( nRcdDeleted_11 != 0 ) && ( nRcdExists_11 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0211( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_11 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0211( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_11 == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               O40000GXC1 = A40000GXC1;
               n40000GXC1 = false;
               AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
            }
            ChangePostValue( edtLugarSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A27LugarSectorId), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorName_Internalname, A28LugarSectorName) ;
            ChangePostValue( edtLugarSectorCantidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A29LugarSectorCantidad), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z27LugarSectorId_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z27LugarSectorId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z28LugarSectorName_"+sGXsfl_58_idx, Z28LugarSectorName) ;
            ChangePostValue( "ZT_"+"Z29LugarSectorCantidad_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29LugarSectorCantidad), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z30LugarSectorPrecio_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30LugarSectorPrecio), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_11_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_11), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_11_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_11), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_11_"+sGXsfl_58_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_11), 4, 0, ",", ""))) ;
            if ( nIsMod_11 != 0 )
            {
               ChangePostValue( "LUGARSECTORID_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORNAME_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORCANTIDAD_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorCantidad_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORPRECIO_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* Using cursor T000221 */
         pr_default.execute(15, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            A40000GXC1 = T000221_A40000GXC1[0];
            n40000GXC1 = T000221_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         if ( A40000GXC1 < 0 )
         {
            GX_msglist.addItem("El lugar debe tener al menos un sector", 1, "");
            AnyError = 1;
         }
         /* End of After( level) rules */
         InitAll0211( ) ;
         if ( AnyError != 0 )
         {
            O40000GXC1 = s40000GXC1;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         nRcdExists_11 = 0;
         nIsMod_11 = 0;
         nRcdDeleted_11 = 0;
      }

      protected void ProcessLevel022( )
      {
         /* Save parent mode. */
         sMode2 = Gx_mode;
         ProcessNestedLevel0211( ) ;
         if ( AnyError != 0 )
         {
            O40000GXC1 = s40000GXC1;
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(16);
            pr_default.close(15);
            context.CommitDataStores("lugar",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(16);
            pr_default.close(15);
            context.RollbackDataStores("lugar",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Scan By routine */
         /* Using cursor T000224 */
         pr_default.execute(18);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound2 = 1;
            A4LugarId = T000224_A4LugarId[0];
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound2 = 1;
            A4LugarId = T000224_A4LugarId[0];
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(18);
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
         edtLugarId_Enabled = 0;
         AssignProp("", false, edtLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarId_Enabled), 5, 0), true);
         edtLugarName_Enabled = 0;
         AssignProp("", false, edtLugarName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarName_Enabled), 5, 0), true);
         edtPaisId_Enabled = 0;
         AssignProp("", false, edtPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisId_Enabled), 5, 0), true);
         edtPaisName_Enabled = 0;
         AssignProp("", false, edtPaisName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisName_Enabled), 5, 0), true);
      }

      protected void ZM0211( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z28LugarSectorName = T00023_A28LugarSectorName[0];
               Z29LugarSectorCantidad = T00023_A29LugarSectorCantidad[0];
               Z30LugarSectorPrecio = T00023_A30LugarSectorPrecio[0];
            }
            else
            {
               Z28LugarSectorName = A28LugarSectorName;
               Z29LugarSectorCantidad = A29LugarSectorCantidad;
               Z30LugarSectorPrecio = A30LugarSectorPrecio;
            }
         }
         if ( GX_JID == -16 )
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
         edtLugarSectorId_Enabled = 0;
         AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), !bGXsfl_58_Refreshing);
      }

      protected void standaloneModal0211( )
      {
      }

      protected void Load0211( )
      {
         /* Using cursor T000225 */
         pr_default.execute(19, new Object[] {A4LugarId, A27LugarSectorId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound11 = 1;
            A28LugarSectorName = T000225_A28LugarSectorName[0];
            A29LugarSectorCantidad = T000225_A29LugarSectorCantidad[0];
            A30LugarSectorPrecio = T000225_A30LugarSectorPrecio[0];
            ZM0211( -16) ;
         }
         pr_default.close(19);
         OnLoadActions0211( ) ;
      }

      protected void OnLoadActions0211( )
      {
         if ( IsIns( )  )
         {
            A40000GXC1 = (int)(O40000GXC1+1);
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A40000GXC1 = O40000GXC1;
               n40000GXC1 = false;
               AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A40000GXC1 = (int)(O40000GXC1-1);
                  n40000GXC1 = false;
                  AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
               }
            }
         }
      }

      protected void CheckExtendedTable0211( )
      {
         nIsDirty_11 = 0;
         Gx_BScreen = 1;
         standaloneModal0211( ) ;
         if ( IsIns( )  )
         {
            nIsDirty_11 = 1;
            A40000GXC1 = (int)(O40000GXC1+1);
            n40000GXC1 = false;
            AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_11 = 1;
               A40000GXC1 = O40000GXC1;
               n40000GXC1 = false;
               AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_11 = 1;
                  A40000GXC1 = (int)(O40000GXC1-1);
                  n40000GXC1 = false;
                  AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
               }
            }
         }
         if ( A40000GXC1 < 0 )
         {
            GX_msglist.addItem("El lugar debe tener al menos un sector", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0211( )
      {
      }

      protected void enableDisable0211( )
      {
      }

      protected void GetKey0211( )
      {
         /* Using cursor T000226 */
         pr_default.execute(20, new Object[] {A4LugarId, A27LugarSectorId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(20);
      }

      protected void getByPrimaryKey0211( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A4LugarId, A27LugarSectorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0211( 16) ;
            RcdFound11 = 1;
            InitializeNonKey0211( ) ;
            A27LugarSectorId = T00023_A27LugarSectorId[0];
            A28LugarSectorName = T00023_A28LugarSectorName[0];
            A29LugarSectorCantidad = T00023_A29LugarSectorCantidad[0];
            A30LugarSectorPrecio = T00023_A30LugarSectorPrecio[0];
            Z4LugarId = A4LugarId;
            Z27LugarSectorId = A27LugarSectorId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0211( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0211( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0211( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
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
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A4LugarId, A27LugarSectorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"LugarSector"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z28LugarSectorName, T00022_A28LugarSectorName[0]) != 0 ) || ( Z29LugarSectorCantidad != T00022_A29LugarSectorCantidad[0] ) || ( Z30LugarSectorPrecio != T00022_A30LugarSectorPrecio[0] ) )
            {
               if ( StringUtil.StrCmp(Z28LugarSectorName, T00022_A28LugarSectorName[0]) != 0 )
               {
                  GXUtil.WriteLog("lugar:[seudo value changed for attri]"+"LugarSectorName");
                  GXUtil.WriteLogRaw("Old: ",Z28LugarSectorName);
                  GXUtil.WriteLogRaw("Current: ",T00022_A28LugarSectorName[0]);
               }
               if ( Z29LugarSectorCantidad != T00022_A29LugarSectorCantidad[0] )
               {
                  GXUtil.WriteLog("lugar:[seudo value changed for attri]"+"LugarSectorCantidad");
                  GXUtil.WriteLogRaw("Old: ",Z29LugarSectorCantidad);
                  GXUtil.WriteLogRaw("Current: ",T00022_A29LugarSectorCantidad[0]);
               }
               if ( Z30LugarSectorPrecio != T00022_A30LugarSectorPrecio[0] )
               {
                  GXUtil.WriteLog("lugar:[seudo value changed for attri]"+"LugarSectorPrecio");
                  GXUtil.WriteLogRaw("Old: ",Z30LugarSectorPrecio);
                  GXUtil.WriteLogRaw("Current: ",T00022_A30LugarSectorPrecio[0]);
               }
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
                     /* Using cursor T000227 */
                     pr_default.execute(21, new Object[] {A4LugarId, A27LugarSectorId, A28LugarSectorName, A29LugarSectorCantidad, A30LugarSectorPrecio});
                     pr_default.close(21);
                     dsDefault.SmartCacheProvider.SetUpdated("LugarSector");
                     if ( (pr_default.getStatus(21) == 1) )
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
         if ( ( nIsMod_11 != 0 ) || ( nIsDirty_11 != 0 ) )
         {
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
                        /* Using cursor T000228 */
                        pr_default.execute(22, new Object[] {A28LugarSectorName, A29LugarSectorCantidad, A30LugarSectorPrecio, A4LugarId, A27LugarSectorId});
                        pr_default.close(22);
                        dsDefault.SmartCacheProvider.SetUpdated("LugarSector");
                        if ( (pr_default.getStatus(22) == 103) )
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
         }
         CloseExtendedTableCursors0211( ) ;
      }

      protected void DeferredUpdate0211( )
      {
      }

      protected void Delete0211( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
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
                  /* Using cursor T000229 */
                  pr_default.execute(23, new Object[] {A4LugarId, A27LugarSectorId});
                  pr_default.close(23);
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
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0211( ) ;
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0211( )
      {
         standaloneModal0211( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( IsIns( )  )
            {
               A40000GXC1 = (int)(O40000GXC1+1);
               n40000GXC1 = false;
               AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A40000GXC1 = O40000GXC1;
                  n40000GXC1 = false;
                  AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A40000GXC1 = (int)(O40000GXC1-1);
                     n40000GXC1 = false;
                     AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
                  }
               }
            }
         }
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

      public void ScanStart0211( )
      {
         /* Scan By routine */
         /* Using cursor T000230 */
         pr_default.execute(24, new Object[] {A4LugarId});
         RcdFound11 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound11 = 1;
            A27LugarSectorId = T000230_A27LugarSectorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0211( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound11 = 1;
            A27LugarSectorId = T000230_A27LugarSectorId[0];
         }
      }

      protected void ScanEnd0211( )
      {
         pr_default.close(24);
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
         edtLugarSectorId_Enabled = 0;
         AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), !bGXsfl_58_Refreshing);
         edtLugarSectorName_Enabled = 0;
         AssignProp("", false, edtLugarSectorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorName_Enabled), 5, 0), !bGXsfl_58_Refreshing);
         edtLugarSectorCantidad_Enabled = 0;
         AssignProp("", false, edtLugarSectorCantidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorCantidad_Enabled), 5, 0), !bGXsfl_58_Refreshing);
         edtLugarSectorPrecio_Enabled = 0;
         AssignProp("", false, edtLugarSectorPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0), !bGXsfl_58_Refreshing);
      }

      protected void send_integrity_lvl_hashes0211( )
      {
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void SubsflControlProps_5811( )
      {
         edtLugarSectorId_Internalname = "LUGARSECTORID_"+sGXsfl_58_idx;
         edtLugarSectorName_Internalname = "LUGARSECTORNAME_"+sGXsfl_58_idx;
         edtLugarSectorCantidad_Internalname = "LUGARSECTORCANTIDAD_"+sGXsfl_58_idx;
         edtLugarSectorPrecio_Internalname = "LUGARSECTORPRECIO_"+sGXsfl_58_idx;
      }

      protected void SubsflControlProps_fel_5811( )
      {
         edtLugarSectorId_Internalname = "LUGARSECTORID_"+sGXsfl_58_fel_idx;
         edtLugarSectorName_Internalname = "LUGARSECTORNAME_"+sGXsfl_58_fel_idx;
         edtLugarSectorCantidad_Internalname = "LUGARSECTORCANTIDAD_"+sGXsfl_58_fel_idx;
         edtLugarSectorPrecio_Internalname = "LUGARSECTORPRECIO_"+sGXsfl_58_fel_idx;
      }

      protected void AddRow0211( )
      {
         nGXsfl_58_idx = (int)(nGXsfl_58_idx+1);
         sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
         SubsflControlProps_5811( ) ;
         SendRow0211( ) ;
      }

      protected void SendRow0211( )
      {
         Gridlugar_sectorRow = GXWebRow.GetNew(context);
         if ( subGridlugar_sector_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlugar_sector_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlugar_sector_Class, "") != 0 )
            {
               subGridlugar_sector_Linesclass = subGridlugar_sector_Class+"Odd";
            }
         }
         else if ( subGridlugar_sector_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlugar_sector_Backstyle = 0;
            subGridlugar_sector_Backcolor = subGridlugar_sector_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlugar_sector_Class, "") != 0 )
            {
               subGridlugar_sector_Linesclass = subGridlugar_sector_Class+"Uniform";
            }
         }
         else if ( subGridlugar_sector_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlugar_sector_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlugar_sector_Class, "") != 0 )
            {
               subGridlugar_sector_Linesclass = subGridlugar_sector_Class+"Odd";
            }
            subGridlugar_sector_Backcolor = (int)(0x0);
         }
         else if ( subGridlugar_sector_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlugar_sector_Backstyle = 1;
            if ( ((int)((nGXsfl_58_idx) % (2))) == 0 )
            {
               subGridlugar_sector_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlugar_sector_Class, "") != 0 )
               {
                  subGridlugar_sector_Linesclass = subGridlugar_sector_Class+"Even";
               }
            }
            else
            {
               subGridlugar_sector_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlugar_sector_Class, "") != 0 )
               {
                  subGridlugar_sector_Linesclass = subGridlugar_sector_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlugar_sectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarSectorId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A27LugarSectorId), 4, 0, ",", "")),StringUtil.LTrim( ((edtLugarSectorId_Enabled!=0) ? context.localUtil.Format( (decimal)(A27LugarSectorId), "ZZZ9") : context.localUtil.Format( (decimal)(A27LugarSectorId), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarSectorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtLugarSectorId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)58,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_11_" + sGXsfl_58_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_58_idx + "',58)\"";
         ROClassString = "Attribute";
         Gridlugar_sectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarSectorName_Internalname,(string)A28LugarSectorName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarSectorName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtLugarSectorName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)58,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_11_" + sGXsfl_58_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 61,'',false,'" + sGXsfl_58_idx + "',58)\"";
         ROClassString = "Attribute";
         Gridlugar_sectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarSectorCantidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A29LugarSectorCantidad), 4, 0, ",", "")),StringUtil.LTrim( ((edtLugarSectorCantidad_Enabled!=0) ? context.localUtil.Format( (decimal)(A29LugarSectorCantidad), "ZZZ9") : context.localUtil.Format( (decimal)(A29LugarSectorCantidad), "ZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,61);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarSectorCantidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtLugarSectorCantidad_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)58,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_11_" + sGXsfl_58_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_58_idx + "',58)\"";
         ROClassString = "Attribute";
         Gridlugar_sectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarSectorPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ",", "")),StringUtil.LTrim( ((edtLugarSectorPrecio_Enabled!=0) ? context.localUtil.Format( (decimal)(A30LugarSectorPrecio), "ZZZ9") : context.localUtil.Format( (decimal)(A30LugarSectorPrecio), "ZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,62);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarSectorPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtLugarSectorPrecio_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)58,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridlugar_sectorRow);
         send_integrity_lvl_hashes0211( ) ;
         GXCCtl = "Z27LugarSectorId_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z27LugarSectorId), 4, 0, ",", "")));
         GXCCtl = "Z28LugarSectorName_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z28LugarSectorName);
         GXCCtl = "Z29LugarSectorCantidad_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29LugarSectorCantidad), 4, 0, ",", "")));
         GXCCtl = "Z30LugarSectorPrecio_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30LugarSectorPrecio), 4, 0, ",", "")));
         GXCCtl = "nRcdDeleted_11_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_11), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_11_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_11), 4, 0, ",", "")));
         GXCCtl = "nIsMod_11_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_11), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_58_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vLUGARID_" + sGXsfl_58_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7LugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORID_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORNAME_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORCANTIDAD_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorCantidad_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORPRECIO_"+sGXsfl_58_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridlugar_sectorContainer.AddRow(Gridlugar_sectorRow);
      }

      protected void ReadRow0211( )
      {
         nGXsfl_58_idx = (int)(nGXsfl_58_idx+1);
         sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
         SubsflControlProps_5811( ) ;
         edtLugarSectorId_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORID_"+sGXsfl_58_idx+"Enabled"), ",", "."));
         edtLugarSectorName_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORNAME_"+sGXsfl_58_idx+"Enabled"), ",", "."));
         edtLugarSectorCantidad_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORCANTIDAD_"+sGXsfl_58_idx+"Enabled"), ",", "."));
         edtLugarSectorPrecio_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORPRECIO_"+sGXsfl_58_idx+"Enabled"), ",", "."));
         A27LugarSectorId = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorId_Internalname), ",", "."));
         A28LugarSectorName = cgiGet( edtLugarSectorName_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtLugarSectorCantidad_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLugarSectorCantidad_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "LUGARSECTORCANTIDAD_" + sGXsfl_58_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtLugarSectorCantidad_Internalname;
            wbErr = true;
            A29LugarSectorCantidad = 0;
         }
         else
         {
            A29LugarSectorCantidad = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorCantidad_Internalname), ",", "."));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtLugarSectorPrecio_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLugarSectorPrecio_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "LUGARSECTORPRECIO_" + sGXsfl_58_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtLugarSectorPrecio_Internalname;
            wbErr = true;
            A30LugarSectorPrecio = 0;
         }
         else
         {
            A30LugarSectorPrecio = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorPrecio_Internalname), ",", "."));
         }
         GXCCtl = "Z27LugarSectorId_" + sGXsfl_58_idx;
         Z27LugarSectorId = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "Z28LugarSectorName_" + sGXsfl_58_idx;
         Z28LugarSectorName = cgiGet( GXCCtl);
         GXCCtl = "Z29LugarSectorCantidad_" + sGXsfl_58_idx;
         Z29LugarSectorCantidad = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "Z30LugarSectorPrecio_" + sGXsfl_58_idx;
         Z30LugarSectorPrecio = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdDeleted_11_" + sGXsfl_58_idx;
         nRcdDeleted_11 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdExists_11_" + sGXsfl_58_idx;
         nRcdExists_11 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nIsMod_11_" + sGXsfl_58_idx;
         nIsMod_11 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
      }

      protected void assign_properties_default( )
      {
         defedtLugarSectorId_Enabled = edtLugarSectorId_Enabled;
      }

      protected void ConfirmValues020( )
      {
         nGXsfl_58_idx = 0;
         sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
         SubsflControlProps_5811( ) ;
         while ( nGXsfl_58_idx < nRC_GXsfl_58 )
         {
            nGXsfl_58_idx = (int)(nGXsfl_58_idx+1);
            sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
            SubsflControlProps_5811( ) ;
            ChangePostValue( "Z27LugarSectorId_"+sGXsfl_58_idx, cgiGet( "ZT_"+"Z27LugarSectorId_"+sGXsfl_58_idx)) ;
            DeletePostValue( "ZT_"+"Z27LugarSectorId_"+sGXsfl_58_idx) ;
            ChangePostValue( "Z28LugarSectorName_"+sGXsfl_58_idx, cgiGet( "ZT_"+"Z28LugarSectorName_"+sGXsfl_58_idx)) ;
            DeletePostValue( "ZT_"+"Z28LugarSectorName_"+sGXsfl_58_idx) ;
            ChangePostValue( "Z29LugarSectorCantidad_"+sGXsfl_58_idx, cgiGet( "ZT_"+"Z29LugarSectorCantidad_"+sGXsfl_58_idx)) ;
            DeletePostValue( "ZT_"+"Z29LugarSectorCantidad_"+sGXsfl_58_idx) ;
            ChangePostValue( "Z30LugarSectorPrecio_"+sGXsfl_58_idx, cgiGet( "ZT_"+"Z30LugarSectorPrecio_"+sGXsfl_58_idx)) ;
            DeletePostValue( "ZT_"+"Z30LugarSectorPrecio_"+sGXsfl_58_idx) ;
         }
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 511400), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 511400), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 511400), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202281118293347", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("lugar.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7LugarId,4,0))}, new string[] {"Gx_mode","LugarId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Lugar");
         forbiddenHiddens.Add("LugarId", context.localUtil.Format( (decimal)(A4LugarId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("lugar:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z4LugarId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4LugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z5LugarName", Z5LugarName);
         GxWebStd.gx_hidden_field( context, "Z3PaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3PaisId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "O40000GXC1", StringUtil.LTrim( StringUtil.NToC( (decimal)(O40000GXC1), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_58", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_58_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N3PaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vLUGARID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7LugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLUGARID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7LugarId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_PaisId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXC1", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40000GXC1), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV13Pgmname));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("lugar.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7LugarId,4,0))}, new string[] {"Gx_mode","LugarId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Lugar" ;
      }

      public override string GetPgmdesc( )
      {
         return "Lugar" ;
      }

      protected void InitializeNonKey022( )
      {
         A3PaisId = 0;
         AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
         A5LugarName = "";
         AssignAttri("", false, "A5LugarName", A5LugarName);
         A6PaisName = "";
         AssignAttri("", false, "A6PaisName", A6PaisName);
         A40000GXC1 = 0;
         n40000GXC1 = false;
         AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         O40000GXC1 = A40000GXC1;
         n40000GXC1 = false;
         AssignAttri("", false, "A40000GXC1", StringUtil.LTrimStr( (decimal)(A40000GXC1), 9, 0));
         Z5LugarName = "";
         Z3PaisId = 0;
      }

      protected void InitAll022( )
      {
         A4LugarId = 0;
         AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
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

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281118293353", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("lugar.js", "?202281118293353", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties11( )
      {
         edtLugarSectorId_Enabled = defedtLugarSectorId_Enabled;
         AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), !bGXsfl_58_Refreshing);
      }

      protected void StartGridControl58( )
      {
         Gridlugar_sectorContainer.AddObjectProperty("GridName", "Gridlugar_sector");
         Gridlugar_sectorContainer.AddObjectProperty("Header", subGridlugar_sector_Header);
         Gridlugar_sectorContainer.AddObjectProperty("Class", "Grid");
         Gridlugar_sectorContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlugar_sectorContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlugar_sectorContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlugar_sector_Backcolorstyle), 1, 0, ".", "")));
         Gridlugar_sectorContainer.AddObjectProperty("CmpContext", "");
         Gridlugar_sectorContainer.AddObjectProperty("InMasterPage", "false");
         Gridlugar_sectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlugar_sectorColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A27LugarSectorId), 4, 0, ".", "")));
         Gridlugar_sectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorId_Enabled), 5, 0, ".", "")));
         Gridlugar_sectorContainer.AddColumnProperties(Gridlugar_sectorColumn);
         Gridlugar_sectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlugar_sectorColumn.AddObjectProperty("Value", A28LugarSectorName);
         Gridlugar_sectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorName_Enabled), 5, 0, ".", "")));
         Gridlugar_sectorContainer.AddColumnProperties(Gridlugar_sectorColumn);
         Gridlugar_sectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlugar_sectorColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29LugarSectorCantidad), 4, 0, ".", "")));
         Gridlugar_sectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorCantidad_Enabled), 5, 0, ".", "")));
         Gridlugar_sectorContainer.AddColumnProperties(Gridlugar_sectorColumn);
         Gridlugar_sectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlugar_sectorColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ".", "")));
         Gridlugar_sectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0, ".", "")));
         Gridlugar_sectorContainer.AddColumnProperties(Gridlugar_sectorColumn);
         Gridlugar_sectorContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlugar_sector_Selectedindex), 4, 0, ".", "")));
         Gridlugar_sectorContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlugar_sector_Allowselection), 1, 0, ".", "")));
         Gridlugar_sectorContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlugar_sector_Selectioncolor), 9, 0, ".", "")));
         Gridlugar_sectorContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlugar_sector_Allowhovering), 1, 0, ".", "")));
         Gridlugar_sectorContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlugar_sector_Hoveringcolor), 9, 0, ".", "")));
         Gridlugar_sectorContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlugar_sector_Allowcollapsing), 1, 0, ".", "")));
         Gridlugar_sectorContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlugar_sector_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtLugarId_Internalname = "LUGARID";
         edtLugarName_Internalname = "LUGARNAME";
         edtPaisId_Internalname = "PAISID";
         edtPaisName_Internalname = "PAISNAME";
         lblTitlesector_Internalname = "TITLESECTOR";
         edtLugarSectorId_Internalname = "LUGARSECTORID";
         edtLugarSectorName_Internalname = "LUGARSECTORNAME";
         edtLugarSectorCantidad_Internalname = "LUGARSECTORCANTIDAD";
         edtLugarSectorPrecio_Internalname = "LUGARSECTORPRECIO";
         divSectortable_Internalname = "SECTORTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_3_Internalname = "PROMPT_3";
         subGridlugar_sector_Internalname = "GRIDLUGAR_SECTOR";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlugar_sector_Allowcollapsing = 0;
         subGridlugar_sector_Allowselection = 0;
         subGridlugar_sector_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Lugar";
         edtLugarSectorPrecio_Jsonclick = "";
         edtLugarSectorCantidad_Jsonclick = "";
         edtLugarSectorName_Jsonclick = "";
         edtLugarSectorId_Jsonclick = "";
         subGridlugar_sector_Class = "Grid";
         subGridlugar_sector_Backcolorstyle = 0;
         edtLugarSectorPrecio_Enabled = 1;
         edtLugarSectorCantidad_Enabled = 1;
         edtLugarSectorName_Enabled = 1;
         edtLugarSectorId_Enabled = 0;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPaisName_Jsonclick = "";
         edtPaisName_Enabled = 0;
         imgprompt_3_Visible = 1;
         imgprompt_3_Link = "";
         edtPaisId_Jsonclick = "";
         edtPaisId_Enabled = 1;
         edtLugarName_Jsonclick = "";
         edtLugarName_Enabled = 1;
         edtLugarId_Jsonclick = "";
         edtLugarId_Enabled = 0;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridlugar_sector_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_5811( ) ;
         while ( nGXsfl_58_idx <= nRC_GXsfl_58 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0211( ) ;
            standaloneModal0211( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0211( ) ;
            nGXsfl_58_idx = (int)(nGXsfl_58_idx+1);
            sGXsfl_58_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_58_idx), 4, 0), 4, "0");
            SubsflControlProps_5811( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlugar_sectorContainer)) ;
         /* End function gxnrGridlugar_sector_newrow */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
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

      public void Valid_Lugarid( )
      {
         n40000GXC1 = false;
         /* Using cursor T000221 */
         pr_default.execute(15, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            A40000GXC1 = T000221_A40000GXC1[0];
            n40000GXC1 = T000221_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(15);
         if ( A40000GXC1 < 0 )
         {
            GX_msglist.addItem("El lugar debe tener al menos un sector", 1, "LUGARID");
            AnyError = 1;
            GX_FocusControl = edtLugarId_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A40000GXC1", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40000GXC1), 9, 0, ".", "")));
      }

      public void Valid_Paisid( )
      {
         /* Using cursor T000222 */
         pr_default.execute(16, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
            GX_FocusControl = edtPaisId_Internalname;
         }
         A6PaisName = T000222_A6PaisName[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A6PaisName", A6PaisName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7LugarId',fld:'vLUGARID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7LugarId',fld:'vLUGARID',pic:'ZZZ9',hsh:true},{av:'A4LugarId',fld:'LUGARID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12022',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_LUGARID","{handler:'Valid_Lugarid',iparms:[{av:'A4LugarId',fld:'LUGARID',pic:'ZZZ9'},{av:'A40000GXC1',fld:'GXC1',pic:'999999999'}]");
         setEventMetadata("VALID_LUGARID",",oparms:[{av:'A40000GXC1',fld:'GXC1',pic:'999999999'}]}");
         setEventMetadata("VALID_LUGARNAME","{handler:'Valid_Lugarname',iparms:[]");
         setEventMetadata("VALID_LUGARNAME",",oparms:[]}");
         setEventMetadata("VALID_PAISID","{handler:'Valid_Paisid',iparms:[{av:'A3PaisId',fld:'PAISID',pic:'ZZZ9'},{av:'A6PaisName',fld:'PAISNAME',pic:''}]");
         setEventMetadata("VALID_PAISID",",oparms:[{av:'A6PaisName',fld:'PAISNAME',pic:''}]}");
         setEventMetadata("VALID_LUGARSECTORID","{handler:'Valid_Lugarsectorid',iparms:[]");
         setEventMetadata("VALID_LUGARSECTORID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Lugarsectorprecio',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
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
         pr_default.close(4);
         pr_default.close(16);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z5LugarName = "";
         Z28LugarSectorName = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A5LugarName = "";
         sImgUrl = "";
         A6PaisName = "";
         lblTitlesector_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridlugar_sectorContainer = new GXWebGrid( context);
         sMode11 = "";
         sStyleString = "";
         AV13Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode2 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         A28LugarSectorName = "";
         T00025_A40000GXC1 = new int[1] ;
         T00025_n40000GXC1 = new bool[] {false} ;
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z6PaisName = "";
         T00028_A6PaisName = new string[] {""} ;
         T000210_A4LugarId = new short[1] ;
         T000210_A5LugarName = new string[] {""} ;
         T000210_A6PaisName = new string[] {""} ;
         T000210_A3PaisId = new short[1] ;
         T000210_A40000GXC1 = new int[1] ;
         T000210_n40000GXC1 = new bool[] {false} ;
         T000212_A40000GXC1 = new int[1] ;
         T000212_n40000GXC1 = new bool[] {false} ;
         T000213_A6PaisName = new string[] {""} ;
         T000214_A4LugarId = new short[1] ;
         T00027_A4LugarId = new short[1] ;
         T00027_A5LugarName = new string[] {""} ;
         T00027_A3PaisId = new short[1] ;
         T000215_A4LugarId = new short[1] ;
         T000216_A4LugarId = new short[1] ;
         T00026_A4LugarId = new short[1] ;
         T00026_A5LugarName = new string[] {""} ;
         T00026_A3PaisId = new short[1] ;
         T000217_A4LugarId = new short[1] ;
         T000221_A40000GXC1 = new int[1] ;
         T000221_n40000GXC1 = new bool[] {false} ;
         T000222_A6PaisName = new string[] {""} ;
         T000223_A1EspectaculoId = new short[1] ;
         T000224_A4LugarId = new short[1] ;
         T000225_A4LugarId = new short[1] ;
         T000225_A27LugarSectorId = new short[1] ;
         T000225_A28LugarSectorName = new string[] {""} ;
         T000225_A29LugarSectorCantidad = new short[1] ;
         T000225_A30LugarSectorPrecio = new short[1] ;
         T000226_A4LugarId = new short[1] ;
         T000226_A27LugarSectorId = new short[1] ;
         T00023_A4LugarId = new short[1] ;
         T00023_A27LugarSectorId = new short[1] ;
         T00023_A28LugarSectorName = new string[] {""} ;
         T00023_A29LugarSectorCantidad = new short[1] ;
         T00023_A30LugarSectorPrecio = new short[1] ;
         T00022_A4LugarId = new short[1] ;
         T00022_A27LugarSectorId = new short[1] ;
         T00022_A28LugarSectorName = new string[] {""} ;
         T00022_A29LugarSectorCantidad = new short[1] ;
         T00022_A30LugarSectorPrecio = new short[1] ;
         T000230_A4LugarId = new short[1] ;
         T000230_A27LugarSectorId = new short[1] ;
         Gridlugar_sectorRow = new GXWebRow();
         subGridlugar_sector_Linesclass = "";
         ROClassString = "";
         GXCCtl = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Gridlugar_sectorColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.lugar__default(),
            new Object[][] {
                new Object[] {
               T00022_A4LugarId, T00022_A27LugarSectorId, T00022_A28LugarSectorName, T00022_A29LugarSectorCantidad, T00022_A30LugarSectorPrecio
               }
               , new Object[] {
               T00023_A4LugarId, T00023_A27LugarSectorId, T00023_A28LugarSectorName, T00023_A29LugarSectorCantidad, T00023_A30LugarSectorPrecio
               }
               , new Object[] {
               T00025_A40000GXC1, T00025_n40000GXC1
               }
               , new Object[] {
               T00026_A4LugarId, T00026_A5LugarName, T00026_A3PaisId
               }
               , new Object[] {
               T00027_A4LugarId, T00027_A5LugarName, T00027_A3PaisId
               }
               , new Object[] {
               T00028_A6PaisName
               }
               , new Object[] {
               T000210_A4LugarId, T000210_A5LugarName, T000210_A6PaisName, T000210_A3PaisId, T000210_A40000GXC1, T000210_n40000GXC1
               }
               , new Object[] {
               T000212_A40000GXC1, T000212_n40000GXC1
               }
               , new Object[] {
               T000213_A6PaisName
               }
               , new Object[] {
               T000214_A4LugarId
               }
               , new Object[] {
               T000215_A4LugarId
               }
               , new Object[] {
               T000216_A4LugarId
               }
               , new Object[] {
               T000217_A4LugarId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000221_A40000GXC1, T000221_n40000GXC1
               }
               , new Object[] {
               T000222_A6PaisName
               }
               , new Object[] {
               T000223_A1EspectaculoId
               }
               , new Object[] {
               T000224_A4LugarId
               }
               , new Object[] {
               T000225_A4LugarId, T000225_A27LugarSectorId, T000225_A28LugarSectorName, T000225_A29LugarSectorCantidad, T000225_A30LugarSectorPrecio
               }
               , new Object[] {
               T000226_A4LugarId, T000226_A27LugarSectorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000230_A4LugarId, T000230_A27LugarSectorId
               }
            }
         );
         AV13Pgmname = "Lugar";
      }

      private short wcpOAV7LugarId ;
      private short Z4LugarId ;
      private short Z3PaisId ;
      private short N3PaisId ;
      private short Z27LugarSectorId ;
      private short Z29LugarSectorCantidad ;
      private short Z30LugarSectorPrecio ;
      private short nRcdDeleted_11 ;
      private short nRcdExists_11 ;
      private short nIsMod_11 ;
      private short GxWebError ;
      private short A4LugarId ;
      private short A3PaisId ;
      private short AV7LugarId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nBlankRcdCount11 ;
      private short RcdFound11 ;
      private short nBlankRcdUsr11 ;
      private short AV11Insert_PaisId ;
      private short RcdFound2 ;
      private short A27LugarSectorId ;
      private short A29LugarSectorCantidad ;
      private short A30LugarSectorPrecio ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_2 ;
      private short nIsDirty_11 ;
      private short subGridlugar_sector_Backcolorstyle ;
      private short subGridlugar_sector_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlugar_sector_Allowselection ;
      private short subGridlugar_sector_Allowhovering ;
      private short subGridlugar_sector_Allowcollapsing ;
      private short subGridlugar_sector_Collapsed ;
      private int O40000GXC1 ;
      private int nRC_GXsfl_58 ;
      private int nGXsfl_58_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtLugarId_Enabled ;
      private int edtLugarName_Enabled ;
      private int edtPaisId_Enabled ;
      private int imgprompt_3_Visible ;
      private int edtPaisName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int B40000GXC1 ;
      private int A40000GXC1 ;
      private int edtLugarSectorId_Enabled ;
      private int edtLugarSectorName_Enabled ;
      private int edtLugarSectorCantidad_Enabled ;
      private int edtLugarSectorPrecio_Enabled ;
      private int fRowAdded ;
      private int s40000GXC1 ;
      private int AV14GXV1 ;
      private int Z40000GXC1 ;
      private int subGridlugar_sector_Backcolor ;
      private int subGridlugar_sector_Allbackcolor ;
      private int defedtLugarSectorId_Enabled ;
      private int idxLst ;
      private int subGridlugar_sector_Selectedindex ;
      private int subGridlugar_sector_Selectioncolor ;
      private int subGridlugar_sector_Hoveringcolor ;
      private long GRIDLUGAR_SECTOR_nFirstRecordOnPage ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLugarName_Internalname ;
      private string sGXsfl_58_idx="0001" ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtLugarId_Internalname ;
      private string edtLugarId_Jsonclick ;
      private string edtLugarName_Jsonclick ;
      private string edtPaisId_Internalname ;
      private string edtPaisId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_3_Internalname ;
      private string imgprompt_3_Link ;
      private string edtPaisName_Internalname ;
      private string edtPaisName_Jsonclick ;
      private string divSectortable_Internalname ;
      private string lblTitlesector_Internalname ;
      private string lblTitlesector_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode11 ;
      private string edtLugarSectorId_Internalname ;
      private string edtLugarSectorName_Internalname ;
      private string edtLugarSectorCantidad_Internalname ;
      private string edtLugarSectorPrecio_Internalname ;
      private string sStyleString ;
      private string subGridlugar_sector_Internalname ;
      private string AV13Pgmname ;
      private string hsh ;
      private string sMode2 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sGXsfl_58_fel_idx="0001" ;
      private string subGridlugar_sector_Class ;
      private string subGridlugar_sector_Linesclass ;
      private string ROClassString ;
      private string edtLugarSectorId_Jsonclick ;
      private string edtLugarSectorName_Jsonclick ;
      private string edtLugarSectorCantidad_Jsonclick ;
      private string edtLugarSectorPrecio_Jsonclick ;
      private string GXCCtl ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridlugar_sector_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n40000GXC1 ;
      private bool bGXsfl_58_Refreshing=false ;
      private bool returnInSub ;
      private string Z5LugarName ;
      private string Z28LugarSectorName ;
      private string A5LugarName ;
      private string A6PaisName ;
      private string A28LugarSectorName ;
      private string Z6PaisName ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlugar_sectorContainer ;
      private GXWebRow Gridlugar_sectorRow ;
      private GXWebColumn Gridlugar_sectorColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00025_A40000GXC1 ;
      private bool[] T00025_n40000GXC1 ;
      private string[] T00028_A6PaisName ;
      private short[] T000210_A4LugarId ;
      private string[] T000210_A5LugarName ;
      private string[] T000210_A6PaisName ;
      private short[] T000210_A3PaisId ;
      private int[] T000210_A40000GXC1 ;
      private bool[] T000210_n40000GXC1 ;
      private int[] T000212_A40000GXC1 ;
      private bool[] T000212_n40000GXC1 ;
      private string[] T000213_A6PaisName ;
      private short[] T000214_A4LugarId ;
      private short[] T00027_A4LugarId ;
      private string[] T00027_A5LugarName ;
      private short[] T00027_A3PaisId ;
      private short[] T000215_A4LugarId ;
      private short[] T000216_A4LugarId ;
      private short[] T00026_A4LugarId ;
      private string[] T00026_A5LugarName ;
      private short[] T00026_A3PaisId ;
      private short[] T000217_A4LugarId ;
      private int[] T000221_A40000GXC1 ;
      private bool[] T000221_n40000GXC1 ;
      private string[] T000222_A6PaisName ;
      private short[] T000223_A1EspectaculoId ;
      private short[] T000224_A4LugarId ;
      private short[] T000225_A4LugarId ;
      private short[] T000225_A27LugarSectorId ;
      private string[] T000225_A28LugarSectorName ;
      private short[] T000225_A29LugarSectorCantidad ;
      private short[] T000225_A30LugarSectorPrecio ;
      private short[] T000226_A4LugarId ;
      private short[] T000226_A27LugarSectorId ;
      private short[] T00023_A4LugarId ;
      private short[] T00023_A27LugarSectorId ;
      private string[] T00023_A28LugarSectorName ;
      private short[] T00023_A29LugarSectorCantidad ;
      private short[] T00023_A30LugarSectorPrecio ;
      private short[] T00022_A4LugarId ;
      private short[] T00022_A27LugarSectorId ;
      private string[] T00022_A28LugarSectorName ;
      private short[] T00022_A29LugarSectorCantidad ;
      private short[] T00022_A30LugarSectorPrecio ;
      private short[] T000230_A4LugarId ;
      private short[] T000230_A27LugarSectorId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class lugar__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[13])
         ,new UpdateCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new UpdateCursor(def[21])
         ,new UpdateCursor(def[22])
         ,new UpdateCursor(def[23])
         ,new ForEachCursor(def[24])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000210;
          prmT000210 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT00025;
          prmT00025 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT00028;
          prmT00028 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000212;
          prmT000212 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000213;
          prmT000213 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000214;
          prmT000214 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT00027;
          prmT00027 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000215;
          prmT000215 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000216;
          prmT000216 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT00026;
          prmT00026 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000217;
          prmT000217 = new Object[] {
          new ParDef("@LugarName",GXType.NVarChar,40,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000218;
          prmT000218 = new Object[] {
          new ParDef("@LugarName",GXType.NVarChar,40,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000219;
          prmT000219 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000223;
          prmT000223 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000224;
          prmT000224 = new Object[] {
          };
          Object[] prmT000225;
          prmT000225 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000226;
          prmT000226 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT00023;
          prmT00023 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT00022;
          prmT00022 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000227;
          prmT000227 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorName",GXType.NVarChar,40,0) ,
          new ParDef("@LugarSectorCantidad",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorPrecio",GXType.Int16,4,0)
          };
          Object[] prmT000228;
          prmT000228 = new Object[] {
          new ParDef("@LugarSectorName",GXType.NVarChar,40,0) ,
          new ParDef("@LugarSectorCantidad",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorPrecio",GXType.Int16,4,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000229;
          prmT000229 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000230;
          prmT000230 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000221;
          prmT000221 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000222;
          prmT000222 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00022", "SELECT [LugarId], [LugarSectorId], [LugarSectorName], [LugarSectorCantidad], [LugarSectorPrecio] FROM [LugarSector] WITH (UPDLOCK) WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00023", "SELECT [LugarId], [LugarSectorId], [LugarSectorName], [LugarSectorCantidad], [LugarSectorPrecio] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00025", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1, [LugarId] FROM [LugarSector] WITH (UPDLOCK) GROUP BY [LugarId] ) T1 WHERE T1.[LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00026", "SELECT [LugarId], [LugarName], [PaisId] FROM [Lugar] WITH (UPDLOCK) WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00027", "SELECT [LugarId], [LugarName], [PaisId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00028", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000210", "SELECT TM1.[LugarId], TM1.[LugarName], T3.[PaisName], TM1.[PaisId], COALESCE( T2.[GXC1], 0) AS GXC1 FROM (([Lugar] TM1 LEFT JOIN (SELECT COUNT(*) AS GXC1, [LugarId] FROM [LugarSector] GROUP BY [LugarId] ) T2 ON T2.[LugarId] = TM1.[LugarId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = TM1.[PaisId]) WHERE TM1.[LugarId] = @LugarId ORDER BY TM1.[LugarId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000210,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000212", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1, [LugarId] FROM [LugarSector] WITH (UPDLOCK) GROUP BY [LugarId] ) T1 WHERE T1.[LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000212,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000213", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000213,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000214", "SELECT [LugarId] FROM [Lugar] WHERE [LugarId] = @LugarId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000214,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000215", "SELECT TOP 1 [LugarId] FROM [Lugar] WHERE ( [LugarId] > @LugarId) ORDER BY [LugarId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000215,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000216", "SELECT TOP 1 [LugarId] FROM [Lugar] WHERE ( [LugarId] < @LugarId) ORDER BY [LugarId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000216,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000217", "INSERT INTO [Lugar]([LugarName], [PaisId]) VALUES(@LugarName, @PaisId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000217,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000218", "UPDATE [Lugar] SET [LugarName]=@LugarName, [PaisId]=@PaisId  WHERE [LugarId] = @LugarId", GxErrorMask.GX_NOMASK,prmT000218)
             ,new CursorDef("T000219", "DELETE FROM [Lugar]  WHERE [LugarId] = @LugarId", GxErrorMask.GX_NOMASK,prmT000219)
             ,new CursorDef("T000221", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1, [LugarId] FROM [LugarSector] WITH (UPDLOCK) GROUP BY [LugarId] ) T1 WHERE T1.[LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000221,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000222", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000222,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000223", "SELECT TOP 1 [EspectaculoId] FROM [Espectaculo] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000223,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000224", "SELECT [LugarId] FROM [Lugar] ORDER BY [LugarId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000224,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000225", "SELECT [LugarId], [LugarSectorId], [LugarSectorName], [LugarSectorCantidad], [LugarSectorPrecio] FROM [LugarSector] WHERE [LugarId] = @LugarId and [LugarSectorId] = @LugarSectorId ORDER BY [LugarId], [LugarSectorId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000225,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000226", "SELECT [LugarId], [LugarSectorId] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000226,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000227", "INSERT INTO [LugarSector]([LugarId], [LugarSectorId], [LugarSectorName], [LugarSectorCantidad], [LugarSectorPrecio]) VALUES(@LugarId, @LugarSectorId, @LugarSectorName, @LugarSectorCantidad, @LugarSectorPrecio)", GxErrorMask.GX_NOMASK,prmT000227)
             ,new CursorDef("T000228", "UPDATE [LugarSector] SET [LugarSectorName]=@LugarSectorName, [LugarSectorCantidad]=@LugarSectorCantidad, [LugarSectorPrecio]=@LugarSectorPrecio  WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId", GxErrorMask.GX_NOMASK,prmT000228)
             ,new CursorDef("T000229", "DELETE FROM [LugarSector]  WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId", GxErrorMask.GX_NOMASK,prmT000229)
             ,new CursorDef("T000230", "SELECT [LugarId], [LugarSectorId] FROM [LugarSector] WHERE [LugarId] = @LugarId ORDER BY [LugarId], [LugarSectorId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000230,11, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
             case 7 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
