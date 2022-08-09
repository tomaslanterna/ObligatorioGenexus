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
   public class entrada : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A9ClienteId = (short)(NumberUtil.Val( GetPar( "ClienteId"), "."));
            AssignAttri("", false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A9ClienteId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A15FuncionId = (short)(NumberUtil.Val( GetPar( "FuncionId"), "."));
            AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A15FuncionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A1EspectaculoId = (short)(NumberUtil.Val( GetPar( "EspectaculoId"), "."));
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A1EspectaculoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A4LugarId = (short)(NumberUtil.Val( GetPar( "LugarId"), "."));
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A4LugarId) ;
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
               AV7EntradaId = (short)(NumberUtil.Val( GetPar( "EntradaId"), "."));
               AssignAttri("", false, "AV7EntradaId", StringUtil.LTrimStr( (decimal)(AV7EntradaId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vENTRADAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EntradaId), "ZZZ9"), context));
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
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_10-161416", 0) ;
            }
            Form.Meta.addItem("description", "Entrada", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public entrada( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public entrada( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_EntradaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EntradaId = aP1_EntradaId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Entrada", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Entrada.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Entrada.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEntradaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEntradaId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEntradaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A23EntradaId), 4, 0, ",", "")), StringUtil.LTrim( ((edtEntradaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A23EntradaId), "ZZZ9") : context.localUtil.Format( (decimal)(A23EntradaId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntradaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEntradaId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteId_Internalname, "Cliente Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9ClienteId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A9ClienteId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Entrada.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_9_Internalname, sImgUrl, imgprompt_9_Link, "", "", context.GetTheme( ), imgprompt_9_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteName_Internalname, "Cliente Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtClienteName_Internalname, A10ClienteName, StringUtil.RTrim( context.localUtil.Format( A10ClienteName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFuncionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFuncionId_Internalname, "Funcion Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFuncionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15FuncionId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A15FuncionId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFuncionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFuncionId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Entrada.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_15_Internalname, sImgUrl, imgprompt_15_Link, "", "", context.GetTheme( ), imgprompt_15_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFuncionName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFuncionName_Internalname, "Funcion Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFuncionName_Internalname, StringUtil.RTrim( A22FuncionName), StringUtil.RTrim( context.localUtil.Format( A22FuncionName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFuncionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFuncionName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Entrada.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPaisName_Internalname, A6PaisName, StringUtil.RTrim( context.localUtil.Format( A6PaisName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Entrada.htm");
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
         GxWebStd.gx_label_element( context, edtLugarName_Internalname, "Lugar Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLugarName_Internalname, A5LugarName, StringUtil.RTrim( context.localUtil.Format( A5LugarName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSectorId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSectorId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13SectorId), 4, 0, ",", "")), StringUtil.LTrim( ((edtSectorId_Enabled!=0) ? context.localUtil.Format( (decimal)(A13SectorId), "ZZZ9") : context.localUtil.Format( (decimal)(A13SectorId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSectorName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSectorName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSectorName_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17SectorName), 4, 0, ",", "")), StringUtil.LTrim( ((edtSectorName_Enabled!=0) ? context.localUtil.Format( (decimal)(A17SectorName), "ZZZ9") : context.localUtil.Format( (decimal)(A17SectorName), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSectorName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSectorName_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Entrada.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         E11082 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z23EntradaId = (short)(context.localUtil.CToN( cgiGet( "Z23EntradaId"), ",", "."));
               Z13SectorId = (short)(context.localUtil.CToN( cgiGet( "Z13SectorId"), ",", "."));
               Z17SectorName = (short)(context.localUtil.CToN( cgiGet( "Z17SectorName"), ",", "."));
               Z9ClienteId = (short)(context.localUtil.CToN( cgiGet( "Z9ClienteId"), ",", "."));
               Z15FuncionId = (short)(context.localUtil.CToN( cgiGet( "Z15FuncionId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               N9ClienteId = (short)(context.localUtil.CToN( cgiGet( "N9ClienteId"), ",", "."));
               N15FuncionId = (short)(context.localUtil.CToN( cgiGet( "N15FuncionId"), ",", "."));
               AV7EntradaId = (short)(context.localUtil.CToN( cgiGet( "vENTRADAID"), ",", "."));
               AV11Insert_ClienteId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTEID"), ",", "."));
               AV12Insert_FuncionId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_FUNCIONID"), ",", "."));
               A3PaisId = (short)(context.localUtil.CToN( cgiGet( "PAISID"), ",", "."));
               A1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( "ESPECTACULOID"), ",", "."));
               A4LugarId = (short)(context.localUtil.CToN( cgiGet( "LUGARID"), ",", "."));
               AV14Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A23EntradaId = (short)(context.localUtil.CToN( cgiGet( edtEntradaId_Internalname), ",", "."));
               AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A9ClienteId = 0;
                  AssignAttri("", false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
               }
               else
               {
                  A9ClienteId = (short)(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ",", "."));
                  AssignAttri("", false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
               }
               A10ClienteName = cgiGet( edtClienteName_Internalname);
               AssignAttri("", false, "A10ClienteName", A10ClienteName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtFuncionId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFuncionId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FUNCIONID");
                  AnyError = 1;
                  GX_FocusControl = edtFuncionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A15FuncionId = 0;
                  AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
               }
               else
               {
                  A15FuncionId = (short)(context.localUtil.CToN( cgiGet( edtFuncionId_Internalname), ",", "."));
                  AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
               }
               A22FuncionName = cgiGet( edtFuncionName_Internalname);
               AssignAttri("", false, "A22FuncionName", A22FuncionName);
               A6PaisName = cgiGet( edtPaisName_Internalname);
               AssignAttri("", false, "A6PaisName", A6PaisName);
               A5LugarName = cgiGet( edtLugarName_Internalname);
               AssignAttri("", false, "A5LugarName", A5LugarName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSectorId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSectorId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECTORID");
                  AnyError = 1;
                  GX_FocusControl = edtSectorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A13SectorId = 0;
                  AssignAttri("", false, "A13SectorId", StringUtil.LTrimStr( (decimal)(A13SectorId), 4, 0));
               }
               else
               {
                  A13SectorId = (short)(context.localUtil.CToN( cgiGet( edtSectorId_Internalname), ",", "."));
                  AssignAttri("", false, "A13SectorId", StringUtil.LTrimStr( (decimal)(A13SectorId), 4, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtSectorName_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSectorName_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SECTORNAME");
                  AnyError = 1;
                  GX_FocusControl = edtSectorName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A17SectorName = 0;
                  AssignAttri("", false, "A17SectorName", StringUtil.LTrimStr( (decimal)(A17SectorName), 4, 0));
               }
               else
               {
                  A17SectorName = (short)(context.localUtil.CToN( cgiGet( edtSectorName_Internalname), ",", "."));
                  AssignAttri("", false, "A17SectorName", StringUtil.LTrimStr( (decimal)(A17SectorName), 4, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Entrada");
               A23EntradaId = (short)(context.localUtil.CToN( cgiGet( edtEntradaId_Internalname), ",", "."));
               AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
               forbiddenHiddens.Add("EntradaId", context.localUtil.Format( (decimal)(A23EntradaId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A23EntradaId != Z23EntradaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("entrada:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A23EntradaId = (short)(NumberUtil.Val( GetPar( "EntradaId"), "."));
                  AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
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
                     sMode9 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode9;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound9 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_080( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ENTRADAID");
                        AnyError = 1;
                        GX_FocusControl = edtEntradaId_Internalname;
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
                           E11082 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12082 ();
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
            E12082 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll089( ) ;
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
            DisableAttributes089( ) ;
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
               CloseExtendedTableCursors089( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption080( )
      {
      }

      protected void E11082( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_ClienteId = 0;
         AssignAttri("", false, "AV11Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteId), 4, 0));
         AV12Insert_FuncionId = 0;
         AssignAttri("", false, "AV12Insert_FuncionId", StringUtil.LTrimStr( (decimal)(AV12Insert_FuncionId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV14Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV15GXV1 = 1;
            AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            while ( AV15GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ClienteId") == 0 )
               {
                  AV11Insert_ClienteId = (short)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "FuncionId") == 0 )
               {
                  AV12Insert_FuncionId = (short)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV12Insert_FuncionId", StringUtil.LTrimStr( (decimal)(AV12Insert_FuncionId), 4, 0));
               }
               AV15GXV1 = (int)(AV15GXV1+1);
               AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
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

      protected void E12082( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwentrada.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM089( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z13SectorId = T00083_A13SectorId[0];
               Z17SectorName = T00083_A17SectorName[0];
               Z9ClienteId = T00083_A9ClienteId[0];
               Z15FuncionId = T00083_A15FuncionId[0];
            }
            else
            {
               Z13SectorId = A13SectorId;
               Z17SectorName = A17SectorName;
               Z9ClienteId = A9ClienteId;
               Z15FuncionId = A15FuncionId;
            }
         }
         if ( GX_JID == -11 )
         {
            Z23EntradaId = A23EntradaId;
            Z13SectorId = A13SectorId;
            Z17SectorName = A17SectorName;
            Z9ClienteId = A9ClienteId;
            Z15FuncionId = A15FuncionId;
            Z3PaisId = A3PaisId;
            Z10ClienteName = A10ClienteName;
            Z6PaisName = A6PaisName;
            Z1EspectaculoId = A1EspectaculoId;
            Z22FuncionName = A22FuncionName;
            Z4LugarId = A4LugarId;
            Z5LugarName = A5LugarName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtEntradaId_Enabled = 0;
         AssignProp("", false, edtEntradaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntradaId_Enabled), 5, 0), true);
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CLIENTEID"+"'), id:'"+"CLIENTEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_15_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0070.aspx"+"',["+"{Ctrl:gx.dom.el('"+"FUNCIONID"+"'), id:'"+"FUNCIONID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtEntradaId_Enabled = 0;
         AssignProp("", false, edtEntradaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntradaId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7EntradaId) )
         {
            A23EntradaId = AV7EntradaId;
            AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteId) )
         {
            edtClienteId_Enabled = 0;
            AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         }
         else
         {
            edtClienteId_Enabled = 1;
            AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_FuncionId) )
         {
            edtFuncionId_Enabled = 0;
            AssignProp("", false, edtFuncionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFuncionId_Enabled), 5, 0), true);
         }
         else
         {
            edtFuncionId_Enabled = 1;
            AssignProp("", false, edtFuncionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFuncionId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_FuncionId) )
         {
            A15FuncionId = AV12Insert_FuncionId;
            AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteId) )
         {
            A9ClienteId = AV11Insert_ClienteId;
            AssignAttri("", false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
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
            AV14Pgmname = "Entrada";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T00085 */
            pr_default.execute(3, new Object[] {A15FuncionId});
            A1EspectaculoId = T00085_A1EspectaculoId[0];
            A22FuncionName = T00085_A22FuncionName[0];
            AssignAttri("", false, "A22FuncionName", A22FuncionName);
            pr_default.close(3);
            /* Using cursor T00087 */
            pr_default.execute(5, new Object[] {A1EspectaculoId});
            A4LugarId = T00087_A4LugarId[0];
            pr_default.close(5);
            /* Using cursor T00088 */
            pr_default.execute(6, new Object[] {A4LugarId});
            A5LugarName = T00088_A5LugarName[0];
            AssignAttri("", false, "A5LugarName", A5LugarName);
            pr_default.close(6);
            /* Using cursor T00084 */
            pr_default.execute(2, new Object[] {A9ClienteId});
            A3PaisId = T00084_A3PaisId[0];
            A10ClienteName = T00084_A10ClienteName[0];
            AssignAttri("", false, "A10ClienteName", A10ClienteName);
            pr_default.close(2);
            /* Using cursor T00086 */
            pr_default.execute(4, new Object[] {A3PaisId});
            A6PaisName = T00086_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            pr_default.close(4);
         }
      }

      protected void Load089( )
      {
         /* Using cursor T00089 */
         pr_default.execute(7, new Object[] {A23EntradaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound9 = 1;
            A3PaisId = T00089_A3PaisId[0];
            A1EspectaculoId = T00089_A1EspectaculoId[0];
            A4LugarId = T00089_A4LugarId[0];
            A10ClienteName = T00089_A10ClienteName[0];
            AssignAttri("", false, "A10ClienteName", A10ClienteName);
            A22FuncionName = T00089_A22FuncionName[0];
            AssignAttri("", false, "A22FuncionName", A22FuncionName);
            A6PaisName = T00089_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            A5LugarName = T00089_A5LugarName[0];
            AssignAttri("", false, "A5LugarName", A5LugarName);
            A13SectorId = T00089_A13SectorId[0];
            AssignAttri("", false, "A13SectorId", StringUtil.LTrimStr( (decimal)(A13SectorId), 4, 0));
            A17SectorName = T00089_A17SectorName[0];
            AssignAttri("", false, "A17SectorName", StringUtil.LTrimStr( (decimal)(A17SectorName), 4, 0));
            A9ClienteId = T00089_A9ClienteId[0];
            AssignAttri("", false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
            A15FuncionId = T00089_A15FuncionId[0];
            AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
            ZM089( -11) ;
         }
         pr_default.close(7);
         OnLoadActions089( ) ;
      }

      protected void OnLoadActions089( )
      {
         AV14Pgmname = "Entrada";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable089( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV14Pgmname = "Entrada";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         /* Using cursor T00084 */
         pr_default.execute(2, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A3PaisId = T00084_A3PaisId[0];
         A10ClienteName = T00084_A10ClienteName[0];
         AssignAttri("", false, "A10ClienteName", A10ClienteName);
         pr_default.close(2);
         /* Using cursor T00086 */
         pr_default.execute(4, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = T00086_A6PaisName[0];
         AssignAttri("", false, "A6PaisName", A6PaisName);
         pr_default.close(4);
         /* Using cursor T00085 */
         pr_default.execute(3, new Object[] {A15FuncionId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Funcion'.", "ForeignKeyNotFound", 1, "FUNCIONID");
            AnyError = 1;
            GX_FocusControl = edtFuncionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1EspectaculoId = T00085_A1EspectaculoId[0];
         A22FuncionName = T00085_A22FuncionName[0];
         AssignAttri("", false, "A22FuncionName", A22FuncionName);
         pr_default.close(3);
         /* Using cursor T00087 */
         pr_default.execute(5, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
         }
         A4LugarId = T00087_A4LugarId[0];
         pr_default.close(5);
         /* Using cursor T00088 */
         pr_default.execute(6, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
         }
         A5LugarName = T00088_A5LugarName[0];
         AssignAttri("", false, "A5LugarName", A5LugarName);
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors089( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
         pr_default.close(5);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( short A9ClienteId )
      {
         /* Using cursor T000810 */
         pr_default.execute(8, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A3PaisId = T000810_A3PaisId[0];
         A10ClienteName = T000810_A10ClienteName[0];
         AssignAttri("", false, "A10ClienteName", A10ClienteName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A10ClienteName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_14( short A3PaisId )
      {
         /* Using cursor T000811 */
         pr_default.execute(9, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = T000811_A6PaisName[0];
         AssignAttri("", false, "A6PaisName", A6PaisName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A6PaisName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_13( short A15FuncionId )
      {
         /* Using cursor T000812 */
         pr_default.execute(10, new Object[] {A15FuncionId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Funcion'.", "ForeignKeyNotFound", 1, "FUNCIONID");
            AnyError = 1;
            GX_FocusControl = edtFuncionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1EspectaculoId = T000812_A1EspectaculoId[0];
         A22FuncionName = T000812_A22FuncionName[0];
         AssignAttri("", false, "A22FuncionName", A22FuncionName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A22FuncionName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_15( short A1EspectaculoId )
      {
         /* Using cursor T000813 */
         pr_default.execute(11, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
         }
         A4LugarId = T000813_A4LugarId[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_16( short A4LugarId )
      {
         /* Using cursor T000814 */
         pr_default.execute(12, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
         }
         A5LugarName = T000814_A5LugarName[0];
         AssignAttri("", false, "A5LugarName", A5LugarName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A5LugarName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey089( )
      {
         /* Using cursor T000815 */
         pr_default.execute(13, new Object[] {A23EntradaId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00083 */
         pr_default.execute(1, new Object[] {A23EntradaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM089( 11) ;
            RcdFound9 = 1;
            A23EntradaId = T00083_A23EntradaId[0];
            AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
            A13SectorId = T00083_A13SectorId[0];
            AssignAttri("", false, "A13SectorId", StringUtil.LTrimStr( (decimal)(A13SectorId), 4, 0));
            A17SectorName = T00083_A17SectorName[0];
            AssignAttri("", false, "A17SectorName", StringUtil.LTrimStr( (decimal)(A17SectorName), 4, 0));
            A9ClienteId = T00083_A9ClienteId[0];
            AssignAttri("", false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
            A15FuncionId = T00083_A15FuncionId[0];
            AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
            Z23EntradaId = A23EntradaId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load089( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey089( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey089( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey089( ) ;
         if ( RcdFound9 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound9 = 0;
         /* Using cursor T000816 */
         pr_default.execute(14, new Object[] {A23EntradaId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000816_A23EntradaId[0] < A23EntradaId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000816_A23EntradaId[0] > A23EntradaId ) ) )
            {
               A23EntradaId = T000816_A23EntradaId[0];
               AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T000817 */
         pr_default.execute(15, new Object[] {A23EntradaId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T000817_A23EntradaId[0] > A23EntradaId ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T000817_A23EntradaId[0] < A23EntradaId ) ) )
            {
               A23EntradaId = T000817_A23EntradaId[0];
               AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey089( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert089( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A23EntradaId != Z23EntradaId )
               {
                  A23EntradaId = Z23EntradaId;
                  AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ENTRADAID");
                  AnyError = 1;
                  GX_FocusControl = edtEntradaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update089( ) ;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A23EntradaId != Z23EntradaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert089( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ENTRADAID");
                     AnyError = 1;
                     GX_FocusControl = edtEntradaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtClienteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert089( ) ;
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
         if ( A23EntradaId != Z23EntradaId )
         {
            A23EntradaId = Z23EntradaId;
            AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ENTRADAID");
            AnyError = 1;
            GX_FocusControl = edtEntradaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency089( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00082 */
            pr_default.execute(0, new Object[] {A23EntradaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Entrada"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z13SectorId != T00082_A13SectorId[0] ) || ( Z17SectorName != T00082_A17SectorName[0] ) || ( Z9ClienteId != T00082_A9ClienteId[0] ) || ( Z15FuncionId != T00082_A15FuncionId[0] ) )
            {
               if ( Z13SectorId != T00082_A13SectorId[0] )
               {
                  GXUtil.WriteLog("entrada:[seudo value changed for attri]"+"SectorId");
                  GXUtil.WriteLogRaw("Old: ",Z13SectorId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A13SectorId[0]);
               }
               if ( Z17SectorName != T00082_A17SectorName[0] )
               {
                  GXUtil.WriteLog("entrada:[seudo value changed for attri]"+"SectorName");
                  GXUtil.WriteLogRaw("Old: ",Z17SectorName);
                  GXUtil.WriteLogRaw("Current: ",T00082_A17SectorName[0]);
               }
               if ( Z9ClienteId != T00082_A9ClienteId[0] )
               {
                  GXUtil.WriteLog("entrada:[seudo value changed for attri]"+"ClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z9ClienteId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A9ClienteId[0]);
               }
               if ( Z15FuncionId != T00082_A15FuncionId[0] )
               {
                  GXUtil.WriteLog("entrada:[seudo value changed for attri]"+"FuncionId");
                  GXUtil.WriteLogRaw("Old: ",Z15FuncionId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A15FuncionId[0]);
               }
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
                     /* Using cursor T000818 */
                     pr_default.execute(16, new Object[] {A13SectorId, A17SectorName, A9ClienteId, A15FuncionId});
                     A23EntradaId = T000818_A23EntradaId[0];
                     AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
                     pr_default.close(16);
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
                           ResetCaption080( ) ;
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
                     /* Using cursor T000819 */
                     pr_default.execute(17, new Object[] {A13SectorId, A17SectorName, A9ClienteId, A15FuncionId, A23EntradaId});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("Entrada");
                     if ( (pr_default.getStatus(17) == 103) )
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
            EndLevel089( ) ;
         }
         CloseExtendedTableCursors089( ) ;
      }

      protected void DeferredUpdate089( )
      {
      }

      protected void delete( )
      {
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
                  /* Using cursor T000820 */
                  pr_default.execute(18, new Object[] {A23EntradaId});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("Entrada");
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel089( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls089( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "Entrada";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T000821 */
            pr_default.execute(19, new Object[] {A9ClienteId});
            A3PaisId = T000821_A3PaisId[0];
            A10ClienteName = T000821_A10ClienteName[0];
            AssignAttri("", false, "A10ClienteName", A10ClienteName);
            pr_default.close(19);
            /* Using cursor T000822 */
            pr_default.execute(20, new Object[] {A3PaisId});
            A6PaisName = T000822_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            pr_default.close(20);
            /* Using cursor T000823 */
            pr_default.execute(21, new Object[] {A15FuncionId});
            A1EspectaculoId = T000823_A1EspectaculoId[0];
            A22FuncionName = T000823_A22FuncionName[0];
            AssignAttri("", false, "A22FuncionName", A22FuncionName);
            pr_default.close(21);
            /* Using cursor T000824 */
            pr_default.execute(22, new Object[] {A1EspectaculoId});
            A4LugarId = T000824_A4LugarId[0];
            pr_default.close(22);
            /* Using cursor T000825 */
            pr_default.execute(23, new Object[] {A4LugarId});
            A5LugarName = T000825_A5LugarName[0];
            AssignAttri("", false, "A5LugarName", A5LugarName);
            pr_default.close(23);
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
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(21);
            pr_default.close(20);
            pr_default.close(22);
            pr_default.close(23);
            context.CommitDataStores("entrada",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues080( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(21);
            pr_default.close(20);
            pr_default.close(22);
            pr_default.close(23);
            context.RollbackDataStores("entrada",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart089( )
      {
         /* Scan By routine */
         /* Using cursor T000826 */
         pr_default.execute(24);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound9 = 1;
            A23EntradaId = T000826_A23EntradaId[0];
            AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext089( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound9 = 1;
            A23EntradaId = T000826_A23EntradaId[0];
            AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
         }
      }

      protected void ScanEnd089( )
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
         edtEntradaId_Enabled = 0;
         AssignProp("", false, edtEntradaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntradaId_Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         edtClienteName_Enabled = 0;
         AssignProp("", false, edtClienteName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteName_Enabled), 5, 0), true);
         edtFuncionId_Enabled = 0;
         AssignProp("", false, edtFuncionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFuncionId_Enabled), 5, 0), true);
         edtFuncionName_Enabled = 0;
         AssignProp("", false, edtFuncionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFuncionName_Enabled), 5, 0), true);
         edtPaisName_Enabled = 0;
         AssignProp("", false, edtPaisName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisName_Enabled), 5, 0), true);
         edtLugarName_Enabled = 0;
         AssignProp("", false, edtLugarName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarName_Enabled), 5, 0), true);
         edtSectorId_Enabled = 0;
         AssignProp("", false, edtSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorId_Enabled), 5, 0), true);
         edtSectorName_Enabled = 0;
         AssignProp("", false, edtSectorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSectorName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes089( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues080( )
      {
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 552120), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 552120), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 552120), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20228822543475", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("entrada.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EntradaId,4,0))}, new string[] {"Gx_mode","EntradaId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Entrada");
         forbiddenHiddens.Add("EntradaId", context.localUtil.Format( (decimal)(A23EntradaId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("entrada:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z23EntradaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z23EntradaId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z13SectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13SectorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z17SectorName", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17SectorName), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z9ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9ClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z15FuncionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15FuncionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N9ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9ClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N15FuncionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15FuncionId), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vENTRADAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EntradaId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vENTRADAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EntradaId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_FUNCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_FuncionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "LUGARID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
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
         return formatLink("entrada.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EntradaId,4,0))}, new string[] {"Gx_mode","EntradaId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Entrada" ;
      }

      public override string GetPgmdesc( )
      {
         return "Entrada" ;
      }

      protected void InitializeNonKey089( )
      {
         A4LugarId = 0;
         AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
         A1EspectaculoId = 0;
         AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         A3PaisId = 0;
         AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
         A9ClienteId = 0;
         AssignAttri("", false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
         A15FuncionId = 0;
         AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
         A10ClienteName = "";
         AssignAttri("", false, "A10ClienteName", A10ClienteName);
         A22FuncionName = "";
         AssignAttri("", false, "A22FuncionName", A22FuncionName);
         A6PaisName = "";
         AssignAttri("", false, "A6PaisName", A6PaisName);
         A5LugarName = "";
         AssignAttri("", false, "A5LugarName", A5LugarName);
         A13SectorId = 0;
         AssignAttri("", false, "A13SectorId", StringUtil.LTrimStr( (decimal)(A13SectorId), 4, 0));
         A17SectorName = 0;
         AssignAttri("", false, "A17SectorName", StringUtil.LTrimStr( (decimal)(A17SectorName), 4, 0));
         Z13SectorId = 0;
         Z17SectorName = 0;
         Z9ClienteId = 0;
         Z15FuncionId = 0;
      }

      protected void InitAll089( )
      {
         A23EntradaId = 0;
         AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
         InitializeNonKey089( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228822543480", true, true);
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
         context.AddJavascriptSource("entrada.js", "?20228822543481", false, true);
         /* End function include_jscripts */
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
         edtEntradaId_Internalname = "ENTRADAID";
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteName_Internalname = "CLIENTENAME";
         edtFuncionId_Internalname = "FUNCIONID";
         edtFuncionName_Internalname = "FUNCIONNAME";
         edtPaisName_Internalname = "PAISNAME";
         edtLugarName_Internalname = "LUGARNAME";
         edtSectorId_Internalname = "SECTORID";
         edtSectorName_Internalname = "SECTORNAME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_9_Internalname = "PROMPT_9";
         imgprompt_15_Internalname = "PROMPT_15";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Entrada";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSectorName_Jsonclick = "";
         edtSectorName_Enabled = 1;
         edtSectorId_Jsonclick = "";
         edtSectorId_Enabled = 1;
         edtLugarName_Jsonclick = "";
         edtLugarName_Enabled = 0;
         edtPaisName_Jsonclick = "";
         edtPaisName_Enabled = 0;
         edtFuncionName_Jsonclick = "";
         edtFuncionName_Enabled = 0;
         imgprompt_15_Visible = 1;
         imgprompt_15_Link = "";
         edtFuncionId_Jsonclick = "";
         edtFuncionId_Enabled = 1;
         edtClienteName_Jsonclick = "";
         edtClienteName_Enabled = 0;
         imgprompt_9_Visible = 1;
         imgprompt_9_Link = "";
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
         edtEntradaId_Jsonclick = "";
         edtEntradaId_Enabled = 0;
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

      public void Valid_Clienteid( )
      {
         /* Using cursor T000821 */
         pr_default.execute(19, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
         }
         A3PaisId = T000821_A3PaisId[0];
         A10ClienteName = T000821_A10ClienteName[0];
         pr_default.close(19);
         /* Using cursor T000822 */
         pr_default.execute(20, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = T000822_A6PaisName[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A3PaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ".", "")));
         AssignAttri("", false, "A10ClienteName", A10ClienteName);
         AssignAttri("", false, "A6PaisName", A6PaisName);
      }

      public void Valid_Funcionid( )
      {
         /* Using cursor T000823 */
         pr_default.execute(21, new Object[] {A15FuncionId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Funcion'.", "ForeignKeyNotFound", 1, "FUNCIONID");
            AnyError = 1;
            GX_FocusControl = edtFuncionId_Internalname;
         }
         A1EspectaculoId = T000823_A1EspectaculoId[0];
         A22FuncionName = T000823_A22FuncionName[0];
         pr_default.close(21);
         /* Using cursor T000824 */
         pr_default.execute(22, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
         }
         A4LugarId = T000824_A4LugarId[0];
         pr_default.close(22);
         /* Using cursor T000825 */
         pr_default.execute(23, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
         }
         A5LugarName = T000825_A5LugarName[0];
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ".", "")));
         AssignAttri("", false, "A22FuncionName", StringUtil.RTrim( A22FuncionName));
         AssignAttri("", false, "A4LugarId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ".", "")));
         AssignAttri("", false, "A5LugarName", A5LugarName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7EntradaId',fld:'vENTRADAID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7EntradaId',fld:'vENTRADAID',pic:'ZZZ9',hsh:true},{av:'A23EntradaId',fld:'ENTRADAID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12082',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_ENTRADAID","{handler:'Valid_Entradaid',iparms:[]");
         setEventMetadata("VALID_ENTRADAID",",oparms:[]}");
         setEventMetadata("VALID_CLIENTEID","{handler:'Valid_Clienteid',iparms:[{av:'A9ClienteId',fld:'CLIENTEID',pic:'ZZZ9'},{av:'A3PaisId',fld:'PAISID',pic:'ZZZ9'},{av:'A10ClienteName',fld:'CLIENTENAME',pic:''},{av:'A6PaisName',fld:'PAISNAME',pic:''}]");
         setEventMetadata("VALID_CLIENTEID",",oparms:[{av:'A3PaisId',fld:'PAISID',pic:'ZZZ9'},{av:'A10ClienteName',fld:'CLIENTENAME',pic:''},{av:'A6PaisName',fld:'PAISNAME',pic:''}]}");
         setEventMetadata("VALID_FUNCIONID","{handler:'Valid_Funcionid',iparms:[{av:'A15FuncionId',fld:'FUNCIONID',pic:'ZZZ9'},{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A4LugarId',fld:'LUGARID',pic:'ZZZ9'},{av:'A22FuncionName',fld:'FUNCIONNAME',pic:''},{av:'A5LugarName',fld:'LUGARNAME',pic:''}]");
         setEventMetadata("VALID_FUNCIONID",",oparms:[{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A22FuncionName',fld:'FUNCIONNAME',pic:''},{av:'A4LugarId',fld:'LUGARID',pic:'ZZZ9'},{av:'A5LugarName',fld:'LUGARNAME',pic:''}]}");
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
         pr_default.close(19);
         pr_default.close(21);
         pr_default.close(20);
         pr_default.close(22);
         pr_default.close(23);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
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
         sImgUrl = "";
         A10ClienteName = "";
         A22FuncionName = "";
         A6PaisName = "";
         A5LugarName = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV14Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode9 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z10ClienteName = "";
         Z6PaisName = "";
         Z22FuncionName = "";
         Z5LugarName = "";
         T00085_A1EspectaculoId = new short[1] ;
         T00085_A22FuncionName = new string[] {""} ;
         T00087_A4LugarId = new short[1] ;
         T00088_A5LugarName = new string[] {""} ;
         T00084_A3PaisId = new short[1] ;
         T00084_A10ClienteName = new string[] {""} ;
         T00086_A6PaisName = new string[] {""} ;
         T00089_A3PaisId = new short[1] ;
         T00089_A1EspectaculoId = new short[1] ;
         T00089_A4LugarId = new short[1] ;
         T00089_A23EntradaId = new short[1] ;
         T00089_A10ClienteName = new string[] {""} ;
         T00089_A22FuncionName = new string[] {""} ;
         T00089_A6PaisName = new string[] {""} ;
         T00089_A5LugarName = new string[] {""} ;
         T00089_A13SectorId = new short[1] ;
         T00089_A17SectorName = new short[1] ;
         T00089_A9ClienteId = new short[1] ;
         T00089_A15FuncionId = new short[1] ;
         T000810_A3PaisId = new short[1] ;
         T000810_A10ClienteName = new string[] {""} ;
         T000811_A6PaisName = new string[] {""} ;
         T000812_A1EspectaculoId = new short[1] ;
         T000812_A22FuncionName = new string[] {""} ;
         T000813_A4LugarId = new short[1] ;
         T000814_A5LugarName = new string[] {""} ;
         T000815_A23EntradaId = new short[1] ;
         T00083_A23EntradaId = new short[1] ;
         T00083_A13SectorId = new short[1] ;
         T00083_A17SectorName = new short[1] ;
         T00083_A9ClienteId = new short[1] ;
         T00083_A15FuncionId = new short[1] ;
         T000816_A23EntradaId = new short[1] ;
         T000817_A23EntradaId = new short[1] ;
         T00082_A23EntradaId = new short[1] ;
         T00082_A13SectorId = new short[1] ;
         T00082_A17SectorName = new short[1] ;
         T00082_A9ClienteId = new short[1] ;
         T00082_A15FuncionId = new short[1] ;
         T000818_A23EntradaId = new short[1] ;
         T000821_A3PaisId = new short[1] ;
         T000821_A10ClienteName = new string[] {""} ;
         T000822_A6PaisName = new string[] {""} ;
         T000823_A1EspectaculoId = new short[1] ;
         T000823_A22FuncionName = new string[] {""} ;
         T000824_A4LugarId = new short[1] ;
         T000825_A5LugarName = new string[] {""} ;
         T000826_A23EntradaId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.entrada__default(),
            new Object[][] {
                new Object[] {
               T00082_A23EntradaId, T00082_A13SectorId, T00082_A17SectorName, T00082_A9ClienteId, T00082_A15FuncionId
               }
               , new Object[] {
               T00083_A23EntradaId, T00083_A13SectorId, T00083_A17SectorName, T00083_A9ClienteId, T00083_A15FuncionId
               }
               , new Object[] {
               T00084_A3PaisId, T00084_A10ClienteName
               }
               , new Object[] {
               T00085_A1EspectaculoId, T00085_A22FuncionName
               }
               , new Object[] {
               T00086_A6PaisName
               }
               , new Object[] {
               T00087_A4LugarId
               }
               , new Object[] {
               T00088_A5LugarName
               }
               , new Object[] {
               T00089_A3PaisId, T00089_A1EspectaculoId, T00089_A4LugarId, T00089_A23EntradaId, T00089_A10ClienteName, T00089_A22FuncionName, T00089_A6PaisName, T00089_A5LugarName, T00089_A13SectorId, T00089_A17SectorName,
               T00089_A9ClienteId, T00089_A15FuncionId
               }
               , new Object[] {
               T000810_A3PaisId, T000810_A10ClienteName
               }
               , new Object[] {
               T000811_A6PaisName
               }
               , new Object[] {
               T000812_A1EspectaculoId, T000812_A22FuncionName
               }
               , new Object[] {
               T000813_A4LugarId
               }
               , new Object[] {
               T000814_A5LugarName
               }
               , new Object[] {
               T000815_A23EntradaId
               }
               , new Object[] {
               T000816_A23EntradaId
               }
               , new Object[] {
               T000817_A23EntradaId
               }
               , new Object[] {
               T000818_A23EntradaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000821_A3PaisId, T000821_A10ClienteName
               }
               , new Object[] {
               T000822_A6PaisName
               }
               , new Object[] {
               T000823_A1EspectaculoId, T000823_A22FuncionName
               }
               , new Object[] {
               T000824_A4LugarId
               }
               , new Object[] {
               T000825_A5LugarName
               }
               , new Object[] {
               T000826_A23EntradaId
               }
            }
         );
         AV14Pgmname = "Entrada";
      }

      private short wcpOAV7EntradaId ;
      private short Z23EntradaId ;
      private short Z13SectorId ;
      private short Z17SectorName ;
      private short Z9ClienteId ;
      private short Z15FuncionId ;
      private short N9ClienteId ;
      private short N15FuncionId ;
      private short GxWebError ;
      private short A9ClienteId ;
      private short A3PaisId ;
      private short A15FuncionId ;
      private short A1EspectaculoId ;
      private short A4LugarId ;
      private short AV7EntradaId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A23EntradaId ;
      private short A13SectorId ;
      private short A17SectorName ;
      private short AV11Insert_ClienteId ;
      private short AV12Insert_FuncionId ;
      private short RcdFound9 ;
      private short GX_JID ;
      private short Z3PaisId ;
      private short Z1EspectaculoId ;
      private short Z4LugarId ;
      private short Gx_BScreen ;
      private short nIsDirty_9 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtEntradaId_Enabled ;
      private int edtClienteId_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtClienteName_Enabled ;
      private int edtFuncionId_Enabled ;
      private int imgprompt_15_Visible ;
      private int edtFuncionName_Enabled ;
      private int edtPaisName_Enabled ;
      private int edtLugarName_Enabled ;
      private int edtSectorId_Enabled ;
      private int edtSectorName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV15GXV1 ;
      private int idxLst ;
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
      private string edtClienteId_Internalname ;
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
      private string edtEntradaId_Internalname ;
      private string edtEntradaId_Jsonclick ;
      private string edtClienteId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_9_Internalname ;
      private string imgprompt_9_Link ;
      private string edtClienteName_Internalname ;
      private string edtClienteName_Jsonclick ;
      private string edtFuncionId_Internalname ;
      private string edtFuncionId_Jsonclick ;
      private string imgprompt_15_Internalname ;
      private string imgprompt_15_Link ;
      private string edtFuncionName_Internalname ;
      private string A22FuncionName ;
      private string edtFuncionName_Jsonclick ;
      private string edtPaisName_Internalname ;
      private string edtPaisName_Jsonclick ;
      private string edtLugarName_Internalname ;
      private string edtLugarName_Jsonclick ;
      private string edtSectorId_Internalname ;
      private string edtSectorId_Jsonclick ;
      private string edtSectorName_Internalname ;
      private string edtSectorName_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV14Pgmname ;
      private string hsh ;
      private string sMode9 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z22FuncionName ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private string A10ClienteName ;
      private string A6PaisName ;
      private string A5LugarName ;
      private string Z10ClienteName ;
      private string Z6PaisName ;
      private string Z5LugarName ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00085_A1EspectaculoId ;
      private string[] T00085_A22FuncionName ;
      private short[] T00087_A4LugarId ;
      private string[] T00088_A5LugarName ;
      private short[] T00084_A3PaisId ;
      private string[] T00084_A10ClienteName ;
      private string[] T00086_A6PaisName ;
      private short[] T00089_A3PaisId ;
      private short[] T00089_A1EspectaculoId ;
      private short[] T00089_A4LugarId ;
      private short[] T00089_A23EntradaId ;
      private string[] T00089_A10ClienteName ;
      private string[] T00089_A22FuncionName ;
      private string[] T00089_A6PaisName ;
      private string[] T00089_A5LugarName ;
      private short[] T00089_A13SectorId ;
      private short[] T00089_A17SectorName ;
      private short[] T00089_A9ClienteId ;
      private short[] T00089_A15FuncionId ;
      private short[] T000810_A3PaisId ;
      private string[] T000810_A10ClienteName ;
      private string[] T000811_A6PaisName ;
      private short[] T000812_A1EspectaculoId ;
      private string[] T000812_A22FuncionName ;
      private short[] T000813_A4LugarId ;
      private string[] T000814_A5LugarName ;
      private short[] T000815_A23EntradaId ;
      private short[] T00083_A23EntradaId ;
      private short[] T00083_A13SectorId ;
      private short[] T00083_A17SectorName ;
      private short[] T00083_A9ClienteId ;
      private short[] T00083_A15FuncionId ;
      private short[] T000816_A23EntradaId ;
      private short[] T000817_A23EntradaId ;
      private short[] T00082_A23EntradaId ;
      private short[] T00082_A13SectorId ;
      private short[] T00082_A17SectorName ;
      private short[] T00082_A9ClienteId ;
      private short[] T00082_A15FuncionId ;
      private short[] T000818_A23EntradaId ;
      private short[] T000821_A3PaisId ;
      private string[] T000821_A10ClienteName ;
      private string[] T000822_A6PaisName ;
      private short[] T000823_A1EspectaculoId ;
      private string[] T000823_A22FuncionName ;
      private short[] T000824_A4LugarId ;
      private string[] T000825_A5LugarName ;
      private short[] T000826_A23EntradaId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV13TrnContextAtt ;
   }

   public class entrada__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
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
          Object[] prmT00089;
          prmT00089 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT00084;
          prmT00084 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT00086;
          prmT00086 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT00085;
          prmT00085 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmT00087;
          prmT00087 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00088;
          prmT00088 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000810;
          prmT000810 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000811;
          prmT000811 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000812;
          prmT000812 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmT000813;
          prmT000813 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000814;
          prmT000814 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000815;
          prmT000815 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT00083;
          prmT00083 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT000816;
          prmT000816 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT000817;
          prmT000817 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT00082;
          prmT00082 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT000818;
          prmT000818 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0) ,
          new ParDef("@SectorName",GXType.Int16,4,0) ,
          new ParDef("@ClienteId",GXType.Int16,4,0) ,
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmT000819;
          prmT000819 = new Object[] {
          new ParDef("@SectorId",GXType.Int16,4,0) ,
          new ParDef("@SectorName",GXType.Int16,4,0) ,
          new ParDef("@ClienteId",GXType.Int16,4,0) ,
          new ParDef("@FuncionId",GXType.Int16,4,0) ,
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT000820;
          prmT000820 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT000826;
          prmT000826 = new Object[] {
          };
          Object[] prmT000821;
          prmT000821 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000822;
          prmT000822 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000823;
          prmT000823 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmT000824;
          prmT000824 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000825;
          prmT000825 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00082", "SELECT [EntradaId], [SectorId], [SectorName], [ClienteId], [FuncionId] FROM [Entrada] WITH (UPDLOCK) WHERE [EntradaId] = @EntradaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00082,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00083", "SELECT [EntradaId], [SectorId], [SectorName], [ClienteId], [FuncionId] FROM [Entrada] WHERE [EntradaId] = @EntradaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00083,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00084", "SELECT [PaisId], [ClienteName] FROM [Cliente] WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00084,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00085", "SELECT [EspectaculoId], [FuncionName] FROM [Funcion] WHERE [FuncionId] = @FuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00085,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00086", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00086,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00087", "SELECT [LugarId] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00087,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00088", "SELECT [LugarName] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00088,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00089", "SELECT T2.[PaisId], T4.[EspectaculoId], T5.[LugarId], TM1.[EntradaId], T2.[ClienteName], T4.[FuncionName], T3.[PaisName], T6.[LugarName], TM1.[SectorId], TM1.[SectorName], TM1.[ClienteId], TM1.[FuncionId] FROM ((((([Entrada] TM1 INNER JOIN [Cliente] T2 ON T2.[ClienteId] = TM1.[ClienteId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = T2.[PaisId]) INNER JOIN [Funcion] T4 ON T4.[FuncionId] = TM1.[FuncionId]) INNER JOIN [Espectaculo] T5 ON T5.[EspectaculoId] = T4.[EspectaculoId]) INNER JOIN [Lugar] T6 ON T6.[LugarId] = T5.[LugarId]) WHERE TM1.[EntradaId] = @EntradaId ORDER BY TM1.[EntradaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00089,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000810", "SELECT [PaisId], [ClienteName] FROM [Cliente] WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000810,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000811", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000811,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000812", "SELECT [EspectaculoId], [FuncionName] FROM [Funcion] WHERE [FuncionId] = @FuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000812,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000813", "SELECT [LugarId] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000813,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000814", "SELECT [LugarName] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000814,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000815", "SELECT [EntradaId] FROM [Entrada] WHERE [EntradaId] = @EntradaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000815,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000816", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE ( [EntradaId] > @EntradaId) ORDER BY [EntradaId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000816,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000817", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE ( [EntradaId] < @EntradaId) ORDER BY [EntradaId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000817,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000818", "INSERT INTO [Entrada]([SectorId], [SectorName], [ClienteId], [FuncionId]) VALUES(@SectorId, @SectorName, @ClienteId, @FuncionId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000818,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000819", "UPDATE [Entrada] SET [SectorId]=@SectorId, [SectorName]=@SectorName, [ClienteId]=@ClienteId, [FuncionId]=@FuncionId  WHERE [EntradaId] = @EntradaId", GxErrorMask.GX_NOMASK,prmT000819)
             ,new CursorDef("T000820", "DELETE FROM [Entrada]  WHERE [EntradaId] = @EntradaId", GxErrorMask.GX_NOMASK,prmT000820)
             ,new CursorDef("T000821", "SELECT [PaisId], [ClienteName] FROM [Cliente] WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000821,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000822", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000822,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000823", "SELECT [EspectaculoId], [FuncionName] FROM [Funcion] WHERE [FuncionId] = @FuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000823,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000824", "SELECT [LugarId] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000824,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000825", "SELECT [LugarName] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000825,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000826", "SELECT [EntradaId] FROM [Entrada] ORDER BY [EntradaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000826,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 23 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
