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
   public class funcion : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A1EspectaculoId = (short)(NumberUtil.Val( GetPar( "EspectaculoId"), "."));
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A1EspectaculoId) ;
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
               AV7FuncionId = (short)(NumberUtil.Val( GetPar( "FuncionId"), "."));
               AssignAttri("", false, "AV7FuncionId", StringUtil.LTrimStr( (decimal)(AV7FuncionId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vFUNCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7FuncionId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Funcion", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFuncionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public funcion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public funcion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_FuncionId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7FuncionId = aP1_FuncionId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Funcion", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Funcion.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Funcion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Funcion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Funcion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Funcion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Funcion.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFuncionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFuncionId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFuncionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15FuncionId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A15FuncionId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFuncionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFuncionId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Funcion.htm");
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
         GxWebStd.gx_single_line_edit( context, edtEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Funcion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1_Internalname, sImgUrl, imgprompt_1_Link, "", "", context.GetTheme( ), imgprompt_1_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Funcion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPrecioFuncion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPrecioFuncion_Internalname, "Funcion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrecioFuncion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A21PrecioFuncion), 4, 0, ",", "")), StringUtil.LTrim( ((edtPrecioFuncion_Enabled!=0) ? context.localUtil.Format( (decimal)(A21PrecioFuncion), "ZZZ9") : context.localUtil.Format( (decimal)(A21PrecioFuncion), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrecioFuncion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrecioFuncion_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Funcion.htm");
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
         GxWebStd.gx_label_element( context, edtFuncionName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFuncionName_Internalname, StringUtil.RTrim( A22FuncionName), StringUtil.RTrim( context.localUtil.Format( A22FuncionName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFuncionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFuncionName_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Funcion.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Funcion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Funcion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Funcion.htm");
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
         E11072 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z15FuncionId = (short)(context.localUtil.CToN( cgiGet( "Z15FuncionId"), ",", "."));
               Z21PrecioFuncion = (short)(context.localUtil.CToN( cgiGet( "Z21PrecioFuncion"), ",", "."));
               Z22FuncionName = cgiGet( "Z22FuncionName");
               Z1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( "Z1EspectaculoId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               N1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( "N1EspectaculoId"), ",", "."));
               AV7FuncionId = (short)(context.localUtil.CToN( cgiGet( "vFUNCIONID"), ",", "."));
               AV11Insert_EspectaculoId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_ESPECTACULOID"), ",", "."));
               AV13Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtPrecioFuncion_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPrecioFuncion_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRECIOFUNCION");
                  AnyError = 1;
                  GX_FocusControl = edtPrecioFuncion_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A21PrecioFuncion = 0;
                  AssignAttri("", false, "A21PrecioFuncion", StringUtil.LTrimStr( (decimal)(A21PrecioFuncion), 4, 0));
               }
               else
               {
                  A21PrecioFuncion = (short)(context.localUtil.CToN( cgiGet( edtPrecioFuncion_Internalname), ",", "."));
                  AssignAttri("", false, "A21PrecioFuncion", StringUtil.LTrimStr( (decimal)(A21PrecioFuncion), 4, 0));
               }
               A22FuncionName = cgiGet( edtFuncionName_Internalname);
               AssignAttri("", false, "A22FuncionName", A22FuncionName);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Funcion");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A15FuncionId != Z15FuncionId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("funcion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A15FuncionId = (short)(NumberUtil.Val( GetPar( "FuncionId"), "."));
                  AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
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
                     sMode7 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode7;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound7 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_070( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "FUNCIONID");
                        AnyError = 1;
                        GX_FocusControl = edtFuncionId_Internalname;
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
                           E11072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12072 ();
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
            E12072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll077( ) ;
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
            DisableAttributes077( ) ;
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
               CloseExtendedTableCursors077( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption070( )
      {
      }

      protected void E11072( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_EspectaculoId = 0;
         AssignAttri("", false, "AV11Insert_EspectaculoId", StringUtil.LTrimStr( (decimal)(AV11Insert_EspectaculoId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV13Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV14GXV1 = 1;
            AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            while ( AV14GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV14GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "EspectaculoId") == 0 )
               {
                  AV11Insert_EspectaculoId = (short)(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_EspectaculoId", StringUtil.LTrimStr( (decimal)(AV11Insert_EspectaculoId), 4, 0));
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

      protected void E12072( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwfuncion.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM077( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z21PrecioFuncion = T00073_A21PrecioFuncion[0];
               Z22FuncionName = T00073_A22FuncionName[0];
               Z1EspectaculoId = T00073_A1EspectaculoId[0];
            }
            else
            {
               Z21PrecioFuncion = A21PrecioFuncion;
               Z22FuncionName = A22FuncionName;
               Z1EspectaculoId = A1EspectaculoId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z15FuncionId = A15FuncionId;
            Z21PrecioFuncion = A21PrecioFuncion;
            Z22FuncionName = A22FuncionName;
            Z1EspectaculoId = A1EspectaculoId;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ESPECTACULOID"+"'), id:'"+"ESPECTACULOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7FuncionId) )
         {
            A15FuncionId = AV7FuncionId;
            AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
         }
         if ( ! (0==AV7FuncionId) )
         {
            edtFuncionId_Enabled = 0;
            AssignProp("", false, edtFuncionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFuncionId_Enabled), 5, 0), true);
         }
         else
         {
            edtFuncionId_Enabled = 1;
            AssignProp("", false, edtFuncionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFuncionId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7FuncionId) )
         {
            edtFuncionId_Enabled = 0;
            AssignProp("", false, edtFuncionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFuncionId_Enabled), 5, 0), true);
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
      }

      protected void standaloneModal( )
      {
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
            AV13Pgmname = "Funcion";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         }
      }

      protected void Load077( )
      {
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {A15FuncionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound7 = 1;
            A21PrecioFuncion = T00075_A21PrecioFuncion[0];
            AssignAttri("", false, "A21PrecioFuncion", StringUtil.LTrimStr( (decimal)(A21PrecioFuncion), 4, 0));
            A22FuncionName = T00075_A22FuncionName[0];
            AssignAttri("", false, "A22FuncionName", A22FuncionName);
            A1EspectaculoId = T00075_A1EspectaculoId[0];
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            ZM077( -9) ;
         }
         pr_default.close(3);
         OnLoadActions077( ) ;
      }

      protected void OnLoadActions077( )
      {
         AV13Pgmname = "Funcion";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable077( )
      {
         nIsDirty_7 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV13Pgmname = "Funcion";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors077( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_10( short A1EspectaculoId )
      {
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey077( )
      {
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {A15FuncionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A15FuncionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM077( 9) ;
            RcdFound7 = 1;
            A15FuncionId = T00073_A15FuncionId[0];
            AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
            A21PrecioFuncion = T00073_A21PrecioFuncion[0];
            AssignAttri("", false, "A21PrecioFuncion", StringUtil.LTrimStr( (decimal)(A21PrecioFuncion), 4, 0));
            A22FuncionName = T00073_A22FuncionName[0];
            AssignAttri("", false, "A22FuncionName", A22FuncionName);
            A1EspectaculoId = T00073_A1EspectaculoId[0];
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            Z15FuncionId = A15FuncionId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load077( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey077( ) ;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey077( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey077( ) ;
         if ( RcdFound7 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound7 = 0;
         /* Using cursor T00078 */
         pr_default.execute(6, new Object[] {A15FuncionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00078_A15FuncionId[0] < A15FuncionId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00078_A15FuncionId[0] > A15FuncionId ) ) )
            {
               A15FuncionId = T00078_A15FuncionId[0];
               AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound7 = 0;
         /* Using cursor T00079 */
         pr_default.execute(7, new Object[] {A15FuncionId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00079_A15FuncionId[0] > A15FuncionId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00079_A15FuncionId[0] < A15FuncionId ) ) )
            {
               A15FuncionId = T00079_A15FuncionId[0];
               AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey077( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtFuncionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert077( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A15FuncionId != Z15FuncionId )
               {
                  A15FuncionId = Z15FuncionId;
                  AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FUNCIONID");
                  AnyError = 1;
                  GX_FocusControl = edtFuncionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFuncionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update077( ) ;
                  GX_FocusControl = edtFuncionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A15FuncionId != Z15FuncionId )
               {
                  /* Insert record */
                  GX_FocusControl = edtFuncionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert077( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FUNCIONID");
                     AnyError = 1;
                     GX_FocusControl = edtFuncionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtFuncionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert077( ) ;
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
         if ( A15FuncionId != Z15FuncionId )
         {
            A15FuncionId = Z15FuncionId;
            AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FUNCIONID");
            AnyError = 1;
            GX_FocusControl = edtFuncionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFuncionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency077( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A15FuncionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Funcion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z21PrecioFuncion != T00072_A21PrecioFuncion[0] ) || ( StringUtil.StrCmp(Z22FuncionName, T00072_A22FuncionName[0]) != 0 ) || ( Z1EspectaculoId != T00072_A1EspectaculoId[0] ) )
            {
               if ( Z21PrecioFuncion != T00072_A21PrecioFuncion[0] )
               {
                  GXUtil.WriteLog("funcion:[seudo value changed for attri]"+"PrecioFuncion");
                  GXUtil.WriteLogRaw("Old: ",Z21PrecioFuncion);
                  GXUtil.WriteLogRaw("Current: ",T00072_A21PrecioFuncion[0]);
               }
               if ( StringUtil.StrCmp(Z22FuncionName, T00072_A22FuncionName[0]) != 0 )
               {
                  GXUtil.WriteLog("funcion:[seudo value changed for attri]"+"FuncionName");
                  GXUtil.WriteLogRaw("Old: ",Z22FuncionName);
                  GXUtil.WriteLogRaw("Current: ",T00072_A22FuncionName[0]);
               }
               if ( Z1EspectaculoId != T00072_A1EspectaculoId[0] )
               {
                  GXUtil.WriteLog("funcion:[seudo value changed for attri]"+"EspectaculoId");
                  GXUtil.WriteLogRaw("Old: ",Z1EspectaculoId);
                  GXUtil.WriteLogRaw("Current: ",T00072_A1EspectaculoId[0]);
               }
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
                     /* Using cursor T000710 */
                     pr_default.execute(8, new Object[] {A15FuncionId, A21PrecioFuncion, A22FuncionName, A1EspectaculoId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Funcion");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption070( ) ;
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
                     /* Using cursor T000711 */
                     pr_default.execute(9, new Object[] {A21PrecioFuncion, A22FuncionName, A1EspectaculoId, A15FuncionId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Funcion");
                     if ( (pr_default.getStatus(9) == 103) )
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
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void DeferredUpdate077( )
      {
      }

      protected void delete( )
      {
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
                  /* Using cursor T000712 */
                  pr_default.execute(10, new Object[] {A15FuncionId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("Funcion");
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel077( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls077( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "Funcion";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000713 */
            pr_default.execute(11, new Object[] {A15FuncionId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Entrada"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
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
            pr_default.close(1);
            context.CommitDataStores("funcion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("funcion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart077( )
      {
         /* Scan By routine */
         /* Using cursor T000714 */
         pr_default.execute(12);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound7 = 1;
            A15FuncionId = T000714_A15FuncionId[0];
            AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext077( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound7 = 1;
            A15FuncionId = T000714_A15FuncionId[0];
            AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
         }
      }

      protected void ScanEnd077( )
      {
         pr_default.close(12);
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
         edtFuncionId_Enabled = 0;
         AssignProp("", false, edtFuncionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFuncionId_Enabled), 5, 0), true);
         edtEspectaculoId_Enabled = 0;
         AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         edtPrecioFuncion_Enabled = 0;
         AssignProp("", false, edtPrecioFuncion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrecioFuncion_Enabled), 5, 0), true);
         edtFuncionName_Enabled = 0;
         AssignProp("", false, edtFuncionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFuncionName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes077( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues070( )
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
         context.AddJavascriptSource("gxcfg.js", "?2022882235470", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("funcion.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7FuncionId,4,0))}, new string[] {"Gx_mode","FuncionId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Funcion");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("funcion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z15FuncionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15FuncionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z21PrecioFuncion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z21PrecioFuncion), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z22FuncionName", StringUtil.RTrim( Z22FuncionName));
         GxWebStd.gx_hidden_field( context, "Z1EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N1EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vFUNCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7FuncionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFUNCIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7FuncionId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_ESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_EspectaculoId), 4, 0, ",", "")));
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
         return formatLink("funcion.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7FuncionId,4,0))}, new string[] {"Gx_mode","FuncionId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Funcion" ;
      }

      public override string GetPgmdesc( )
      {
         return "Funcion" ;
      }

      protected void InitializeNonKey077( )
      {
         A1EspectaculoId = 0;
         AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         A21PrecioFuncion = 0;
         AssignAttri("", false, "A21PrecioFuncion", StringUtil.LTrimStr( (decimal)(A21PrecioFuncion), 4, 0));
         A22FuncionName = "";
         AssignAttri("", false, "A22FuncionName", A22FuncionName);
         Z21PrecioFuncion = 0;
         Z22FuncionName = "";
         Z1EspectaculoId = 0;
      }

      protected void InitAll077( )
      {
         A15FuncionId = 0;
         AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
         InitializeNonKey077( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2022882235474", true, true);
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
         context.AddJavascriptSource("funcion.js", "?2022882235474", false, true);
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
         edtFuncionId_Internalname = "FUNCIONID";
         edtEspectaculoId_Internalname = "ESPECTACULOID";
         edtPrecioFuncion_Internalname = "PRECIOFUNCION";
         edtFuncionName_Internalname = "FUNCIONNAME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_1_Internalname = "PROMPT_1";
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
         Form.Caption = "Funcion";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtFuncionName_Jsonclick = "";
         edtFuncionName_Enabled = 1;
         edtPrecioFuncion_Jsonclick = "";
         edtPrecioFuncion_Enabled = 1;
         imgprompt_1_Visible = 1;
         imgprompt_1_Link = "";
         edtEspectaculoId_Jsonclick = "";
         edtEspectaculoId_Enabled = 1;
         edtFuncionId_Jsonclick = "";
         edtFuncionId_Enabled = 1;
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
         /* Using cursor T000715 */
         pr_default.execute(13, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7FuncionId',fld:'vFUNCIONID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7FuncionId',fld:'vFUNCIONID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12072',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_FUNCIONID","{handler:'Valid_Funcionid',iparms:[]");
         setEventMetadata("VALID_FUNCIONID",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOID","{handler:'Valid_Espectaculoid',iparms:[{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_ESPECTACULOID",",oparms:[]}");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z22FuncionName = "";
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
         A22FuncionName = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV13Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode7 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new SdtTransactionContext_Attribute(context);
         T00075_A15FuncionId = new short[1] ;
         T00075_A21PrecioFuncion = new short[1] ;
         T00075_A22FuncionName = new string[] {""} ;
         T00075_A1EspectaculoId = new short[1] ;
         T00074_A1EspectaculoId = new short[1] ;
         T00076_A1EspectaculoId = new short[1] ;
         T00077_A15FuncionId = new short[1] ;
         T00073_A15FuncionId = new short[1] ;
         T00073_A21PrecioFuncion = new short[1] ;
         T00073_A22FuncionName = new string[] {""} ;
         T00073_A1EspectaculoId = new short[1] ;
         T00078_A15FuncionId = new short[1] ;
         T00079_A15FuncionId = new short[1] ;
         T00072_A15FuncionId = new short[1] ;
         T00072_A21PrecioFuncion = new short[1] ;
         T00072_A22FuncionName = new string[] {""} ;
         T00072_A1EspectaculoId = new short[1] ;
         T000713_A23EntradaId = new short[1] ;
         T000714_A15FuncionId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000715_A1EspectaculoId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.funcion__default(),
            new Object[][] {
                new Object[] {
               T00072_A15FuncionId, T00072_A21PrecioFuncion, T00072_A22FuncionName, T00072_A1EspectaculoId
               }
               , new Object[] {
               T00073_A15FuncionId, T00073_A21PrecioFuncion, T00073_A22FuncionName, T00073_A1EspectaculoId
               }
               , new Object[] {
               T00074_A1EspectaculoId
               }
               , new Object[] {
               T00075_A15FuncionId, T00075_A21PrecioFuncion, T00075_A22FuncionName, T00075_A1EspectaculoId
               }
               , new Object[] {
               T00076_A1EspectaculoId
               }
               , new Object[] {
               T00077_A15FuncionId
               }
               , new Object[] {
               T00078_A15FuncionId
               }
               , new Object[] {
               T00079_A15FuncionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000713_A23EntradaId
               }
               , new Object[] {
               T000714_A15FuncionId
               }
               , new Object[] {
               T000715_A1EspectaculoId
               }
            }
         );
         AV13Pgmname = "Funcion";
      }

      private short wcpOAV7FuncionId ;
      private short Z15FuncionId ;
      private short Z21PrecioFuncion ;
      private short Z1EspectaculoId ;
      private short N1EspectaculoId ;
      private short GxWebError ;
      private short A1EspectaculoId ;
      private short AV7FuncionId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A15FuncionId ;
      private short A21PrecioFuncion ;
      private short AV11Insert_EspectaculoId ;
      private short RcdFound7 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_7 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtFuncionId_Enabled ;
      private int edtEspectaculoId_Enabled ;
      private int imgprompt_1_Visible ;
      private int edtPrecioFuncion_Enabled ;
      private int edtFuncionName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV14GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z22FuncionName ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtFuncionId_Internalname ;
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
      private string edtFuncionId_Jsonclick ;
      private string edtEspectaculoId_Internalname ;
      private string edtEspectaculoId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_1_Internalname ;
      private string imgprompt_1_Link ;
      private string edtPrecioFuncion_Internalname ;
      private string edtPrecioFuncion_Jsonclick ;
      private string edtFuncionName_Internalname ;
      private string A22FuncionName ;
      private string edtFuncionName_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV13Pgmname ;
      private string hsh ;
      private string sMode7 ;
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
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00075_A15FuncionId ;
      private short[] T00075_A21PrecioFuncion ;
      private string[] T00075_A22FuncionName ;
      private short[] T00075_A1EspectaculoId ;
      private short[] T00074_A1EspectaculoId ;
      private short[] T00076_A1EspectaculoId ;
      private short[] T00077_A15FuncionId ;
      private short[] T00073_A15FuncionId ;
      private short[] T00073_A21PrecioFuncion ;
      private string[] T00073_A22FuncionName ;
      private short[] T00073_A1EspectaculoId ;
      private short[] T00078_A15FuncionId ;
      private short[] T00079_A15FuncionId ;
      private short[] T00072_A15FuncionId ;
      private short[] T00072_A21PrecioFuncion ;
      private string[] T00072_A22FuncionName ;
      private short[] T00072_A1EspectaculoId ;
      private short[] T000713_A23EntradaId ;
      private short[] T000714_A15FuncionId ;
      private short[] T000715_A1EspectaculoId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class funcion__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00075;
          prmT00075 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmT00074;
          prmT00074 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00076;
          prmT00076 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT00077;
          prmT00077 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmT00073;
          prmT00073 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmT00078;
          prmT00078 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmT00079;
          prmT00079 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmT00072;
          prmT00072 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmT000710;
          prmT000710 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0) ,
          new ParDef("@PrecioFuncion",GXType.Int16,4,0) ,
          new ParDef("@FuncionName",GXType.NChar,20,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000711;
          prmT000711 = new Object[] {
          new ParDef("@PrecioFuncion",GXType.Int16,4,0) ,
          new ParDef("@FuncionName",GXType.NChar,20,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmT000712;
          prmT000712 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmT000713;
          prmT000713 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmT000714;
          prmT000714 = new Object[] {
          };
          Object[] prmT000715;
          prmT000715 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00072", "SELECT [FuncionId], [PrecioFuncion], [FuncionName], [EspectaculoId] FROM [Funcion] WITH (UPDLOCK) WHERE [FuncionId] = @FuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00073", "SELECT [FuncionId], [PrecioFuncion], [FuncionName], [EspectaculoId] FROM [Funcion] WHERE [FuncionId] = @FuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00074", "SELECT [EspectaculoId] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00075", "SELECT TM1.[FuncionId], TM1.[PrecioFuncion], TM1.[FuncionName], TM1.[EspectaculoId] FROM [Funcion] TM1 WHERE TM1.[FuncionId] = @FuncionId ORDER BY TM1.[FuncionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00076", "SELECT [EspectaculoId] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00077", "SELECT [FuncionId] FROM [Funcion] WHERE [FuncionId] = @FuncionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00078", "SELECT TOP 1 [FuncionId] FROM [Funcion] WHERE ( [FuncionId] > @FuncionId) ORDER BY [FuncionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00078,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00079", "SELECT TOP 1 [FuncionId] FROM [Funcion] WHERE ( [FuncionId] < @FuncionId) ORDER BY [FuncionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000710", "INSERT INTO [Funcion]([FuncionId], [PrecioFuncion], [FuncionName], [EspectaculoId]) VALUES(@FuncionId, @PrecioFuncion, @FuncionName, @EspectaculoId)", GxErrorMask.GX_NOMASK,prmT000710)
             ,new CursorDef("T000711", "UPDATE [Funcion] SET [PrecioFuncion]=@PrecioFuncion, [FuncionName]=@FuncionName, [EspectaculoId]=@EspectaculoId  WHERE [FuncionId] = @FuncionId", GxErrorMask.GX_NOMASK,prmT000711)
             ,new CursorDef("T000712", "DELETE FROM [Funcion]  WHERE [FuncionId] = @FuncionId", GxErrorMask.GX_NOMASK,prmT000712)
             ,new CursorDef("T000713", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE [FuncionId] = @FuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000713,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000714", "SELECT [FuncionId] FROM [Funcion] ORDER BY [FuncionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000714,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000715", "SELECT [EspectaculoId] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000715,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
