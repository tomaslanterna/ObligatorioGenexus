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
   public class venta : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A7TipoEspectaculoId = (short)(NumberUtil.Val( GetPar( "TipoEspectaculoId"), "."));
            AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A7TipoEspectaculoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A1EspectaculoId = (short)(NumberUtil.Val( GetPar( "EspectaculoId"), "."));
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            A31EspectaculoSectorId = (short)(NumberUtil.Val( GetPar( "EspectaculoSectorId"), "."));
            AssignAttri("", false, "A31EspectaculoSectorId", StringUtil.LTrimStr( (decimal)(A31EspectaculoSectorId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A1EspectaculoId, A31EspectaculoSectorId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A9ClienteId = (short)(NumberUtil.Val( GetPar( "ClienteId"), "."));
            AssignAttri("", false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A9ClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A3PaisId = (short)(NumberUtil.Val( GetPar( "PaisId"), "."));
            AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A3PaisId) ;
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
               AV7VentaId = (short)(NumberUtil.Val( GetPar( "VentaId"), "."));
               AssignAttri("", false, "AV7VentaId", StringUtil.LTrimStr( (decimal)(AV7VentaId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vVENTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7VentaId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Venta", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public venta( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public venta( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_VentaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7VentaId = aP1_VentaId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Venta", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Venta.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Venta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Venta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Venta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Venta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Venta.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVentaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVentaId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtVentaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11VentaId), 4, 0, ",", "")), StringUtil.LTrim( ((edtVentaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A11VentaId), "ZZZ9") : context.localUtil.Format( (decimal)(A11VentaId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVentaId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVentaId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Venta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoId_Internalname, "Espectaculo Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Venta.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1_Internalname, sImgUrl, imgprompt_1_Link, "", "", context.GetTheme( ), imgprompt_1_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Venta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoName_Internalname, "Espectaculo Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEspectaculoName_Internalname, A2EspectaculoName, StringUtil.RTrim( context.localUtil.Format( A2EspectaculoName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Venta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipoEspectaculoName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoEspectaculoName_Internalname, "Tipo Espectaculo Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtTipoEspectaculoName_Internalname, A8TipoEspectaculoName, StringUtil.RTrim( context.localUtil.Format( A8TipoEspectaculoName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoEspectaculoName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipoEspectaculoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Venta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtValorPorAsiento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtValorPorAsiento_Internalname, "Por Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtValorPorAsiento_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12ValorPorAsiento), 4, 0, ",", "")), StringUtil.LTrim( ((edtValorPorAsiento_Enabled!=0) ? context.localUtil.Format( (decimal)(A12ValorPorAsiento), "ZZZ9") : context.localUtil.Format( (decimal)(A12ValorPorAsiento), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtValorPorAsiento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtValorPorAsiento_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Venta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoSectorId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoSectorId_Internalname, "Espectaculo Sector Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEspectaculoSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A31EspectaculoSectorId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A31EspectaculoSectorId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoSectorId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoSectorId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Venta.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_31_Internalname, sImgUrl, imgprompt_31_Link, "", "", context.GetTheme( ), imgprompt_31_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Venta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoSectorName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoSectorName_Internalname, "Espectaculo Sector Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEspectaculoSectorName_Internalname, A32EspectaculoSectorName, StringUtil.RTrim( context.localUtil.Format( A32EspectaculoSectorName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoSectorName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoSectorName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Venta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoSectorPrecio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoSectorPrecio_Internalname, "Espectaculo Sector Precio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEspectaculoSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A35EspectaculoSectorPrecio), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoSectorPrecio_Enabled!=0) ? context.localUtil.Format( (decimal)(A35EspectaculoSectorPrecio), "ZZZ9") : context.localUtil.Format( (decimal)(A35EspectaculoSectorPrecio), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoSectorPrecio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoSectorPrecio_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Venta.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPaisId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ",", "")), StringUtil.LTrim( ((edtPaisId_Enabled!=0) ? context.localUtil.Format( (decimal)(A3PaisId), "ZZZ9") : context.localUtil.Format( (decimal)(A3PaisId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Venta.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPaisName_Internalname, A6PaisName, StringUtil.RTrim( context.localUtil.Format( A6PaisName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Venta.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9ClienteId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A9ClienteId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Venta.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_9_Internalname, sImgUrl, imgprompt_9_Link, "", "", context.GetTheme( ), imgprompt_9_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Venta.htm");
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
         GxWebStd.gx_single_line_edit( context, edtClienteName_Internalname, A10ClienteName, StringUtil.RTrim( context.localUtil.Format( A10ClienteName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Venta.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Venta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Venta.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Venta.htm");
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
         E11062 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z11VentaId = (short)(context.localUtil.CToN( cgiGet( "Z11VentaId"), ",", "."));
               Z12ValorPorAsiento = (short)(context.localUtil.CToN( cgiGet( "Z12ValorPorAsiento"), ",", "."));
               Z1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( "Z1EspectaculoId"), ",", "."));
               Z31EspectaculoSectorId = (short)(context.localUtil.CToN( cgiGet( "Z31EspectaculoSectorId"), ",", "."));
               Z9ClienteId = (short)(context.localUtil.CToN( cgiGet( "Z9ClienteId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               N1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( "N1EspectaculoId"), ",", "."));
               N31EspectaculoSectorId = (short)(context.localUtil.CToN( cgiGet( "N31EspectaculoSectorId"), ",", "."));
               N9ClienteId = (short)(context.localUtil.CToN( cgiGet( "N9ClienteId"), ",", "."));
               AV7VentaId = (short)(context.localUtil.CToN( cgiGet( "vVENTAID"), ",", "."));
               AV11Insert_EspectaculoId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_ESPECTACULOID"), ",", "."));
               AV14Insert_EspectaculoSectorId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_ESPECTACULOSECTORID"), ",", "."));
               AV12Insert_ClienteId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTEID"), ",", "."));
               A7TipoEspectaculoId = (short)(context.localUtil.CToN( cgiGet( "TIPOESPECTACULOID"), ",", "."));
               AV15Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A11VentaId = (short)(context.localUtil.CToN( cgiGet( edtVentaId_Internalname), ",", "."));
               AssignAttri("", false, "A11VentaId", StringUtil.LTrimStr( (decimal)(A11VentaId), 4, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ESPECTACULOID");
                  AnyError = 1;
                  GX_FocusControl = edtEspectaculoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1EspectaculoId = 0;
                  AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
               }
               else
               {
                  A1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."));
                  AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
               }
               A2EspectaculoName = cgiGet( edtEspectaculoName_Internalname);
               AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
               A8TipoEspectaculoName = cgiGet( edtTipoEspectaculoName_Internalname);
               AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtValorPorAsiento_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtValorPorAsiento_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VALORPORASIENTO");
                  AnyError = 1;
                  GX_FocusControl = edtValorPorAsiento_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A12ValorPorAsiento = 0;
                  AssignAttri("", false, "A12ValorPorAsiento", StringUtil.LTrimStr( (decimal)(A12ValorPorAsiento), 4, 0));
               }
               else
               {
                  A12ValorPorAsiento = (short)(context.localUtil.CToN( cgiGet( edtValorPorAsiento_Internalname), ",", "."));
                  AssignAttri("", false, "A12ValorPorAsiento", StringUtil.LTrimStr( (decimal)(A12ValorPorAsiento), 4, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtEspectaculoSectorId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEspectaculoSectorId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ESPECTACULOSECTORID");
                  AnyError = 1;
                  GX_FocusControl = edtEspectaculoSectorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A31EspectaculoSectorId = 0;
                  AssignAttri("", false, "A31EspectaculoSectorId", StringUtil.LTrimStr( (decimal)(A31EspectaculoSectorId), 4, 0));
               }
               else
               {
                  A31EspectaculoSectorId = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoSectorId_Internalname), ",", "."));
                  AssignAttri("", false, "A31EspectaculoSectorId", StringUtil.LTrimStr( (decimal)(A31EspectaculoSectorId), 4, 0));
               }
               A32EspectaculoSectorName = cgiGet( edtEspectaculoSectorName_Internalname);
               AssignAttri("", false, "A32EspectaculoSectorName", A32EspectaculoSectorName);
               A35EspectaculoSectorPrecio = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoSectorPrecio_Internalname), ",", "."));
               AssignAttri("", false, "A35EspectaculoSectorPrecio", StringUtil.LTrimStr( (decimal)(A35EspectaculoSectorPrecio), 4, 0));
               A3PaisId = (short)(context.localUtil.CToN( cgiGet( edtPaisId_Internalname), ",", "."));
               AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
               A6PaisName = cgiGet( edtPaisName_Internalname);
               AssignAttri("", false, "A6PaisName", A6PaisName);
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
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Venta");
               A11VentaId = (short)(context.localUtil.CToN( cgiGet( edtVentaId_Internalname), ",", "."));
               AssignAttri("", false, "A11VentaId", StringUtil.LTrimStr( (decimal)(A11VentaId), 4, 0));
               forbiddenHiddens.Add("VentaId", context.localUtil.Format( (decimal)(A11VentaId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A11VentaId != Z11VentaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("venta:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A11VentaId = (short)(NumberUtil.Val( GetPar( "VentaId"), "."));
                  AssignAttri("", false, "A11VentaId", StringUtil.LTrimStr( (decimal)(A11VentaId), 4, 0));
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
                     sMode6 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode6;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound6 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_060( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "VENTAID");
                        AnyError = 1;
                        GX_FocusControl = edtVentaId_Internalname;
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
                           E11062 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12062 ();
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
            E12062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll066( ) ;
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
            DisableAttributes066( ) ;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls066( ) ;
            }
            else
            {
               CheckExtendedTable066( ) ;
               CloseExtendedTableCursors066( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption060( )
      {
      }

      protected void E11062( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV15Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_EspectaculoId = 0;
         AssignAttri("", false, "AV11Insert_EspectaculoId", StringUtil.LTrimStr( (decimal)(AV11Insert_EspectaculoId), 4, 0));
         AV14Insert_EspectaculoSectorId = 0;
         AssignAttri("", false, "AV14Insert_EspectaculoSectorId", StringUtil.LTrimStr( (decimal)(AV14Insert_EspectaculoSectorId), 4, 0));
         AV12Insert_ClienteId = 0;
         AssignAttri("", false, "AV12Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV12Insert_ClienteId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV15Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV16GXV1 = 1;
            AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            while ( AV16GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV16GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "EspectaculoId") == 0 )
               {
                  AV11Insert_EspectaculoId = (short)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_EspectaculoId", StringUtil.LTrimStr( (decimal)(AV11Insert_EspectaculoId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "EspectaculoSectorId") == 0 )
               {
                  AV14Insert_EspectaculoSectorId = (short)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV14Insert_EspectaculoSectorId", StringUtil.LTrimStr( (decimal)(AV14Insert_EspectaculoSectorId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "ClienteId") == 0 )
               {
                  AV12Insert_ClienteId = (short)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV12Insert_ClienteId", StringUtil.LTrimStr( (decimal)(AV12Insert_ClienteId), 4, 0));
               }
               AV16GXV1 = (int)(AV16GXV1+1);
               AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
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

      protected void E12062( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwventa.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM066( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z12ValorPorAsiento = T00063_A12ValorPorAsiento[0];
               Z1EspectaculoId = T00063_A1EspectaculoId[0];
               Z31EspectaculoSectorId = T00063_A31EspectaculoSectorId[0];
               Z9ClienteId = T00063_A9ClienteId[0];
            }
            else
            {
               Z12ValorPorAsiento = A12ValorPorAsiento;
               Z1EspectaculoId = A1EspectaculoId;
               Z31EspectaculoSectorId = A31EspectaculoSectorId;
               Z9ClienteId = A9ClienteId;
            }
         }
         if ( GX_JID == -14 )
         {
            Z11VentaId = A11VentaId;
            Z12ValorPorAsiento = A12ValorPorAsiento;
            Z1EspectaculoId = A1EspectaculoId;
            Z31EspectaculoSectorId = A31EspectaculoSectorId;
            Z9ClienteId = A9ClienteId;
            Z7TipoEspectaculoId = A7TipoEspectaculoId;
            Z2EspectaculoName = A2EspectaculoName;
            Z8TipoEspectaculoName = A8TipoEspectaculoName;
            Z32EspectaculoSectorName = A32EspectaculoSectorName;
            Z35EspectaculoSectorPrecio = A35EspectaculoSectorPrecio;
            Z10ClienteName = A10ClienteName;
            Z3PaisId = A3PaisId;
            Z6PaisName = A6PaisName;
         }
      }

      protected void standaloneNotModal( )
      {
         edtVentaId_Enabled = 0;
         AssignProp("", false, edtVentaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVentaId_Enabled), 5, 0), true);
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ESPECTACULOID"+"'), id:'"+"ESPECTACULOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_31_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00c1.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ESPECTACULOID"+"'), id:'"+"ESPECTACULOID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"ESPECTACULOSECTORID"+"'), id:'"+"ESPECTACULOSECTORID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CLIENTEID"+"'), id:'"+"CLIENTEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtVentaId_Enabled = 0;
         AssignProp("", false, edtVentaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVentaId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7VentaId) )
         {
            A11VentaId = AV7VentaId;
            AssignAttri("", false, "A11VentaId", StringUtil.LTrimStr( (decimal)(A11VentaId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_EspectaculoId) )
         {
            edtEspectaculoId_Enabled = 0;
            AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         }
         else
         {
            edtEspectaculoId_Enabled = 1;
            AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_EspectaculoSectorId) )
         {
            edtEspectaculoSectorId_Enabled = 0;
            AssignProp("", false, edtEspectaculoSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoSectorId_Enabled), 5, 0), true);
         }
         else
         {
            edtEspectaculoSectorId_Enabled = 1;
            AssignProp("", false, edtEspectaculoSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoSectorId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ClienteId) )
         {
            edtClienteId_Enabled = 0;
            AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         }
         else
         {
            edtClienteId_Enabled = 1;
            AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_ClienteId) )
         {
            A9ClienteId = AV12Insert_ClienteId;
            AssignAttri("", false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_EspectaculoSectorId) )
         {
            A31EspectaculoSectorId = AV14Insert_EspectaculoSectorId;
            AssignAttri("", false, "A31EspectaculoSectorId", StringUtil.LTrimStr( (decimal)(A31EspectaculoSectorId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_EspectaculoId) )
         {
            A1EspectaculoId = AV11Insert_EspectaculoId;
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
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
            AV15Pgmname = "Venta";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T00066 */
            pr_default.execute(4, new Object[] {A9ClienteId});
            A10ClienteName = T00066_A10ClienteName[0];
            AssignAttri("", false, "A10ClienteName", A10ClienteName);
            A3PaisId = T00066_A3PaisId[0];
            AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            pr_default.close(4);
            /* Using cursor T00068 */
            pr_default.execute(6, new Object[] {A3PaisId});
            A6PaisName = T00068_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            pr_default.close(6);
            /* Using cursor T00064 */
            pr_default.execute(2, new Object[] {A1EspectaculoId});
            A7TipoEspectaculoId = T00064_A7TipoEspectaculoId[0];
            A2EspectaculoName = T00064_A2EspectaculoName[0];
            AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
            pr_default.close(2);
            /* Using cursor T00067 */
            pr_default.execute(5, new Object[] {A7TipoEspectaculoId});
            A8TipoEspectaculoName = T00067_A8TipoEspectaculoName[0];
            AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            pr_default.close(5);
            /* Using cursor T00065 */
            pr_default.execute(3, new Object[] {A1EspectaculoId, A31EspectaculoSectorId});
            A32EspectaculoSectorName = T00065_A32EspectaculoSectorName[0];
            AssignAttri("", false, "A32EspectaculoSectorName", A32EspectaculoSectorName);
            A35EspectaculoSectorPrecio = T00065_A35EspectaculoSectorPrecio[0];
            AssignAttri("", false, "A35EspectaculoSectorPrecio", StringUtil.LTrimStr( (decimal)(A35EspectaculoSectorPrecio), 4, 0));
            pr_default.close(3);
         }
      }

      protected void Load066( )
      {
         /* Using cursor T00069 */
         pr_default.execute(7, new Object[] {A11VentaId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound6 = 1;
            A7TipoEspectaculoId = T00069_A7TipoEspectaculoId[0];
            A2EspectaculoName = T00069_A2EspectaculoName[0];
            AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
            A8TipoEspectaculoName = T00069_A8TipoEspectaculoName[0];
            AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            A12ValorPorAsiento = T00069_A12ValorPorAsiento[0];
            AssignAttri("", false, "A12ValorPorAsiento", StringUtil.LTrimStr( (decimal)(A12ValorPorAsiento), 4, 0));
            A32EspectaculoSectorName = T00069_A32EspectaculoSectorName[0];
            AssignAttri("", false, "A32EspectaculoSectorName", A32EspectaculoSectorName);
            A35EspectaculoSectorPrecio = T00069_A35EspectaculoSectorPrecio[0];
            AssignAttri("", false, "A35EspectaculoSectorPrecio", StringUtil.LTrimStr( (decimal)(A35EspectaculoSectorPrecio), 4, 0));
            A6PaisName = T00069_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            A10ClienteName = T00069_A10ClienteName[0];
            AssignAttri("", false, "A10ClienteName", A10ClienteName);
            A1EspectaculoId = T00069_A1EspectaculoId[0];
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            A31EspectaculoSectorId = T00069_A31EspectaculoSectorId[0];
            AssignAttri("", false, "A31EspectaculoSectorId", StringUtil.LTrimStr( (decimal)(A31EspectaculoSectorId), 4, 0));
            A9ClienteId = T00069_A9ClienteId[0];
            AssignAttri("", false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
            A3PaisId = T00069_A3PaisId[0];
            AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            ZM066( -14) ;
         }
         pr_default.close(7);
         OnLoadActions066( ) ;
      }

      protected void OnLoadActions066( )
      {
         AV15Pgmname = "Venta";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
      }

      protected void CheckExtendedTable066( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV15Pgmname = "Venta";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A7TipoEspectaculoId = T00064_A7TipoEspectaculoId[0];
         A2EspectaculoName = T00064_A2EspectaculoName[0];
         AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
         pr_default.close(2);
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {A7TipoEspectaculoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
         }
         A8TipoEspectaculoName = T00067_A8TipoEspectaculoName[0];
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
         pr_default.close(5);
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {A1EspectaculoId, A31EspectaculoSectorId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "ESPECTACULOSECTORID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A32EspectaculoSectorName = T00065_A32EspectaculoSectorName[0];
         AssignAttri("", false, "A32EspectaculoSectorName", A32EspectaculoSectorName);
         A35EspectaculoSectorPrecio = T00065_A35EspectaculoSectorPrecio[0];
         AssignAttri("", false, "A35EspectaculoSectorPrecio", StringUtil.LTrimStr( (decimal)(A35EspectaculoSectorPrecio), 4, 0));
         pr_default.close(3);
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10ClienteName = T00066_A10ClienteName[0];
         AssignAttri("", false, "A10ClienteName", A10ClienteName);
         A3PaisId = T00066_A3PaisId[0];
         AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
         pr_default.close(4);
         /* Using cursor T00068 */
         pr_default.execute(6, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = T00068_A6PaisName[0];
         AssignAttri("", false, "A6PaisName", A6PaisName);
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors066( )
      {
         pr_default.close(2);
         pr_default.close(5);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_15( short A1EspectaculoId )
      {
         /* Using cursor T000610 */
         pr_default.execute(8, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A7TipoEspectaculoId = T000610_A7TipoEspectaculoId[0];
         A2EspectaculoName = T000610_A2EspectaculoName[0];
         AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A7TipoEspectaculoId), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A2EspectaculoName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_18( short A7TipoEspectaculoId )
      {
         /* Using cursor T000611 */
         pr_default.execute(9, new Object[] {A7TipoEspectaculoId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
         }
         A8TipoEspectaculoName = T000611_A8TipoEspectaculoName[0];
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A8TipoEspectaculoName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_16( short A1EspectaculoId ,
                                short A31EspectaculoSectorId )
      {
         /* Using cursor T000612 */
         pr_default.execute(10, new Object[] {A1EspectaculoId, A31EspectaculoSectorId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "ESPECTACULOSECTORID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A32EspectaculoSectorName = T000612_A32EspectaculoSectorName[0];
         AssignAttri("", false, "A32EspectaculoSectorName", A32EspectaculoSectorName);
         A35EspectaculoSectorPrecio = T000612_A35EspectaculoSectorPrecio[0];
         AssignAttri("", false, "A35EspectaculoSectorPrecio", StringUtil.LTrimStr( (decimal)(A35EspectaculoSectorPrecio), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A32EspectaculoSectorName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A35EspectaculoSectorPrecio), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_17( short A9ClienteId )
      {
         /* Using cursor T000613 */
         pr_default.execute(11, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10ClienteName = T000613_A10ClienteName[0];
         AssignAttri("", false, "A10ClienteName", A10ClienteName);
         A3PaisId = T000613_A3PaisId[0];
         AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A10ClienteName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_19( short A3PaisId )
      {
         /* Using cursor T000614 */
         pr_default.execute(12, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = T000614_A6PaisName[0];
         AssignAttri("", false, "A6PaisName", A6PaisName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A6PaisName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey066( )
      {
         /* Using cursor T000615 */
         pr_default.execute(13, new Object[] {A11VentaId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A11VentaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM066( 14) ;
            RcdFound6 = 1;
            A11VentaId = T00063_A11VentaId[0];
            AssignAttri("", false, "A11VentaId", StringUtil.LTrimStr( (decimal)(A11VentaId), 4, 0));
            A12ValorPorAsiento = T00063_A12ValorPorAsiento[0];
            AssignAttri("", false, "A12ValorPorAsiento", StringUtil.LTrimStr( (decimal)(A12ValorPorAsiento), 4, 0));
            A1EspectaculoId = T00063_A1EspectaculoId[0];
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            A31EspectaculoSectorId = T00063_A31EspectaculoSectorId[0];
            AssignAttri("", false, "A31EspectaculoSectorId", StringUtil.LTrimStr( (decimal)(A31EspectaculoSectorId), 4, 0));
            A9ClienteId = T00063_A9ClienteId[0];
            AssignAttri("", false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
            Z11VentaId = A11VentaId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load066( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey066( ) ;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey066( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey066( ) ;
         if ( RcdFound6 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound6 = 0;
         /* Using cursor T000616 */
         pr_default.execute(14, new Object[] {A11VentaId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000616_A11VentaId[0] < A11VentaId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000616_A11VentaId[0] > A11VentaId ) ) )
            {
               A11VentaId = T000616_A11VentaId[0];
               AssignAttri("", false, "A11VentaId", StringUtil.LTrimStr( (decimal)(A11VentaId), 4, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T000617 */
         pr_default.execute(15, new Object[] {A11VentaId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T000617_A11VentaId[0] > A11VentaId ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T000617_A11VentaId[0] < A11VentaId ) ) )
            {
               A11VentaId = T000617_A11VentaId[0];
               AssignAttri("", false, "A11VentaId", StringUtil.LTrimStr( (decimal)(A11VentaId), 4, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey066( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert066( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A11VentaId != Z11VentaId )
               {
                  A11VentaId = Z11VentaId;
                  AssignAttri("", false, "A11VentaId", StringUtil.LTrimStr( (decimal)(A11VentaId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "VENTAID");
                  AnyError = 1;
                  GX_FocusControl = edtVentaId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEspectaculoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update066( ) ;
                  GX_FocusControl = edtEspectaculoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A11VentaId != Z11VentaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtEspectaculoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert066( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VENTAID");
                     AnyError = 1;
                     GX_FocusControl = edtVentaId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEspectaculoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert066( ) ;
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
         if ( A11VentaId != Z11VentaId )
         {
            A11VentaId = Z11VentaId;
            AssignAttri("", false, "A11VentaId", StringUtil.LTrimStr( (decimal)(A11VentaId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "VENTAID");
            AnyError = 1;
            GX_FocusControl = edtVentaId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency066( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A11VentaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Venta"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z12ValorPorAsiento != T00062_A12ValorPorAsiento[0] ) || ( Z1EspectaculoId != T00062_A1EspectaculoId[0] ) || ( Z31EspectaculoSectorId != T00062_A31EspectaculoSectorId[0] ) || ( Z9ClienteId != T00062_A9ClienteId[0] ) )
            {
               if ( Z12ValorPorAsiento != T00062_A12ValorPorAsiento[0] )
               {
                  GXUtil.WriteLog("venta:[seudo value changed for attri]"+"ValorPorAsiento");
                  GXUtil.WriteLogRaw("Old: ",Z12ValorPorAsiento);
                  GXUtil.WriteLogRaw("Current: ",T00062_A12ValorPorAsiento[0]);
               }
               if ( Z1EspectaculoId != T00062_A1EspectaculoId[0] )
               {
                  GXUtil.WriteLog("venta:[seudo value changed for attri]"+"EspectaculoId");
                  GXUtil.WriteLogRaw("Old: ",Z1EspectaculoId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A1EspectaculoId[0]);
               }
               if ( Z31EspectaculoSectorId != T00062_A31EspectaculoSectorId[0] )
               {
                  GXUtil.WriteLog("venta:[seudo value changed for attri]"+"EspectaculoSectorId");
                  GXUtil.WriteLogRaw("Old: ",Z31EspectaculoSectorId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A31EspectaculoSectorId[0]);
               }
               if ( Z9ClienteId != T00062_A9ClienteId[0] )
               {
                  GXUtil.WriteLog("venta:[seudo value changed for attri]"+"ClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z9ClienteId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A9ClienteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Venta"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM066( 0) ;
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000618 */
                     pr_default.execute(16, new Object[] {A12ValorPorAsiento, A1EspectaculoId, A31EspectaculoSectorId, A9ClienteId});
                     A11VentaId = T000618_A11VentaId[0];
                     AssignAttri("", false, "A11VentaId", StringUtil.LTrimStr( (decimal)(A11VentaId), 4, 0));
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("Venta");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption060( ) ;
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
               Load066( ) ;
            }
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void Update066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000619 */
                     pr_default.execute(17, new Object[] {A12ValorPorAsiento, A1EspectaculoId, A31EspectaculoSectorId, A9ClienteId, A11VentaId});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("Venta");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Venta"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate066( ) ;
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
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void DeferredUpdate066( )
      {
      }

      protected void delete( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls066( ) ;
            AfterConfirm066( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete066( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000620 */
                  pr_default.execute(18, new Object[] {A11VentaId});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("Venta");
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel066( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls066( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "Venta";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T000621 */
            pr_default.execute(19, new Object[] {A1EspectaculoId});
            A7TipoEspectaculoId = T000621_A7TipoEspectaculoId[0];
            A2EspectaculoName = T000621_A2EspectaculoName[0];
            AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
            pr_default.close(19);
            /* Using cursor T000622 */
            pr_default.execute(20, new Object[] {A7TipoEspectaculoId});
            A8TipoEspectaculoName = T000622_A8TipoEspectaculoName[0];
            AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            pr_default.close(20);
            /* Using cursor T000623 */
            pr_default.execute(21, new Object[] {A1EspectaculoId, A31EspectaculoSectorId});
            A32EspectaculoSectorName = T000623_A32EspectaculoSectorName[0];
            AssignAttri("", false, "A32EspectaculoSectorName", A32EspectaculoSectorName);
            A35EspectaculoSectorPrecio = T000623_A35EspectaculoSectorPrecio[0];
            AssignAttri("", false, "A35EspectaculoSectorPrecio", StringUtil.LTrimStr( (decimal)(A35EspectaculoSectorPrecio), 4, 0));
            pr_default.close(21);
            /* Using cursor T000624 */
            pr_default.execute(22, new Object[] {A9ClienteId});
            A10ClienteName = T000624_A10ClienteName[0];
            AssignAttri("", false, "A10ClienteName", A10ClienteName);
            A3PaisId = T000624_A3PaisId[0];
            AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            pr_default.close(22);
            /* Using cursor T000625 */
            pr_default.execute(23, new Object[] {A3PaisId});
            A6PaisName = T000625_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            pr_default.close(23);
         }
      }

      protected void EndLevel066( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete066( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(21);
            pr_default.close(22);
            pr_default.close(20);
            pr_default.close(23);
            context.CommitDataStores("venta",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
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
            pr_default.close(22);
            pr_default.close(20);
            pr_default.close(23);
            context.RollbackDataStores("venta",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart066( )
      {
         /* Scan By routine */
         /* Using cursor T000626 */
         pr_default.execute(24);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound6 = 1;
            A11VentaId = T000626_A11VentaId[0];
            AssignAttri("", false, "A11VentaId", StringUtil.LTrimStr( (decimal)(A11VentaId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext066( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound6 = 1;
            A11VentaId = T000626_A11VentaId[0];
            AssignAttri("", false, "A11VentaId", StringUtil.LTrimStr( (decimal)(A11VentaId), 4, 0));
         }
      }

      protected void ScanEnd066( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm066( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert066( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate066( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete066( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete066( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate066( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes066( )
      {
         edtVentaId_Enabled = 0;
         AssignProp("", false, edtVentaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVentaId_Enabled), 5, 0), true);
         edtEspectaculoId_Enabled = 0;
         AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         edtEspectaculoName_Enabled = 0;
         AssignProp("", false, edtEspectaculoName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoName_Enabled), 5, 0), true);
         edtTipoEspectaculoName_Enabled = 0;
         AssignProp("", false, edtTipoEspectaculoName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoName_Enabled), 5, 0), true);
         edtValorPorAsiento_Enabled = 0;
         AssignProp("", false, edtValorPorAsiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtValorPorAsiento_Enabled), 5, 0), true);
         edtEspectaculoSectorId_Enabled = 0;
         AssignProp("", false, edtEspectaculoSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoSectorId_Enabled), 5, 0), true);
         edtEspectaculoSectorName_Enabled = 0;
         AssignProp("", false, edtEspectaculoSectorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoSectorName_Enabled), 5, 0), true);
         edtEspectaculoSectorPrecio_Enabled = 0;
         AssignProp("", false, edtEspectaculoSectorPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoSectorPrecio_Enabled), 5, 0), true);
         edtPaisId_Enabled = 0;
         AssignProp("", false, edtPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisId_Enabled), 5, 0), true);
         edtPaisName_Enabled = 0;
         AssignProp("", false, edtPaisName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisName_Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         edtClienteName_Enabled = 0;
         AssignProp("", false, edtClienteName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes066( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues060( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228822543575", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("venta.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7VentaId,4,0))}, new string[] {"Gx_mode","VentaId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Venta");
         forbiddenHiddens.Add("VentaId", context.localUtil.Format( (decimal)(A11VentaId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("venta:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z11VentaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11VentaId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z12ValorPorAsiento", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12ValorPorAsiento), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z1EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z31EspectaculoSectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31EspectaculoSectorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z9ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9ClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N1EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N31EspectaculoSectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A31EspectaculoSectorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N9ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9ClienteId), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vVENTAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7VentaId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vVENTAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7VentaId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESPECTACULOSECTORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_EspectaculoSectorId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_ClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TIPOESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7TipoEspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
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
         return formatLink("venta.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7VentaId,4,0))}, new string[] {"Gx_mode","VentaId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Venta" ;
      }

      public override string GetPgmdesc( )
      {
         return "Venta" ;
      }

      protected void InitializeNonKey066( )
      {
         A7TipoEspectaculoId = 0;
         AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
         A1EspectaculoId = 0;
         AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         A31EspectaculoSectorId = 0;
         AssignAttri("", false, "A31EspectaculoSectorId", StringUtil.LTrimStr( (decimal)(A31EspectaculoSectorId), 4, 0));
         A9ClienteId = 0;
         AssignAttri("", false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
         A2EspectaculoName = "";
         AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
         A8TipoEspectaculoName = "";
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
         A12ValorPorAsiento = 0;
         AssignAttri("", false, "A12ValorPorAsiento", StringUtil.LTrimStr( (decimal)(A12ValorPorAsiento), 4, 0));
         A32EspectaculoSectorName = "";
         AssignAttri("", false, "A32EspectaculoSectorName", A32EspectaculoSectorName);
         A35EspectaculoSectorPrecio = 0;
         AssignAttri("", false, "A35EspectaculoSectorPrecio", StringUtil.LTrimStr( (decimal)(A35EspectaculoSectorPrecio), 4, 0));
         A3PaisId = 0;
         AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
         A6PaisName = "";
         AssignAttri("", false, "A6PaisName", A6PaisName);
         A10ClienteName = "";
         AssignAttri("", false, "A10ClienteName", A10ClienteName);
         Z12ValorPorAsiento = 0;
         Z1EspectaculoId = 0;
         Z31EspectaculoSectorId = 0;
         Z9ClienteId = 0;
      }

      protected void InitAll066( )
      {
         A11VentaId = 0;
         AssignAttri("", false, "A11VentaId", StringUtil.LTrimStr( (decimal)(A11VentaId), 4, 0));
         InitializeNonKey066( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228822543581", true, true);
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
         context.AddJavascriptSource("venta.js", "?20228822543581", false, true);
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
         edtVentaId_Internalname = "VENTAID";
         edtEspectaculoId_Internalname = "ESPECTACULOID";
         edtEspectaculoName_Internalname = "ESPECTACULONAME";
         edtTipoEspectaculoName_Internalname = "TIPOESPECTACULONAME";
         edtValorPorAsiento_Internalname = "VALORPORASIENTO";
         edtEspectaculoSectorId_Internalname = "ESPECTACULOSECTORID";
         edtEspectaculoSectorName_Internalname = "ESPECTACULOSECTORNAME";
         edtEspectaculoSectorPrecio_Internalname = "ESPECTACULOSECTORPRECIO";
         edtPaisId_Internalname = "PAISID";
         edtPaisName_Internalname = "PAISNAME";
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteName_Internalname = "CLIENTENAME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_1_Internalname = "PROMPT_1";
         imgprompt_31_Internalname = "PROMPT_31";
         imgprompt_9_Internalname = "PROMPT_9";
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
         Form.Caption = "Venta";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtClienteName_Jsonclick = "";
         edtClienteName_Enabled = 0;
         imgprompt_9_Visible = 1;
         imgprompt_9_Link = "";
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
         edtPaisName_Jsonclick = "";
         edtPaisName_Enabled = 0;
         edtPaisId_Jsonclick = "";
         edtPaisId_Enabled = 0;
         edtEspectaculoSectorPrecio_Jsonclick = "";
         edtEspectaculoSectorPrecio_Enabled = 0;
         edtEspectaculoSectorName_Jsonclick = "";
         edtEspectaculoSectorName_Enabled = 0;
         imgprompt_31_Visible = 1;
         imgprompt_31_Link = "";
         edtEspectaculoSectorId_Jsonclick = "";
         edtEspectaculoSectorId_Enabled = 1;
         edtValorPorAsiento_Jsonclick = "";
         edtValorPorAsiento_Enabled = 1;
         edtTipoEspectaculoName_Jsonclick = "";
         edtTipoEspectaculoName_Enabled = 0;
         edtEspectaculoName_Jsonclick = "";
         edtEspectaculoName_Enabled = 0;
         imgprompt_1_Visible = 1;
         imgprompt_1_Link = "";
         edtEspectaculoId_Jsonclick = "";
         edtEspectaculoId_Enabled = 1;
         edtVentaId_Jsonclick = "";
         edtVentaId_Enabled = 0;
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

      public void Valid_Espectaculoid( )
      {
         /* Using cursor T000621 */
         pr_default.execute(19, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
         }
         A7TipoEspectaculoId = T000621_A7TipoEspectaculoId[0];
         A2EspectaculoName = T000621_A2EspectaculoName[0];
         pr_default.close(19);
         /* Using cursor T000622 */
         pr_default.execute(20, new Object[] {A7TipoEspectaculoId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
         }
         A8TipoEspectaculoName = T000622_A8TipoEspectaculoName[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7TipoEspectaculoId), 4, 0, ".", "")));
         AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
      }

      public void Valid_Espectaculosectorid( )
      {
         /* Using cursor T000623 */
         pr_default.execute(21, new Object[] {A1EspectaculoId, A31EspectaculoSectorId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "ESPECTACULOSECTORID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
         }
         A32EspectaculoSectorName = T000623_A32EspectaculoSectorName[0];
         A35EspectaculoSectorPrecio = T000623_A35EspectaculoSectorPrecio[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A32EspectaculoSectorName", A32EspectaculoSectorName);
         AssignAttri("", false, "A35EspectaculoSectorPrecio", StringUtil.LTrim( StringUtil.NToC( (decimal)(A35EspectaculoSectorPrecio), 4, 0, ".", "")));
      }

      public void Valid_Paisid( )
      {
         /* Using cursor T000625 */
         pr_default.execute(23, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = T000625_A6PaisName[0];
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A6PaisName", A6PaisName);
      }

      public void Valid_Clienteid( )
      {
         /* Using cursor T000624 */
         pr_default.execute(22, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
         }
         A10ClienteName = T000624_A10ClienteName[0];
         A3PaisId = T000624_A3PaisId[0];
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A10ClienteName", A10ClienteName);
         AssignAttri("", false, "A3PaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7VentaId',fld:'vVENTAID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7VentaId',fld:'vVENTAID',pic:'ZZZ9',hsh:true},{av:'A11VentaId',fld:'VENTAID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12062',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_VENTAID","{handler:'Valid_Ventaid',iparms:[]");
         setEventMetadata("VALID_VENTAID",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOID","{handler:'Valid_Espectaculoid',iparms:[{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A7TipoEspectaculoId',fld:'TIPOESPECTACULOID',pic:'ZZZ9'},{av:'A2EspectaculoName',fld:'ESPECTACULONAME',pic:''},{av:'A8TipoEspectaculoName',fld:'TIPOESPECTACULONAME',pic:''}]");
         setEventMetadata("VALID_ESPECTACULOID",",oparms:[{av:'A7TipoEspectaculoId',fld:'TIPOESPECTACULOID',pic:'ZZZ9'},{av:'A2EspectaculoName',fld:'ESPECTACULONAME',pic:''},{av:'A8TipoEspectaculoName',fld:'TIPOESPECTACULONAME',pic:''}]}");
         setEventMetadata("VALID_ESPECTACULOSECTORID","{handler:'Valid_Espectaculosectorid',iparms:[{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A31EspectaculoSectorId',fld:'ESPECTACULOSECTORID',pic:'ZZZ9'},{av:'A32EspectaculoSectorName',fld:'ESPECTACULOSECTORNAME',pic:''},{av:'A35EspectaculoSectorPrecio',fld:'ESPECTACULOSECTORPRECIO',pic:'ZZZ9'}]");
         setEventMetadata("VALID_ESPECTACULOSECTORID",",oparms:[{av:'A32EspectaculoSectorName',fld:'ESPECTACULOSECTORNAME',pic:''},{av:'A35EspectaculoSectorPrecio',fld:'ESPECTACULOSECTORPRECIO',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_PAISID","{handler:'Valid_Paisid',iparms:[{av:'A3PaisId',fld:'PAISID',pic:'ZZZ9'},{av:'A6PaisName',fld:'PAISNAME',pic:''}]");
         setEventMetadata("VALID_PAISID",",oparms:[{av:'A6PaisName',fld:'PAISNAME',pic:''}]}");
         setEventMetadata("VALID_CLIENTEID","{handler:'Valid_Clienteid',iparms:[{av:'A9ClienteId',fld:'CLIENTEID',pic:'ZZZ9'},{av:'A10ClienteName',fld:'CLIENTENAME',pic:''},{av:'A3PaisId',fld:'PAISID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_CLIENTEID",",oparms:[{av:'A10ClienteName',fld:'CLIENTENAME',pic:''},{av:'A3PaisId',fld:'PAISID',pic:'ZZZ9'}]}");
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
         pr_default.close(22);
         pr_default.close(20);
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
         A2EspectaculoName = "";
         A8TipoEspectaculoName = "";
         A32EspectaculoSectorName = "";
         A6PaisName = "";
         A10ClienteName = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV15Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode6 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z2EspectaculoName = "";
         Z8TipoEspectaculoName = "";
         Z32EspectaculoSectorName = "";
         Z10ClienteName = "";
         Z6PaisName = "";
         T00066_A10ClienteName = new string[] {""} ;
         T00066_A3PaisId = new short[1] ;
         T00068_A6PaisName = new string[] {""} ;
         T00064_A7TipoEspectaculoId = new short[1] ;
         T00064_A2EspectaculoName = new string[] {""} ;
         T00067_A8TipoEspectaculoName = new string[] {""} ;
         T00065_A32EspectaculoSectorName = new string[] {""} ;
         T00065_A35EspectaculoSectorPrecio = new short[1] ;
         T00069_A7TipoEspectaculoId = new short[1] ;
         T00069_A11VentaId = new short[1] ;
         T00069_A2EspectaculoName = new string[] {""} ;
         T00069_A8TipoEspectaculoName = new string[] {""} ;
         T00069_A12ValorPorAsiento = new short[1] ;
         T00069_A32EspectaculoSectorName = new string[] {""} ;
         T00069_A35EspectaculoSectorPrecio = new short[1] ;
         T00069_A6PaisName = new string[] {""} ;
         T00069_A10ClienteName = new string[] {""} ;
         T00069_A1EspectaculoId = new short[1] ;
         T00069_A31EspectaculoSectorId = new short[1] ;
         T00069_A9ClienteId = new short[1] ;
         T00069_A3PaisId = new short[1] ;
         T000610_A7TipoEspectaculoId = new short[1] ;
         T000610_A2EspectaculoName = new string[] {""} ;
         T000611_A8TipoEspectaculoName = new string[] {""} ;
         T000612_A32EspectaculoSectorName = new string[] {""} ;
         T000612_A35EspectaculoSectorPrecio = new short[1] ;
         T000613_A10ClienteName = new string[] {""} ;
         T000613_A3PaisId = new short[1] ;
         T000614_A6PaisName = new string[] {""} ;
         T000615_A11VentaId = new short[1] ;
         T00063_A11VentaId = new short[1] ;
         T00063_A12ValorPorAsiento = new short[1] ;
         T00063_A1EspectaculoId = new short[1] ;
         T00063_A31EspectaculoSectorId = new short[1] ;
         T00063_A9ClienteId = new short[1] ;
         T000616_A11VentaId = new short[1] ;
         T000617_A11VentaId = new short[1] ;
         T00062_A11VentaId = new short[1] ;
         T00062_A12ValorPorAsiento = new short[1] ;
         T00062_A1EspectaculoId = new short[1] ;
         T00062_A31EspectaculoSectorId = new short[1] ;
         T00062_A9ClienteId = new short[1] ;
         T000618_A11VentaId = new short[1] ;
         T000621_A7TipoEspectaculoId = new short[1] ;
         T000621_A2EspectaculoName = new string[] {""} ;
         T000622_A8TipoEspectaculoName = new string[] {""} ;
         T000623_A32EspectaculoSectorName = new string[] {""} ;
         T000623_A35EspectaculoSectorPrecio = new short[1] ;
         T000624_A10ClienteName = new string[] {""} ;
         T000624_A3PaisId = new short[1] ;
         T000625_A6PaisName = new string[] {""} ;
         T000626_A11VentaId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.venta__default(),
            new Object[][] {
                new Object[] {
               T00062_A11VentaId, T00062_A12ValorPorAsiento, T00062_A1EspectaculoId, T00062_A31EspectaculoSectorId, T00062_A9ClienteId
               }
               , new Object[] {
               T00063_A11VentaId, T00063_A12ValorPorAsiento, T00063_A1EspectaculoId, T00063_A31EspectaculoSectorId, T00063_A9ClienteId
               }
               , new Object[] {
               T00064_A7TipoEspectaculoId, T00064_A2EspectaculoName
               }
               , new Object[] {
               T00065_A32EspectaculoSectorName, T00065_A35EspectaculoSectorPrecio
               }
               , new Object[] {
               T00066_A10ClienteName, T00066_A3PaisId
               }
               , new Object[] {
               T00067_A8TipoEspectaculoName
               }
               , new Object[] {
               T00068_A6PaisName
               }
               , new Object[] {
               T00069_A7TipoEspectaculoId, T00069_A11VentaId, T00069_A2EspectaculoName, T00069_A8TipoEspectaculoName, T00069_A12ValorPorAsiento, T00069_A32EspectaculoSectorName, T00069_A35EspectaculoSectorPrecio, T00069_A6PaisName, T00069_A10ClienteName, T00069_A1EspectaculoId,
               T00069_A31EspectaculoSectorId, T00069_A9ClienteId, T00069_A3PaisId
               }
               , new Object[] {
               T000610_A7TipoEspectaculoId, T000610_A2EspectaculoName
               }
               , new Object[] {
               T000611_A8TipoEspectaculoName
               }
               , new Object[] {
               T000612_A32EspectaculoSectorName, T000612_A35EspectaculoSectorPrecio
               }
               , new Object[] {
               T000613_A10ClienteName, T000613_A3PaisId
               }
               , new Object[] {
               T000614_A6PaisName
               }
               , new Object[] {
               T000615_A11VentaId
               }
               , new Object[] {
               T000616_A11VentaId
               }
               , new Object[] {
               T000617_A11VentaId
               }
               , new Object[] {
               T000618_A11VentaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000621_A7TipoEspectaculoId, T000621_A2EspectaculoName
               }
               , new Object[] {
               T000622_A8TipoEspectaculoName
               }
               , new Object[] {
               T000623_A32EspectaculoSectorName, T000623_A35EspectaculoSectorPrecio
               }
               , new Object[] {
               T000624_A10ClienteName, T000624_A3PaisId
               }
               , new Object[] {
               T000625_A6PaisName
               }
               , new Object[] {
               T000626_A11VentaId
               }
            }
         );
         AV15Pgmname = "Venta";
      }

      private short wcpOAV7VentaId ;
      private short Z11VentaId ;
      private short Z12ValorPorAsiento ;
      private short Z1EspectaculoId ;
      private short Z31EspectaculoSectorId ;
      private short Z9ClienteId ;
      private short N1EspectaculoId ;
      private short N31EspectaculoSectorId ;
      private short N9ClienteId ;
      private short GxWebError ;
      private short A1EspectaculoId ;
      private short A7TipoEspectaculoId ;
      private short A31EspectaculoSectorId ;
      private short A9ClienteId ;
      private short A3PaisId ;
      private short AV7VentaId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A11VentaId ;
      private short A12ValorPorAsiento ;
      private short A35EspectaculoSectorPrecio ;
      private short AV11Insert_EspectaculoId ;
      private short AV14Insert_EspectaculoSectorId ;
      private short AV12Insert_ClienteId ;
      private short RcdFound6 ;
      private short GX_JID ;
      private short Z7TipoEspectaculoId ;
      private short Z35EspectaculoSectorPrecio ;
      private short Z3PaisId ;
      private short Gx_BScreen ;
      private short nIsDirty_6 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtVentaId_Enabled ;
      private int edtEspectaculoId_Enabled ;
      private int imgprompt_1_Visible ;
      private int edtEspectaculoName_Enabled ;
      private int edtTipoEspectaculoName_Enabled ;
      private int edtValorPorAsiento_Enabled ;
      private int edtEspectaculoSectorId_Enabled ;
      private int imgprompt_31_Visible ;
      private int edtEspectaculoSectorName_Enabled ;
      private int edtEspectaculoSectorPrecio_Enabled ;
      private int edtPaisId_Enabled ;
      private int edtPaisName_Enabled ;
      private int edtClienteId_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtClienteName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV16GXV1 ;
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
      private string edtEspectaculoId_Internalname ;
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
      private string edtVentaId_Internalname ;
      private string edtVentaId_Jsonclick ;
      private string edtEspectaculoId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_1_Internalname ;
      private string imgprompt_1_Link ;
      private string edtEspectaculoName_Internalname ;
      private string edtEspectaculoName_Jsonclick ;
      private string edtTipoEspectaculoName_Internalname ;
      private string edtTipoEspectaculoName_Jsonclick ;
      private string edtValorPorAsiento_Internalname ;
      private string edtValorPorAsiento_Jsonclick ;
      private string edtEspectaculoSectorId_Internalname ;
      private string edtEspectaculoSectorId_Jsonclick ;
      private string imgprompt_31_Internalname ;
      private string imgprompt_31_Link ;
      private string edtEspectaculoSectorName_Internalname ;
      private string edtEspectaculoSectorName_Jsonclick ;
      private string edtEspectaculoSectorPrecio_Internalname ;
      private string edtEspectaculoSectorPrecio_Jsonclick ;
      private string edtPaisId_Internalname ;
      private string edtPaisId_Jsonclick ;
      private string edtPaisName_Internalname ;
      private string edtPaisName_Jsonclick ;
      private string edtClienteId_Internalname ;
      private string edtClienteId_Jsonclick ;
      private string imgprompt_9_Internalname ;
      private string imgprompt_9_Link ;
      private string edtClienteName_Internalname ;
      private string edtClienteName_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV15Pgmname ;
      private string hsh ;
      private string sMode6 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private string A2EspectaculoName ;
      private string A8TipoEspectaculoName ;
      private string A32EspectaculoSectorName ;
      private string A6PaisName ;
      private string A10ClienteName ;
      private string Z2EspectaculoName ;
      private string Z8TipoEspectaculoName ;
      private string Z32EspectaculoSectorName ;
      private string Z10ClienteName ;
      private string Z6PaisName ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00066_A10ClienteName ;
      private short[] T00066_A3PaisId ;
      private string[] T00068_A6PaisName ;
      private short[] T00064_A7TipoEspectaculoId ;
      private string[] T00064_A2EspectaculoName ;
      private string[] T00067_A8TipoEspectaculoName ;
      private string[] T00065_A32EspectaculoSectorName ;
      private short[] T00065_A35EspectaculoSectorPrecio ;
      private short[] T00069_A7TipoEspectaculoId ;
      private short[] T00069_A11VentaId ;
      private string[] T00069_A2EspectaculoName ;
      private string[] T00069_A8TipoEspectaculoName ;
      private short[] T00069_A12ValorPorAsiento ;
      private string[] T00069_A32EspectaculoSectorName ;
      private short[] T00069_A35EspectaculoSectorPrecio ;
      private string[] T00069_A6PaisName ;
      private string[] T00069_A10ClienteName ;
      private short[] T00069_A1EspectaculoId ;
      private short[] T00069_A31EspectaculoSectorId ;
      private short[] T00069_A9ClienteId ;
      private short[] T00069_A3PaisId ;
      private short[] T000610_A7TipoEspectaculoId ;
      private string[] T000610_A2EspectaculoName ;
      private string[] T000611_A8TipoEspectaculoName ;
      private string[] T000612_A32EspectaculoSectorName ;
      private short[] T000612_A35EspectaculoSectorPrecio ;
      private string[] T000613_A10ClienteName ;
      private short[] T000613_A3PaisId ;
      private string[] T000614_A6PaisName ;
      private short[] T000615_A11VentaId ;
      private short[] T00063_A11VentaId ;
      private short[] T00063_A12ValorPorAsiento ;
      private short[] T00063_A1EspectaculoId ;
      private short[] T00063_A31EspectaculoSectorId ;
      private short[] T00063_A9ClienteId ;
      private short[] T000616_A11VentaId ;
      private short[] T000617_A11VentaId ;
      private short[] T00062_A11VentaId ;
      private short[] T00062_A12ValorPorAsiento ;
      private short[] T00062_A1EspectaculoId ;
      private short[] T00062_A31EspectaculoSectorId ;
      private short[] T00062_A9ClienteId ;
      private short[] T000618_A11VentaId ;
      private short[] T000621_A7TipoEspectaculoId ;
      private string[] T000621_A2EspectaculoName ;
      private string[] T000622_A8TipoEspectaculoName ;
      private string[] T000623_A32EspectaculoSectorName ;
      private short[] T000623_A35EspectaculoSectorPrecio ;
      private string[] T000624_A10ClienteName ;
      private short[] T000624_A3PaisId ;
      private string[] T000625_A6PaisName ;
      private short[] T000626_A11VentaId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV13TrnContextAtt ;
   }

   public class venta__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT00069;
          prmT00069 = new Object[] {
          new ParDef("@VentaId",GXType.Int16,4,0)
          };
          Object[] prmT00064;
          prmT00064 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00067;
          prmT00067 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00065;
          prmT00065 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoSectorId",GXType.Int16,4,0)
          };
          Object[] prmT00066;
          prmT00066 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT00068;
          prmT00068 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000610;
          prmT000610 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000611;
          prmT000611 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000612;
          prmT000612 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000613;
          prmT000613 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000614;
          prmT000614 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000615;
          prmT000615 = new Object[] {
          new ParDef("@VentaId",GXType.Int16,4,0)
          };
          Object[] prmT00063;
          prmT00063 = new Object[] {
          new ParDef("@VentaId",GXType.Int16,4,0)
          };
          Object[] prmT000616;
          prmT000616 = new Object[] {
          new ParDef("@VentaId",GXType.Int16,4,0)
          };
          Object[] prmT000617;
          prmT000617 = new Object[] {
          new ParDef("@VentaId",GXType.Int16,4,0)
          };
          Object[] prmT00062;
          prmT00062 = new Object[] {
          new ParDef("@VentaId",GXType.Int16,4,0)
          };
          Object[] prmT000618;
          prmT000618 = new Object[] {
          new ParDef("@ValorPorAsiento",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoSectorId",GXType.Int16,4,0) ,
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000619;
          prmT000619 = new Object[] {
          new ParDef("@ValorPorAsiento",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoSectorId",GXType.Int16,4,0) ,
          new ParDef("@ClienteId",GXType.Int16,4,0) ,
          new ParDef("@VentaId",GXType.Int16,4,0)
          };
          Object[] prmT000620;
          prmT000620 = new Object[] {
          new ParDef("@VentaId",GXType.Int16,4,0)
          };
          Object[] prmT000626;
          prmT000626 = new Object[] {
          };
          Object[] prmT000621;
          prmT000621 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000622;
          prmT000622 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000623;
          prmT000623 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000625;
          prmT000625 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000624;
          prmT000624 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00062", "SELECT [VentaId], [ValorPorAsiento], [EspectaculoId], [EspectaculoSectorId], [ClienteId] FROM [Venta] WITH (UPDLOCK) WHERE [VentaId] = @VentaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00063", "SELECT [VentaId], [ValorPorAsiento], [EspectaculoId], [EspectaculoSectorId], [ClienteId] FROM [Venta] WHERE [VentaId] = @VentaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00064", "SELECT [TipoEspectaculoId], [EspectaculoName] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00065", "SELECT [EspectaculoSectorName], [EspectaculoSectorPrecio] FROM [EspectaculoSector] WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoSectorId] = @EspectaculoSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00066", "SELECT [ClienteName], [PaisId] FROM [Cliente] WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00067", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00068", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00069", "SELECT T2.[TipoEspectaculoId], TM1.[VentaId], T2.[EspectaculoName], T3.[TipoEspectaculoName], TM1.[ValorPorAsiento], T4.[EspectaculoSectorName], T4.[EspectaculoSectorPrecio], T6.[PaisName], T5.[ClienteName], TM1.[EspectaculoId], TM1.[EspectaculoSectorId], TM1.[ClienteId], T5.[PaisId] FROM ((((([Venta] TM1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = TM1.[EspectaculoId]) INNER JOIN [TipoEspectaculo] T3 ON T3.[TipoEspectaculoId] = T2.[TipoEspectaculoId]) INNER JOIN [EspectaculoSector] T4 ON T4.[EspectaculoId] = TM1.[EspectaculoId] AND T4.[EspectaculoSectorId] = TM1.[EspectaculoSectorId]) INNER JOIN [Cliente] T5 ON T5.[ClienteId] = TM1.[ClienteId]) INNER JOIN [Pais] T6 ON T6.[PaisId] = T5.[PaisId]) WHERE TM1.[VentaId] = @VentaId ORDER BY TM1.[VentaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00069,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000610", "SELECT [TipoEspectaculoId], [EspectaculoName] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000610,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000611", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000611,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000612", "SELECT [EspectaculoSectorName], [EspectaculoSectorPrecio] FROM [EspectaculoSector] WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoSectorId] = @EspectaculoSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000612,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000613", "SELECT [ClienteName], [PaisId] FROM [Cliente] WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000613,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000614", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000614,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000615", "SELECT [VentaId] FROM [Venta] WHERE [VentaId] = @VentaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000615,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000616", "SELECT TOP 1 [VentaId] FROM [Venta] WHERE ( [VentaId] > @VentaId) ORDER BY [VentaId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000616,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000617", "SELECT TOP 1 [VentaId] FROM [Venta] WHERE ( [VentaId] < @VentaId) ORDER BY [VentaId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000617,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000618", "INSERT INTO [Venta]([ValorPorAsiento], [EspectaculoId], [EspectaculoSectorId], [ClienteId]) VALUES(@ValorPorAsiento, @EspectaculoId, @EspectaculoSectorId, @ClienteId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000618,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000619", "UPDATE [Venta] SET [ValorPorAsiento]=@ValorPorAsiento, [EspectaculoId]=@EspectaculoId, [EspectaculoSectorId]=@EspectaculoSectorId, [ClienteId]=@ClienteId  WHERE [VentaId] = @VentaId", GxErrorMask.GX_NOMASK,prmT000619)
             ,new CursorDef("T000620", "DELETE FROM [Venta]  WHERE [VentaId] = @VentaId", GxErrorMask.GX_NOMASK,prmT000620)
             ,new CursorDef("T000621", "SELECT [TipoEspectaculoId], [EspectaculoName] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000621,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000622", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000622,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000623", "SELECT [EspectaculoSectorName], [EspectaculoSectorPrecio] FROM [EspectaculoSector] WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoSectorId] = @EspectaculoSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000623,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000624", "SELECT [ClienteName], [PaisId] FROM [Cliente] WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000624,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000625", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000625,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000626", "SELECT [VentaId] FROM [Venta] ORDER BY [VentaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000626,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
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
