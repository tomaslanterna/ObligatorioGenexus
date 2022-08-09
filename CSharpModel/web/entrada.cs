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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A9ClienteId = (short)(NumberUtil.Val( GetPar( "ClienteId"), "."));
            AssignAttri("", false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A9ClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A3PaisId = (short)(NumberUtil.Val( GetPar( "PaisId"), "."));
            AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A3PaisId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A15FuncionId = (short)(NumberUtil.Val( GetPar( "FuncionId"), "."));
            AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A15FuncionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A1EspectaculoId = (short)(NumberUtil.Val( GetPar( "EspectaculoId"), "."));
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A1EspectaculoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A4LugarId = (short)(NumberUtil.Val( GetPar( "LugarId"), "."));
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A4LugarId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A4LugarId = (short)(NumberUtil.Val( GetPar( "LugarId"), "."));
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            A27LugarSectorId = (short)(NumberUtil.Val( GetPar( "LugarSectorId"), "."));
            n27LugarSectorId = false;
            AssignAttri("", false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A4LugarId, A27LugarSectorId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A7TipoEspectaculoId = (short)(NumberUtil.Val( GetPar( "TipoEspectaculoId"), "."));
            AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A7TipoEspectaculoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
         {
            A1EspectaculoId = (short)(NumberUtil.Val( GetPar( "EspectaculoId"), "."));
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            A27LugarSectorId = (short)(NumberUtil.Val( GetPar( "LugarSectorId"), "."));
            n27LugarSectorId = false;
            AssignAttri("", false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_21( A1EspectaculoId, A27LugarSectorId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A27LugarSectorId = (short)(NumberUtil.Val( GetPar( "LugarSectorId"), "."));
            n27LugarSectorId = false;
            AssignAttri("", false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
            A1EspectaculoId = (short)(NumberUtil.Val( GetPar( "EspectaculoId"), "."));
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A27LugarSectorId, A1EspectaculoId) ;
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
            GX_FocusControl = edtEntradaFecha_Internalname;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEntradaFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEntradaFecha_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtEntradaFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtEntradaFecha_Internalname, context.localUtil.Format(A42EntradaFecha, "99/99/99"), context.localUtil.Format( A42EntradaFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntradaFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEntradaFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Entrada.htm");
         GxWebStd.gx_bitmap( context, edtEntradaFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEntradaFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Entrada.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9ClienteId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A9ClienteId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Entrada.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoId_Internalname, "Espectaculo Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9") : context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Entrada.htm");
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
         GxWebStd.gx_single_line_edit( context, edtEspectaculoName_Internalname, A2EspectaculoName, StringUtil.RTrim( context.localUtil.Format( A2EspectaculoName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoFecha_Internalname, "Espectaculo Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtEspectaculoFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtEspectaculoFecha_Internalname, context.localUtil.Format(A16EspectaculoFecha, "99/99/99"), context.localUtil.Format( A16EspectaculoFecha, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Entrada.htm");
         GxWebStd.gx_bitmap( context, edtEspectaculoFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEspectaculoFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Entrada.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFuncionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15FuncionId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A15FuncionId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFuncionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFuncionId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Entrada.htm");
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
         GxWebStd.gx_single_line_edit( context, edtFuncionName_Internalname, A22FuncionName, StringUtil.RTrim( context.localUtil.Format( A22FuncionName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFuncionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFuncionName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Entrada.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarSectorId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLugarSectorId_Internalname, "Sector Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLugarSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A27LugarSectorId), 4, 0, ",", "")), StringUtil.LTrim( ((edtLugarSectorId_Enabled!=0) ? context.localUtil.Format( (decimal)(A27LugarSectorId), "ZZZ9") : context.localUtil.Format( (decimal)(A27LugarSectorId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarSectorId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarSectorId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarSectorName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLugarSectorName_Internalname, "Lugar Sector Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLugarSectorName_Internalname, A28LugarSectorName, StringUtil.RTrim( context.localUtil.Format( A28LugarSectorName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarSectorName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarSectorName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarSectorPrecio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLugarSectorPrecio_Internalname, "Lugar Sector Precio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLugarSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ",", "")), StringUtil.LTrim( ((edtLugarSectorPrecio_Enabled!=0) ? context.localUtil.Format( (decimal)(A30LugarSectorPrecio), "ZZZ9") : context.localUtil.Format( (decimal)(A30LugarSectorPrecio), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarSectorPrecio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarSectorPrecio_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarSectorDisponibles_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLugarSectorDisponibles_Internalname, "Lugar Sector Disponibles", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLugarSectorDisponibles_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A38LugarSectorDisponibles), 4, 0, ",", "")), StringUtil.LTrim( ((edtLugarSectorDisponibles_Enabled!=0) ? context.localUtil.Format( (decimal)(A38LugarSectorDisponibles), "ZZZ9") : context.localUtil.Format( (decimal)(A38LugarSectorDisponibles), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarSectorDisponibles_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarSectorDisponibles_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Entrada.htm");
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
         GxWebStd.gx_single_line_edit( context, edtTipoEspectaculoName_Internalname, A8TipoEspectaculoName, StringUtil.RTrim( context.localUtil.Format( A8TipoEspectaculoName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoEspectaculoName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipoEspectaculoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEntradaPaisOrigenId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEntradaPaisOrigenId_Internalname, "Origen Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEntradaPaisOrigenId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A43EntradaPaisOrigenId), 4, 0, ",", "")), StringUtil.LTrim( ((edtEntradaPaisOrigenId_Enabled!=0) ? context.localUtil.Format( (decimal)(A43EntradaPaisOrigenId), "ZZZ9") : context.localUtil.Format( (decimal)(A43EntradaPaisOrigenId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,114);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntradaPaisOrigenId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEntradaPaisOrigenId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEntradaPaisOrigenName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEntradaPaisOrigenName_Internalname, "Origen Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEntradaPaisOrigenName_Internalname, A44EntradaPaisOrigenName, StringUtil.RTrim( context.localUtil.Format( A44EntradaPaisOrigenName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,119);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntradaPaisOrigenName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEntradaPaisOrigenName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Entrada.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Entrada.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
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
               Z42EntradaFecha = context.localUtil.CToD( cgiGet( "Z42EntradaFecha"), 0);
               Z43EntradaPaisOrigenId = (short)(context.localUtil.CToN( cgiGet( "Z43EntradaPaisOrigenId"), ",", "."));
               Z44EntradaPaisOrigenName = cgiGet( "Z44EntradaPaisOrigenName");
               Z9ClienteId = (short)(context.localUtil.CToN( cgiGet( "Z9ClienteId"), ",", "."));
               Z15FuncionId = (short)(context.localUtil.CToN( cgiGet( "Z15FuncionId"), ",", "."));
               Z27LugarSectorId = (short)(context.localUtil.CToN( cgiGet( "Z27LugarSectorId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               N9ClienteId = (short)(context.localUtil.CToN( cgiGet( "N9ClienteId"), ",", "."));
               N15FuncionId = (short)(context.localUtil.CToN( cgiGet( "N15FuncionId"), ",", "."));
               A40LugarSectorCantidadAsientos = (short)(context.localUtil.CToN( cgiGet( "LUGARSECTORCANTIDADASIENTOS"), ",", "."));
               A37LugarSectorVendidas = (short)(context.localUtil.CToN( cgiGet( "LUGARSECTORVENDIDAS"), ",", "."));
               n37LugarSectorVendidas = false;
               AV7EntradaId = (short)(context.localUtil.CToN( cgiGet( "vENTRADAID"), ",", "."));
               AV11Insert_ClienteId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTEID"), ",", "."));
               AV12Insert_FuncionId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_FUNCIONID"), ",", "."));
               A3PaisId = (short)(context.localUtil.CToN( cgiGet( "PAISID"), ",", "."));
               A4LugarId = (short)(context.localUtil.CToN( cgiGet( "LUGARID"), ",", "."));
               A7TipoEspectaculoId = (short)(context.localUtil.CToN( cgiGet( "TIPOESPECTACULOID"), ",", "."));
               AV14Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A23EntradaId = (short)(context.localUtil.CToN( cgiGet( edtEntradaId_Internalname), ",", "."));
               AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
               if ( context.localUtil.VCDate( cgiGet( edtEntradaFecha_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Entrada Fecha"}), 1, "ENTRADAFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtEntradaFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A42EntradaFecha = DateTime.MinValue;
                  AssignAttri("", false, "A42EntradaFecha", context.localUtil.Format(A42EntradaFecha, "99/99/99"));
               }
               else
               {
                  A42EntradaFecha = context.localUtil.CToD( cgiGet( edtEntradaFecha_Internalname), 2);
                  AssignAttri("", false, "A42EntradaFecha", context.localUtil.Format(A42EntradaFecha, "99/99/99"));
               }
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
               A1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."));
               AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
               A2EspectaculoName = cgiGet( edtEspectaculoName_Internalname);
               AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
               A16EspectaculoFecha = context.localUtil.CToD( cgiGet( edtEspectaculoFecha_Internalname), 2);
               AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
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
               if ( ( ( context.localUtil.CToN( cgiGet( edtLugarSectorId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLugarSectorId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LUGARSECTORID");
                  AnyError = 1;
                  GX_FocusControl = edtLugarSectorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A27LugarSectorId = 0;
                  n27LugarSectorId = false;
                  AssignAttri("", false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
               }
               else
               {
                  A27LugarSectorId = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorId_Internalname), ",", "."));
                  n27LugarSectorId = false;
                  AssignAttri("", false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
               }
               A28LugarSectorName = cgiGet( edtLugarSectorName_Internalname);
               AssignAttri("", false, "A28LugarSectorName", A28LugarSectorName);
               A30LugarSectorPrecio = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorPrecio_Internalname), ",", "."));
               AssignAttri("", false, "A30LugarSectorPrecio", StringUtil.LTrimStr( (decimal)(A30LugarSectorPrecio), 4, 0));
               A38LugarSectorDisponibles = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorDisponibles_Internalname), ",", "."));
               AssignAttri("", false, "A38LugarSectorDisponibles", StringUtil.LTrimStr( (decimal)(A38LugarSectorDisponibles), 4, 0));
               A8TipoEspectaculoName = cgiGet( edtTipoEspectaculoName_Internalname);
               AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEntradaPaisOrigenId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEntradaPaisOrigenId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ENTRADAPAISORIGENID");
                  AnyError = 1;
                  GX_FocusControl = edtEntradaPaisOrigenId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A43EntradaPaisOrigenId = 0;
                  AssignAttri("", false, "A43EntradaPaisOrigenId", StringUtil.LTrimStr( (decimal)(A43EntradaPaisOrigenId), 4, 0));
               }
               else
               {
                  A43EntradaPaisOrigenId = (short)(context.localUtil.CToN( cgiGet( edtEntradaPaisOrigenId_Internalname), ",", "."));
                  AssignAttri("", false, "A43EntradaPaisOrigenId", StringUtil.LTrimStr( (decimal)(A43EntradaPaisOrigenId), 4, 0));
               }
               A44EntradaPaisOrigenName = cgiGet( edtEntradaPaisOrigenName_Internalname);
               AssignAttri("", false, "A44EntradaPaisOrigenName", A44EntradaPaisOrigenName);
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
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z42EntradaFecha = T00083_A42EntradaFecha[0];
               Z43EntradaPaisOrigenId = T00083_A43EntradaPaisOrigenId[0];
               Z44EntradaPaisOrigenName = T00083_A44EntradaPaisOrigenName[0];
               Z9ClienteId = T00083_A9ClienteId[0];
               Z15FuncionId = T00083_A15FuncionId[0];
               Z27LugarSectorId = T00083_A27LugarSectorId[0];
            }
            else
            {
               Z42EntradaFecha = A42EntradaFecha;
               Z43EntradaPaisOrigenId = A43EntradaPaisOrigenId;
               Z44EntradaPaisOrigenName = A44EntradaPaisOrigenName;
               Z9ClienteId = A9ClienteId;
               Z15FuncionId = A15FuncionId;
               Z27LugarSectorId = A27LugarSectorId;
            }
         }
         if ( GX_JID == -13 )
         {
            Z23EntradaId = A23EntradaId;
            Z42EntradaFecha = A42EntradaFecha;
            Z43EntradaPaisOrigenId = A43EntradaPaisOrigenId;
            Z44EntradaPaisOrigenName = A44EntradaPaisOrigenName;
            Z9ClienteId = A9ClienteId;
            Z15FuncionId = A15FuncionId;
            Z27LugarSectorId = A27LugarSectorId;
            Z3PaisId = A3PaisId;
            Z10ClienteName = A10ClienteName;
            Z6PaisName = A6PaisName;
            Z22FuncionName = A22FuncionName;
            Z1EspectaculoId = A1EspectaculoId;
            Z4LugarId = A4LugarId;
            Z7TipoEspectaculoId = A7TipoEspectaculoId;
            Z2EspectaculoName = A2EspectaculoName;
            Z16EspectaculoFecha = A16EspectaculoFecha;
            Z5LugarName = A5LugarName;
            Z8TipoEspectaculoName = A8TipoEspectaculoName;
            Z28LugarSectorName = A28LugarSectorName;
            Z30LugarSectorPrecio = A30LugarSectorPrecio;
            Z40LugarSectorCantidadAsientos = A40LugarSectorCantidadAsientos;
            Z37LugarSectorVendidas = A37LugarSectorVendidas;
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
            A22FuncionName = T00085_A22FuncionName[0];
            AssignAttri("", false, "A22FuncionName", A22FuncionName);
            A1EspectaculoId = T00085_A1EspectaculoId[0];
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            pr_default.close(3);
            /* Using cursor T00087 */
            pr_default.execute(5, new Object[] {A1EspectaculoId});
            A4LugarId = T00087_A4LugarId[0];
            A7TipoEspectaculoId = T00087_A7TipoEspectaculoId[0];
            A2EspectaculoName = T00087_A2EspectaculoName[0];
            AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
            A16EspectaculoFecha = T00087_A16EspectaculoFecha[0];
            AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
            pr_default.close(5);
            /* Using cursor T00088 */
            pr_default.execute(6, new Object[] {A4LugarId});
            A5LugarName = T00088_A5LugarName[0];
            AssignAttri("", false, "A5LugarName", A5LugarName);
            pr_default.close(6);
            /* Using cursor T00089 */
            pr_default.execute(7, new Object[] {A7TipoEspectaculoId});
            A8TipoEspectaculoName = T00089_A8TipoEspectaculoName[0];
            AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            pr_default.close(7);
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
         /* Using cursor T000815 */
         pr_default.execute(11, new Object[] {A23EntradaId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound9 = 1;
            A3PaisId = T000815_A3PaisId[0];
            A4LugarId = T000815_A4LugarId[0];
            A7TipoEspectaculoId = T000815_A7TipoEspectaculoId[0];
            A42EntradaFecha = T000815_A42EntradaFecha[0];
            AssignAttri("", false, "A42EntradaFecha", context.localUtil.Format(A42EntradaFecha, "99/99/99"));
            A10ClienteName = T000815_A10ClienteName[0];
            AssignAttri("", false, "A10ClienteName", A10ClienteName);
            A2EspectaculoName = T000815_A2EspectaculoName[0];
            AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
            A16EspectaculoFecha = T000815_A16EspectaculoFecha[0];
            AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
            A22FuncionName = T000815_A22FuncionName[0];
            AssignAttri("", false, "A22FuncionName", A22FuncionName);
            A6PaisName = T000815_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            A5LugarName = T000815_A5LugarName[0];
            AssignAttri("", false, "A5LugarName", A5LugarName);
            A28LugarSectorName = T000815_A28LugarSectorName[0];
            AssignAttri("", false, "A28LugarSectorName", A28LugarSectorName);
            A30LugarSectorPrecio = T000815_A30LugarSectorPrecio[0];
            AssignAttri("", false, "A30LugarSectorPrecio", StringUtil.LTrimStr( (decimal)(A30LugarSectorPrecio), 4, 0));
            A8TipoEspectaculoName = T000815_A8TipoEspectaculoName[0];
            AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            A43EntradaPaisOrigenId = T000815_A43EntradaPaisOrigenId[0];
            AssignAttri("", false, "A43EntradaPaisOrigenId", StringUtil.LTrimStr( (decimal)(A43EntradaPaisOrigenId), 4, 0));
            A44EntradaPaisOrigenName = T000815_A44EntradaPaisOrigenName[0];
            AssignAttri("", false, "A44EntradaPaisOrigenName", A44EntradaPaisOrigenName);
            A40LugarSectorCantidadAsientos = T000815_A40LugarSectorCantidadAsientos[0];
            A9ClienteId = T000815_A9ClienteId[0];
            AssignAttri("", false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
            A15FuncionId = T000815_A15FuncionId[0];
            AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
            A1EspectaculoId = T000815_A1EspectaculoId[0];
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            A27LugarSectorId = T000815_A27LugarSectorId[0];
            n27LugarSectorId = T000815_n27LugarSectorId[0];
            AssignAttri("", false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
            A37LugarSectorVendidas = T000815_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = T000815_n37LugarSectorVendidas[0];
            ZM089( -13) ;
         }
         pr_default.close(11);
         OnLoadActions089( ) ;
      }

      protected void OnLoadActions089( )
      {
         AV14Pgmname = "Entrada";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         A38LugarSectorDisponibles = (short)(A40LugarSectorCantidadAsientos-A37LugarSectorVendidas);
         AssignAttri("", false, "A38LugarSectorDisponibles", StringUtil.LTrimStr( (decimal)(A38LugarSectorDisponibles), 4, 0));
      }

      protected void CheckExtendedTable089( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV14Pgmname = "Entrada";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         if ( ! ( (DateTime.MinValue==A42EntradaFecha) || ( DateTimeUtil.ResetTime ( A42EntradaFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Entrada Fecha fuera de rango", "OutOfRange", 1, "ENTRADAFECHA");
            AnyError = 1;
            GX_FocusControl = edtEntradaFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
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
         A22FuncionName = T00085_A22FuncionName[0];
         AssignAttri("", false, "A22FuncionName", A22FuncionName);
         A1EspectaculoId = T00085_A1EspectaculoId[0];
         AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         pr_default.close(3);
         /* Using cursor T00087 */
         pr_default.execute(5, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
         }
         A4LugarId = T00087_A4LugarId[0];
         A7TipoEspectaculoId = T00087_A7TipoEspectaculoId[0];
         A2EspectaculoName = T00087_A2EspectaculoName[0];
         AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
         A16EspectaculoFecha = T00087_A16EspectaculoFecha[0];
         AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
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
         /* Using cursor T000810 */
         pr_default.execute(8, new Object[] {A4LugarId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "LUGARSECTORID");
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A28LugarSectorName = T000810_A28LugarSectorName[0];
         AssignAttri("", false, "A28LugarSectorName", A28LugarSectorName);
         A30LugarSectorPrecio = T000810_A30LugarSectorPrecio[0];
         AssignAttri("", false, "A30LugarSectorPrecio", StringUtil.LTrimStr( (decimal)(A30LugarSectorPrecio), 4, 0));
         pr_default.close(8);
         /* Using cursor T00089 */
         pr_default.execute(7, new Object[] {A7TipoEspectaculoId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
         }
         A8TipoEspectaculoName = T00089_A8TipoEspectaculoName[0];
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
         pr_default.close(7);
         /* Using cursor T000811 */
         pr_default.execute(9, new Object[] {A1EspectaculoId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar Sector'.", "ForeignKeyNotFound", 1, "LUGARSECTORID");
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40LugarSectorCantidadAsientos = T000811_A40LugarSectorCantidadAsientos[0];
         pr_default.close(9);
         /* Using cursor T000813 */
         pr_default.execute(10, new Object[] {n27LugarSectorId, A27LugarSectorId, A1EspectaculoId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A37LugarSectorVendidas = T000813_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = T000813_n37LugarSectorVendidas[0];
         }
         else
         {
            nIsDirty_9 = 1;
            A37LugarSectorVendidas = 0;
            n37LugarSectorVendidas = false;
            AssignAttri("", false, "A37LugarSectorVendidas", StringUtil.LTrimStr( (decimal)(A37LugarSectorVendidas), 4, 0));
         }
         pr_default.close(10);
         nIsDirty_9 = 1;
         A38LugarSectorDisponibles = (short)(A40LugarSectorCantidadAsientos-A37LugarSectorVendidas);
         AssignAttri("", false, "A38LugarSectorDisponibles", StringUtil.LTrimStr( (decimal)(A38LugarSectorDisponibles), 4, 0));
      }

      protected void CloseExtendedTableCursors089( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(8);
         pr_default.close(7);
         pr_default.close(9);
         pr_default.close(10);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_14( short A9ClienteId )
      {
         /* Using cursor T000816 */
         pr_default.execute(12, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A3PaisId = T000816_A3PaisId[0];
         A10ClienteName = T000816_A10ClienteName[0];
         AssignAttri("", false, "A10ClienteName", A10ClienteName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A10ClienteName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_16( short A3PaisId )
      {
         /* Using cursor T000817 */
         pr_default.execute(13, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = T000817_A6PaisName[0];
         AssignAttri("", false, "A6PaisName", A6PaisName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A6PaisName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_15( short A15FuncionId )
      {
         /* Using cursor T000818 */
         pr_default.execute(14, new Object[] {A15FuncionId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Funcion'.", "ForeignKeyNotFound", 1, "FUNCIONID");
            AnyError = 1;
            GX_FocusControl = edtFuncionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A22FuncionName = T000818_A22FuncionName[0];
         AssignAttri("", false, "A22FuncionName", A22FuncionName);
         A1EspectaculoId = T000818_A1EspectaculoId[0];
         AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A22FuncionName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_17( short A1EspectaculoId )
      {
         /* Using cursor T000819 */
         pr_default.execute(15, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
         }
         A4LugarId = T000819_A4LugarId[0];
         A7TipoEspectaculoId = T000819_A7TipoEspectaculoId[0];
         A2EspectaculoName = T000819_A2EspectaculoName[0];
         AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
         A16EspectaculoFecha = T000819_A16EspectaculoFecha[0];
         AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A7TipoEspectaculoId), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A2EspectaculoName)+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A16EspectaculoFecha, "99/99/99"))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void gxLoad_18( short A4LugarId )
      {
         /* Using cursor T000820 */
         pr_default.execute(16, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
         }
         A5LugarName = T000820_A5LugarName[0];
         AssignAttri("", false, "A5LugarName", A5LugarName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A5LugarName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_20( short A4LugarId ,
                                short A27LugarSectorId )
      {
         /* Using cursor T000821 */
         pr_default.execute(17, new Object[] {A4LugarId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "LUGARSECTORID");
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A28LugarSectorName = T000821_A28LugarSectorName[0];
         AssignAttri("", false, "A28LugarSectorName", A28LugarSectorName);
         A30LugarSectorPrecio = T000821_A30LugarSectorPrecio[0];
         AssignAttri("", false, "A30LugarSectorPrecio", StringUtil.LTrimStr( (decimal)(A30LugarSectorPrecio), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A28LugarSectorName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_19( short A7TipoEspectaculoId )
      {
         /* Using cursor T000822 */
         pr_default.execute(18, new Object[] {A7TipoEspectaculoId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
         }
         A8TipoEspectaculoName = T000822_A8TipoEspectaculoName[0];
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A8TipoEspectaculoName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void gxLoad_21( short A1EspectaculoId ,
                                short A27LugarSectorId )
      {
         /* Using cursor T000823 */
         pr_default.execute(19, new Object[] {A1EspectaculoId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar Sector'.", "ForeignKeyNotFound", 1, "LUGARSECTORID");
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40LugarSectorCantidadAsientos = T000823_A40LugarSectorCantidadAsientos[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A40LugarSectorCantidadAsientos), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_22( short A27LugarSectorId ,
                                short A1EspectaculoId )
      {
         /* Using cursor T000825 */
         pr_default.execute(20, new Object[] {n27LugarSectorId, A27LugarSectorId, A1EspectaculoId});
         if ( (pr_default.getStatus(20) != 101) )
         {
            A37LugarSectorVendidas = T000825_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = T000825_n37LugarSectorVendidas[0];
         }
         else
         {
            A37LugarSectorVendidas = 0;
            n37LugarSectorVendidas = false;
            AssignAttri("", false, "A37LugarSectorVendidas", StringUtil.LTrimStr( (decimal)(A37LugarSectorVendidas), 4, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void GetKey089( )
      {
         /* Using cursor T000826 */
         pr_default.execute(21, new Object[] {A23EntradaId});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00083 */
         pr_default.execute(1, new Object[] {A23EntradaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM089( 13) ;
            RcdFound9 = 1;
            A23EntradaId = T00083_A23EntradaId[0];
            AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
            A42EntradaFecha = T00083_A42EntradaFecha[0];
            AssignAttri("", false, "A42EntradaFecha", context.localUtil.Format(A42EntradaFecha, "99/99/99"));
            A43EntradaPaisOrigenId = T00083_A43EntradaPaisOrigenId[0];
            AssignAttri("", false, "A43EntradaPaisOrigenId", StringUtil.LTrimStr( (decimal)(A43EntradaPaisOrigenId), 4, 0));
            A44EntradaPaisOrigenName = T00083_A44EntradaPaisOrigenName[0];
            AssignAttri("", false, "A44EntradaPaisOrigenName", A44EntradaPaisOrigenName);
            A9ClienteId = T00083_A9ClienteId[0];
            AssignAttri("", false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
            A15FuncionId = T00083_A15FuncionId[0];
            AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
            A27LugarSectorId = T00083_A27LugarSectorId[0];
            n27LugarSectorId = T00083_n27LugarSectorId[0];
            AssignAttri("", false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
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
         /* Using cursor T000827 */
         pr_default.execute(22, new Object[] {A23EntradaId});
         if ( (pr_default.getStatus(22) != 101) )
         {
            while ( (pr_default.getStatus(22) != 101) && ( ( T000827_A23EntradaId[0] < A23EntradaId ) ) )
            {
               pr_default.readNext(22);
            }
            if ( (pr_default.getStatus(22) != 101) && ( ( T000827_A23EntradaId[0] > A23EntradaId ) ) )
            {
               A23EntradaId = T000827_A23EntradaId[0];
               AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(22);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T000828 */
         pr_default.execute(23, new Object[] {A23EntradaId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            while ( (pr_default.getStatus(23) != 101) && ( ( T000828_A23EntradaId[0] > A23EntradaId ) ) )
            {
               pr_default.readNext(23);
            }
            if ( (pr_default.getStatus(23) != 101) && ( ( T000828_A23EntradaId[0] < A23EntradaId ) ) )
            {
               A23EntradaId = T000828_A23EntradaId[0];
               AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(23);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey089( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEntradaFecha_Internalname;
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
                  GX_FocusControl = edtEntradaFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update089( ) ;
                  GX_FocusControl = edtEntradaFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A23EntradaId != Z23EntradaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtEntradaFecha_Internalname;
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
                     GX_FocusControl = edtEntradaFecha_Internalname;
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
            GX_FocusControl = edtEntradaFecha_Internalname;
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
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z42EntradaFecha ) != DateTimeUtil.ResetTime ( T00082_A42EntradaFecha[0] ) ) || ( Z43EntradaPaisOrigenId != T00082_A43EntradaPaisOrigenId[0] ) || ( StringUtil.StrCmp(Z44EntradaPaisOrigenName, T00082_A44EntradaPaisOrigenName[0]) != 0 ) || ( Z9ClienteId != T00082_A9ClienteId[0] ) || ( Z15FuncionId != T00082_A15FuncionId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z27LugarSectorId != T00082_A27LugarSectorId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z42EntradaFecha ) != DateTimeUtil.ResetTime ( T00082_A42EntradaFecha[0] ) )
               {
                  GXUtil.WriteLog("entrada:[seudo value changed for attri]"+"EntradaFecha");
                  GXUtil.WriteLogRaw("Old: ",Z42EntradaFecha);
                  GXUtil.WriteLogRaw("Current: ",T00082_A42EntradaFecha[0]);
               }
               if ( Z43EntradaPaisOrigenId != T00082_A43EntradaPaisOrigenId[0] )
               {
                  GXUtil.WriteLog("entrada:[seudo value changed for attri]"+"EntradaPaisOrigenId");
                  GXUtil.WriteLogRaw("Old: ",Z43EntradaPaisOrigenId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A43EntradaPaisOrigenId[0]);
               }
               if ( StringUtil.StrCmp(Z44EntradaPaisOrigenName, T00082_A44EntradaPaisOrigenName[0]) != 0 )
               {
                  GXUtil.WriteLog("entrada:[seudo value changed for attri]"+"EntradaPaisOrigenName");
                  GXUtil.WriteLogRaw("Old: ",Z44EntradaPaisOrigenName);
                  GXUtil.WriteLogRaw("Current: ",T00082_A44EntradaPaisOrigenName[0]);
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
               if ( Z27LugarSectorId != T00082_A27LugarSectorId[0] )
               {
                  GXUtil.WriteLog("entrada:[seudo value changed for attri]"+"LugarSectorId");
                  GXUtil.WriteLogRaw("Old: ",Z27LugarSectorId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A27LugarSectorId[0]);
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
                     /* Using cursor T000829 */
                     pr_default.execute(24, new Object[] {A42EntradaFecha, A43EntradaPaisOrigenId, A44EntradaPaisOrigenName, A9ClienteId, A15FuncionId, n27LugarSectorId, A27LugarSectorId});
                     A23EntradaId = T000829_A23EntradaId[0];
                     AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
                     pr_default.close(24);
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
                     /* Using cursor T000830 */
                     pr_default.execute(25, new Object[] {A42EntradaFecha, A43EntradaPaisOrigenId, A44EntradaPaisOrigenName, A9ClienteId, A15FuncionId, n27LugarSectorId, A27LugarSectorId, A23EntradaId});
                     pr_default.close(25);
                     dsDefault.SmartCacheProvider.SetUpdated("Entrada");
                     if ( (pr_default.getStatus(25) == 103) )
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
                  /* Using cursor T000831 */
                  pr_default.execute(26, new Object[] {A23EntradaId});
                  pr_default.close(26);
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
            /* Using cursor T000832 */
            pr_default.execute(27, new Object[] {A9ClienteId});
            A3PaisId = T000832_A3PaisId[0];
            A10ClienteName = T000832_A10ClienteName[0];
            AssignAttri("", false, "A10ClienteName", A10ClienteName);
            pr_default.close(27);
            /* Using cursor T000833 */
            pr_default.execute(28, new Object[] {A3PaisId});
            A6PaisName = T000833_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            pr_default.close(28);
            /* Using cursor T000834 */
            pr_default.execute(29, new Object[] {A15FuncionId});
            A22FuncionName = T000834_A22FuncionName[0];
            AssignAttri("", false, "A22FuncionName", A22FuncionName);
            A1EspectaculoId = T000834_A1EspectaculoId[0];
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            pr_default.close(29);
            /* Using cursor T000835 */
            pr_default.execute(30, new Object[] {A1EspectaculoId});
            A4LugarId = T000835_A4LugarId[0];
            A7TipoEspectaculoId = T000835_A7TipoEspectaculoId[0];
            A2EspectaculoName = T000835_A2EspectaculoName[0];
            AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
            A16EspectaculoFecha = T000835_A16EspectaculoFecha[0];
            AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
            pr_default.close(30);
            /* Using cursor T000836 */
            pr_default.execute(31, new Object[] {A4LugarId});
            A5LugarName = T000836_A5LugarName[0];
            AssignAttri("", false, "A5LugarName", A5LugarName);
            pr_default.close(31);
            /* Using cursor T000837 */
            pr_default.execute(32, new Object[] {A7TipoEspectaculoId});
            A8TipoEspectaculoName = T000837_A8TipoEspectaculoName[0];
            AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            pr_default.close(32);
            /* Using cursor T000838 */
            pr_default.execute(33, new Object[] {A4LugarId, n27LugarSectorId, A27LugarSectorId});
            A28LugarSectorName = T000838_A28LugarSectorName[0];
            AssignAttri("", false, "A28LugarSectorName", A28LugarSectorName);
            A30LugarSectorPrecio = T000838_A30LugarSectorPrecio[0];
            AssignAttri("", false, "A30LugarSectorPrecio", StringUtil.LTrimStr( (decimal)(A30LugarSectorPrecio), 4, 0));
            pr_default.close(33);
            /* Using cursor T000839 */
            pr_default.execute(34, new Object[] {A1EspectaculoId, n27LugarSectorId, A27LugarSectorId});
            A40LugarSectorCantidadAsientos = T000839_A40LugarSectorCantidadAsientos[0];
            pr_default.close(34);
            /* Using cursor T000841 */
            pr_default.execute(35, new Object[] {n27LugarSectorId, A27LugarSectorId, A1EspectaculoId});
            if ( (pr_default.getStatus(35) != 101) )
            {
               A37LugarSectorVendidas = T000841_A37LugarSectorVendidas[0];
               n37LugarSectorVendidas = T000841_n37LugarSectorVendidas[0];
            }
            else
            {
               A37LugarSectorVendidas = 0;
               n37LugarSectorVendidas = false;
               AssignAttri("", false, "A37LugarSectorVendidas", StringUtil.LTrimStr( (decimal)(A37LugarSectorVendidas), 4, 0));
            }
            pr_default.close(35);
            A38LugarSectorDisponibles = (short)(A40LugarSectorCantidadAsientos-A37LugarSectorVendidas);
            AssignAttri("", false, "A38LugarSectorDisponibles", StringUtil.LTrimStr( (decimal)(A38LugarSectorDisponibles), 4, 0));
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
            pr_default.close(27);
            pr_default.close(29);
            pr_default.close(28);
            pr_default.close(30);
            pr_default.close(31);
            pr_default.close(32);
            pr_default.close(33);
            pr_default.close(34);
            pr_default.close(35);
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
            pr_default.close(27);
            pr_default.close(29);
            pr_default.close(28);
            pr_default.close(30);
            pr_default.close(31);
            pr_default.close(32);
            pr_default.close(33);
            pr_default.close(34);
            pr_default.close(35);
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
         /* Using cursor T000842 */
         pr_default.execute(36);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound9 = 1;
            A23EntradaId = T000842_A23EntradaId[0];
            AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext089( )
      {
         /* Scan next routine */
         pr_default.readNext(36);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound9 = 1;
            A23EntradaId = T000842_A23EntradaId[0];
            AssignAttri("", false, "A23EntradaId", StringUtil.LTrimStr( (decimal)(A23EntradaId), 4, 0));
         }
      }

      protected void ScanEnd089( )
      {
         pr_default.close(36);
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
         edtEntradaFecha_Enabled = 0;
         AssignProp("", false, edtEntradaFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntradaFecha_Enabled), 5, 0), true);
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         edtClienteName_Enabled = 0;
         AssignProp("", false, edtClienteName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteName_Enabled), 5, 0), true);
         edtEspectaculoId_Enabled = 0;
         AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         edtEspectaculoName_Enabled = 0;
         AssignProp("", false, edtEspectaculoName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoName_Enabled), 5, 0), true);
         edtEspectaculoFecha_Enabled = 0;
         AssignProp("", false, edtEspectaculoFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoFecha_Enabled), 5, 0), true);
         edtFuncionId_Enabled = 0;
         AssignProp("", false, edtFuncionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFuncionId_Enabled), 5, 0), true);
         edtFuncionName_Enabled = 0;
         AssignProp("", false, edtFuncionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFuncionName_Enabled), 5, 0), true);
         edtPaisName_Enabled = 0;
         AssignProp("", false, edtPaisName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisName_Enabled), 5, 0), true);
         edtLugarName_Enabled = 0;
         AssignProp("", false, edtLugarName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarName_Enabled), 5, 0), true);
         edtLugarSectorId_Enabled = 0;
         AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), true);
         edtLugarSectorName_Enabled = 0;
         AssignProp("", false, edtLugarSectorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorName_Enabled), 5, 0), true);
         edtLugarSectorPrecio_Enabled = 0;
         AssignProp("", false, edtLugarSectorPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0), true);
         edtLugarSectorDisponibles_Enabled = 0;
         AssignProp("", false, edtLugarSectorDisponibles_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorDisponibles_Enabled), 5, 0), true);
         edtTipoEspectaculoName_Enabled = 0;
         AssignProp("", false, edtTipoEspectaculoName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoName_Enabled), 5, 0), true);
         edtEntradaPaisOrigenId_Enabled = 0;
         AssignProp("", false, edtEntradaPaisOrigenId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntradaPaisOrigenId_Enabled), 5, 0), true);
         edtEntradaPaisOrigenName_Enabled = 0;
         AssignProp("", false, edtEntradaPaisOrigenName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntradaPaisOrigenName_Enabled), 5, 0), true);
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
         context.AddJavascriptSource("gxcfg.js", "?20228913591275", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 552120), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 552120), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 552120), false, true);
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
         GxWebStd.gx_hidden_field( context, "Z42EntradaFecha", context.localUtil.DToC( Z42EntradaFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z43EntradaPaisOrigenId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z43EntradaPaisOrigenId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z44EntradaPaisOrigenName", Z44EntradaPaisOrigenName);
         GxWebStd.gx_hidden_field( context, "Z9ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9ClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z15FuncionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15FuncionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z27LugarSectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z27LugarSectorId), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "LUGARSECTORCANTIDADASIENTOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40LugarSectorCantidadAsientos), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORVENDIDAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vENTRADAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EntradaId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vENTRADAID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EntradaId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ClienteId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_FUNCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_FuncionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "PAISID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "LUGARID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TIPOESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7TipoEspectaculoId), 4, 0, ",", "")));
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
         A7TipoEspectaculoId = 0;
         AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
         A4LugarId = 0;
         AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
         A3PaisId = 0;
         AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
         A9ClienteId = 0;
         AssignAttri("", false, "A9ClienteId", StringUtil.LTrimStr( (decimal)(A9ClienteId), 4, 0));
         A15FuncionId = 0;
         AssignAttri("", false, "A15FuncionId", StringUtil.LTrimStr( (decimal)(A15FuncionId), 4, 0));
         A38LugarSectorDisponibles = 0;
         AssignAttri("", false, "A38LugarSectorDisponibles", StringUtil.LTrimStr( (decimal)(A38LugarSectorDisponibles), 4, 0));
         A42EntradaFecha = DateTime.MinValue;
         AssignAttri("", false, "A42EntradaFecha", context.localUtil.Format(A42EntradaFecha, "99/99/99"));
         A10ClienteName = "";
         AssignAttri("", false, "A10ClienteName", A10ClienteName);
         A1EspectaculoId = 0;
         AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         A2EspectaculoName = "";
         AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
         A16EspectaculoFecha = DateTime.MinValue;
         AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
         A22FuncionName = "";
         AssignAttri("", false, "A22FuncionName", A22FuncionName);
         A6PaisName = "";
         AssignAttri("", false, "A6PaisName", A6PaisName);
         A5LugarName = "";
         AssignAttri("", false, "A5LugarName", A5LugarName);
         A27LugarSectorId = 0;
         n27LugarSectorId = false;
         AssignAttri("", false, "A27LugarSectorId", StringUtil.LTrimStr( (decimal)(A27LugarSectorId), 4, 0));
         A28LugarSectorName = "";
         AssignAttri("", false, "A28LugarSectorName", A28LugarSectorName);
         A30LugarSectorPrecio = 0;
         AssignAttri("", false, "A30LugarSectorPrecio", StringUtil.LTrimStr( (decimal)(A30LugarSectorPrecio), 4, 0));
         A8TipoEspectaculoName = "";
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
         A43EntradaPaisOrigenId = 0;
         AssignAttri("", false, "A43EntradaPaisOrigenId", StringUtil.LTrimStr( (decimal)(A43EntradaPaisOrigenId), 4, 0));
         A44EntradaPaisOrigenName = "";
         AssignAttri("", false, "A44EntradaPaisOrigenName", A44EntradaPaisOrigenName);
         A40LugarSectorCantidadAsientos = 0;
         AssignAttri("", false, "A40LugarSectorCantidadAsientos", StringUtil.LTrimStr( (decimal)(A40LugarSectorCantidadAsientos), 4, 0));
         A37LugarSectorVendidas = 0;
         n37LugarSectorVendidas = false;
         AssignAttri("", false, "A37LugarSectorVendidas", StringUtil.LTrimStr( (decimal)(A37LugarSectorVendidas), 4, 0));
         Z42EntradaFecha = DateTime.MinValue;
         Z43EntradaPaisOrigenId = 0;
         Z44EntradaPaisOrigenName = "";
         Z9ClienteId = 0;
         Z15FuncionId = 0;
         Z27LugarSectorId = 0;
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
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228913591281", true, true);
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
         context.AddJavascriptSource("entrada.js", "?20228913591281", false, true);
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
         edtEntradaFecha_Internalname = "ENTRADAFECHA";
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteName_Internalname = "CLIENTENAME";
         edtEspectaculoId_Internalname = "ESPECTACULOID";
         edtEspectaculoName_Internalname = "ESPECTACULONAME";
         edtEspectaculoFecha_Internalname = "ESPECTACULOFECHA";
         edtFuncionId_Internalname = "FUNCIONID";
         edtFuncionName_Internalname = "FUNCIONNAME";
         edtPaisName_Internalname = "PAISNAME";
         edtLugarName_Internalname = "LUGARNAME";
         edtLugarSectorId_Internalname = "LUGARSECTORID";
         edtLugarSectorName_Internalname = "LUGARSECTORNAME";
         edtLugarSectorPrecio_Internalname = "LUGARSECTORPRECIO";
         edtLugarSectorDisponibles_Internalname = "LUGARSECTORDISPONIBLES";
         edtTipoEspectaculoName_Internalname = "TIPOESPECTACULONAME";
         edtEntradaPaisOrigenId_Internalname = "ENTRADAPAISORIGENID";
         edtEntradaPaisOrigenName_Internalname = "ENTRADAPAISORIGENNAME";
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
         edtEntradaPaisOrigenName_Jsonclick = "";
         edtEntradaPaisOrigenName_Enabled = 1;
         edtEntradaPaisOrigenId_Jsonclick = "";
         edtEntradaPaisOrigenId_Enabled = 1;
         edtTipoEspectaculoName_Jsonclick = "";
         edtTipoEspectaculoName_Enabled = 0;
         edtLugarSectorDisponibles_Jsonclick = "";
         edtLugarSectorDisponibles_Enabled = 0;
         edtLugarSectorPrecio_Jsonclick = "";
         edtLugarSectorPrecio_Enabled = 0;
         edtLugarSectorName_Jsonclick = "";
         edtLugarSectorName_Enabled = 0;
         edtLugarSectorId_Jsonclick = "";
         edtLugarSectorId_Enabled = 1;
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
         edtEspectaculoFecha_Jsonclick = "";
         edtEspectaculoFecha_Enabled = 0;
         edtEspectaculoName_Jsonclick = "";
         edtEspectaculoName_Enabled = 0;
         edtEspectaculoId_Jsonclick = "";
         edtEspectaculoId_Enabled = 0;
         edtClienteName_Jsonclick = "";
         edtClienteName_Enabled = 0;
         imgprompt_9_Visible = 1;
         imgprompt_9_Link = "";
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
         edtEntradaFecha_Jsonclick = "";
         edtEntradaFecha_Enabled = 1;
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
         /* Using cursor T000832 */
         pr_default.execute(27, new Object[] {A9ClienteId});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
         }
         A3PaisId = T000832_A3PaisId[0];
         A10ClienteName = T000832_A10ClienteName[0];
         pr_default.close(27);
         /* Using cursor T000833 */
         pr_default.execute(28, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(28) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = T000833_A6PaisName[0];
         pr_default.close(28);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A3PaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ".", "")));
         AssignAttri("", false, "A10ClienteName", A10ClienteName);
         AssignAttri("", false, "A6PaisName", A6PaisName);
      }

      public void Valid_Espectaculoid( )
      {
         /* Using cursor T000835 */
         pr_default.execute(30, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("No existe 'Espectaculo'.", "ForeignKeyNotFound", 1, "ESPECTACULOID");
            AnyError = 1;
         }
         A4LugarId = T000835_A4LugarId[0];
         A7TipoEspectaculoId = T000835_A7TipoEspectaculoId[0];
         A2EspectaculoName = T000835_A2EspectaculoName[0];
         A16EspectaculoFecha = T000835_A16EspectaculoFecha[0];
         pr_default.close(30);
         /* Using cursor T000836 */
         pr_default.execute(31, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(31) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
         }
         A5LugarName = T000836_A5LugarName[0];
         pr_default.close(31);
         /* Using cursor T000837 */
         pr_default.execute(32, new Object[] {A7TipoEspectaculoId});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
         }
         A8TipoEspectaculoName = T000837_A8TipoEspectaculoName[0];
         pr_default.close(32);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A4LugarId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ".", "")));
         AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7TipoEspectaculoId), 4, 0, ".", "")));
         AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
         AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
         AssignAttri("", false, "A5LugarName", A5LugarName);
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
      }

      public void Valid_Funcionid( )
      {
         /* Using cursor T000834 */
         pr_default.execute(29, new Object[] {A15FuncionId});
         if ( (pr_default.getStatus(29) == 101) )
         {
            GX_msglist.addItem("No existe 'Funcion'.", "ForeignKeyNotFound", 1, "FUNCIONID");
            AnyError = 1;
            GX_FocusControl = edtFuncionId_Internalname;
         }
         A22FuncionName = T000834_A22FuncionName[0];
         A1EspectaculoId = T000834_A1EspectaculoId[0];
         pr_default.close(29);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A22FuncionName", A22FuncionName);
         AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ".", "")));
      }

      public void Valid_Lugarsectorid( )
      {
         n27LugarSectorId = false;
         n37LugarSectorVendidas = false;
         /* Using cursor T000838 */
         pr_default.execute(33, new Object[] {A4LugarId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(33) == 101) )
         {
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "LUGARSECTORID");
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
         }
         A28LugarSectorName = T000838_A28LugarSectorName[0];
         A30LugarSectorPrecio = T000838_A30LugarSectorPrecio[0];
         pr_default.close(33);
         /* Using cursor T000839 */
         pr_default.execute(34, new Object[] {A1EspectaculoId, n27LugarSectorId, A27LugarSectorId});
         if ( (pr_default.getStatus(34) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar Sector'.", "ForeignKeyNotFound", 1, "LUGARSECTORID");
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
         }
         A40LugarSectorCantidadAsientos = T000839_A40LugarSectorCantidadAsientos[0];
         pr_default.close(34);
         /* Using cursor T000841 */
         pr_default.execute(35, new Object[] {n27LugarSectorId, A27LugarSectorId, A1EspectaculoId});
         if ( (pr_default.getStatus(35) != 101) )
         {
            A37LugarSectorVendidas = T000841_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = T000841_n37LugarSectorVendidas[0];
         }
         else
         {
            A37LugarSectorVendidas = 0;
            n37LugarSectorVendidas = false;
         }
         pr_default.close(35);
         A38LugarSectorDisponibles = (short)(A40LugarSectorCantidadAsientos-A37LugarSectorVendidas);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A28LugarSectorName", A28LugarSectorName);
         AssignAttri("", false, "A30LugarSectorPrecio", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ".", "")));
         AssignAttri("", false, "A40LugarSectorCantidadAsientos", StringUtil.LTrim( StringUtil.NToC( (decimal)(A40LugarSectorCantidadAsientos), 4, 0, ".", "")));
         AssignAttri("", false, "A37LugarSectorVendidas", StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ".", "")));
         AssignAttri("", false, "A38LugarSectorDisponibles", StringUtil.LTrim( StringUtil.NToC( (decimal)(A38LugarSectorDisponibles), 4, 0, ".", "")));
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
         setEventMetadata("VALID_ENTRADAFECHA","{handler:'Valid_Entradafecha',iparms:[]");
         setEventMetadata("VALID_ENTRADAFECHA",",oparms:[]}");
         setEventMetadata("VALID_CLIENTEID","{handler:'Valid_Clienteid',iparms:[{av:'A9ClienteId',fld:'CLIENTEID',pic:'ZZZ9'},{av:'A3PaisId',fld:'PAISID',pic:'ZZZ9'},{av:'A10ClienteName',fld:'CLIENTENAME',pic:''},{av:'A6PaisName',fld:'PAISNAME',pic:''}]");
         setEventMetadata("VALID_CLIENTEID",",oparms:[{av:'A3PaisId',fld:'PAISID',pic:'ZZZ9'},{av:'A10ClienteName',fld:'CLIENTENAME',pic:''},{av:'A6PaisName',fld:'PAISNAME',pic:''}]}");
         setEventMetadata("VALID_ESPECTACULOID","{handler:'Valid_Espectaculoid',iparms:[{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A4LugarId',fld:'LUGARID',pic:'ZZZ9'},{av:'A7TipoEspectaculoId',fld:'TIPOESPECTACULOID',pic:'ZZZ9'},{av:'A2EspectaculoName',fld:'ESPECTACULONAME',pic:''},{av:'A16EspectaculoFecha',fld:'ESPECTACULOFECHA',pic:''},{av:'A5LugarName',fld:'LUGARNAME',pic:''},{av:'A8TipoEspectaculoName',fld:'TIPOESPECTACULONAME',pic:''}]");
         setEventMetadata("VALID_ESPECTACULOID",",oparms:[{av:'A4LugarId',fld:'LUGARID',pic:'ZZZ9'},{av:'A7TipoEspectaculoId',fld:'TIPOESPECTACULOID',pic:'ZZZ9'},{av:'A2EspectaculoName',fld:'ESPECTACULONAME',pic:''},{av:'A16EspectaculoFecha',fld:'ESPECTACULOFECHA',pic:''},{av:'A5LugarName',fld:'LUGARNAME',pic:''},{av:'A8TipoEspectaculoName',fld:'TIPOESPECTACULONAME',pic:''}]}");
         setEventMetadata("VALID_FUNCIONID","{handler:'Valid_Funcionid',iparms:[{av:'A15FuncionId',fld:'FUNCIONID',pic:'ZZZ9'},{av:'A22FuncionName',fld:'FUNCIONNAME',pic:''},{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_FUNCIONID",",oparms:[{av:'A22FuncionName',fld:'FUNCIONNAME',pic:''},{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_LUGARSECTORID","{handler:'Valid_Lugarsectorid',iparms:[{av:'A4LugarId',fld:'LUGARID',pic:'ZZZ9'},{av:'A27LugarSectorId',fld:'LUGARSECTORID',pic:'ZZZ9'},{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A40LugarSectorCantidadAsientos',fld:'LUGARSECTORCANTIDADASIENTOS',pic:'ZZZ9'},{av:'A37LugarSectorVendidas',fld:'LUGARSECTORVENDIDAS',pic:'ZZZ9'},{av:'A28LugarSectorName',fld:'LUGARSECTORNAME',pic:''},{av:'A30LugarSectorPrecio',fld:'LUGARSECTORPRECIO',pic:'ZZZ9'},{av:'A38LugarSectorDisponibles',fld:'LUGARSECTORDISPONIBLES',pic:'ZZZ9'}]");
         setEventMetadata("VALID_LUGARSECTORID",",oparms:[{av:'A28LugarSectorName',fld:'LUGARSECTORNAME',pic:''},{av:'A30LugarSectorPrecio',fld:'LUGARSECTORPRECIO',pic:'ZZZ9'},{av:'A40LugarSectorCantidadAsientos',fld:'LUGARSECTORCANTIDADASIENTOS',pic:'ZZZ9'},{av:'A37LugarSectorVendidas',fld:'LUGARSECTORVENDIDAS',pic:'ZZZ9'},{av:'A38LugarSectorDisponibles',fld:'LUGARSECTORDISPONIBLES',pic:'ZZZ9'}]}");
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
         pr_default.close(27);
         pr_default.close(29);
         pr_default.close(28);
         pr_default.close(30);
         pr_default.close(31);
         pr_default.close(32);
         pr_default.close(33);
         pr_default.close(34);
         pr_default.close(35);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z42EntradaFecha = DateTime.MinValue;
         Z44EntradaPaisOrigenName = "";
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
         A42EntradaFecha = DateTime.MinValue;
         sImgUrl = "";
         A10ClienteName = "";
         A2EspectaculoName = "";
         A16EspectaculoFecha = DateTime.MinValue;
         A22FuncionName = "";
         A6PaisName = "";
         A5LugarName = "";
         A28LugarSectorName = "";
         A8TipoEspectaculoName = "";
         A44EntradaPaisOrigenName = "";
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
         Z2EspectaculoName = "";
         Z16EspectaculoFecha = DateTime.MinValue;
         Z5LugarName = "";
         Z8TipoEspectaculoName = "";
         Z28LugarSectorName = "";
         T00085_A22FuncionName = new string[] {""} ;
         T00085_A1EspectaculoId = new short[1] ;
         T00087_A4LugarId = new short[1] ;
         T00087_A7TipoEspectaculoId = new short[1] ;
         T00087_A2EspectaculoName = new string[] {""} ;
         T00087_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T00088_A5LugarName = new string[] {""} ;
         T00089_A8TipoEspectaculoName = new string[] {""} ;
         T00084_A3PaisId = new short[1] ;
         T00084_A10ClienteName = new string[] {""} ;
         T00086_A6PaisName = new string[] {""} ;
         T000815_A3PaisId = new short[1] ;
         T000815_A4LugarId = new short[1] ;
         T000815_A7TipoEspectaculoId = new short[1] ;
         T000815_A23EntradaId = new short[1] ;
         T000815_A42EntradaFecha = new DateTime[] {DateTime.MinValue} ;
         T000815_A10ClienteName = new string[] {""} ;
         T000815_A2EspectaculoName = new string[] {""} ;
         T000815_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T000815_A22FuncionName = new string[] {""} ;
         T000815_A6PaisName = new string[] {""} ;
         T000815_A5LugarName = new string[] {""} ;
         T000815_A28LugarSectorName = new string[] {""} ;
         T000815_A30LugarSectorPrecio = new short[1] ;
         T000815_A8TipoEspectaculoName = new string[] {""} ;
         T000815_A43EntradaPaisOrigenId = new short[1] ;
         T000815_A44EntradaPaisOrigenName = new string[] {""} ;
         T000815_A40LugarSectorCantidadAsientos = new short[1] ;
         T000815_A9ClienteId = new short[1] ;
         T000815_A15FuncionId = new short[1] ;
         T000815_A1EspectaculoId = new short[1] ;
         T000815_A27LugarSectorId = new short[1] ;
         T000815_n27LugarSectorId = new bool[] {false} ;
         T000815_A37LugarSectorVendidas = new short[1] ;
         T000815_n37LugarSectorVendidas = new bool[] {false} ;
         T000810_A28LugarSectorName = new string[] {""} ;
         T000810_A30LugarSectorPrecio = new short[1] ;
         T000811_A40LugarSectorCantidadAsientos = new short[1] ;
         T000813_A37LugarSectorVendidas = new short[1] ;
         T000813_n37LugarSectorVendidas = new bool[] {false} ;
         T000816_A3PaisId = new short[1] ;
         T000816_A10ClienteName = new string[] {""} ;
         T000817_A6PaisName = new string[] {""} ;
         T000818_A22FuncionName = new string[] {""} ;
         T000818_A1EspectaculoId = new short[1] ;
         T000819_A4LugarId = new short[1] ;
         T000819_A7TipoEspectaculoId = new short[1] ;
         T000819_A2EspectaculoName = new string[] {""} ;
         T000819_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T000820_A5LugarName = new string[] {""} ;
         T000821_A28LugarSectorName = new string[] {""} ;
         T000821_A30LugarSectorPrecio = new short[1] ;
         T000822_A8TipoEspectaculoName = new string[] {""} ;
         T000823_A40LugarSectorCantidadAsientos = new short[1] ;
         T000825_A37LugarSectorVendidas = new short[1] ;
         T000825_n37LugarSectorVendidas = new bool[] {false} ;
         T000826_A23EntradaId = new short[1] ;
         T00083_A23EntradaId = new short[1] ;
         T00083_A42EntradaFecha = new DateTime[] {DateTime.MinValue} ;
         T00083_A43EntradaPaisOrigenId = new short[1] ;
         T00083_A44EntradaPaisOrigenName = new string[] {""} ;
         T00083_A9ClienteId = new short[1] ;
         T00083_A15FuncionId = new short[1] ;
         T00083_A27LugarSectorId = new short[1] ;
         T00083_n27LugarSectorId = new bool[] {false} ;
         T000827_A23EntradaId = new short[1] ;
         T000828_A23EntradaId = new short[1] ;
         T00082_A23EntradaId = new short[1] ;
         T00082_A42EntradaFecha = new DateTime[] {DateTime.MinValue} ;
         T00082_A43EntradaPaisOrigenId = new short[1] ;
         T00082_A44EntradaPaisOrigenName = new string[] {""} ;
         T00082_A9ClienteId = new short[1] ;
         T00082_A15FuncionId = new short[1] ;
         T00082_A27LugarSectorId = new short[1] ;
         T00082_n27LugarSectorId = new bool[] {false} ;
         T000829_A23EntradaId = new short[1] ;
         T000832_A3PaisId = new short[1] ;
         T000832_A10ClienteName = new string[] {""} ;
         T000833_A6PaisName = new string[] {""} ;
         T000834_A22FuncionName = new string[] {""} ;
         T000834_A1EspectaculoId = new short[1] ;
         T000835_A4LugarId = new short[1] ;
         T000835_A7TipoEspectaculoId = new short[1] ;
         T000835_A2EspectaculoName = new string[] {""} ;
         T000835_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T000836_A5LugarName = new string[] {""} ;
         T000837_A8TipoEspectaculoName = new string[] {""} ;
         T000838_A28LugarSectorName = new string[] {""} ;
         T000838_A30LugarSectorPrecio = new short[1] ;
         T000839_A40LugarSectorCantidadAsientos = new short[1] ;
         T000841_A37LugarSectorVendidas = new short[1] ;
         T000841_n37LugarSectorVendidas = new bool[] {false} ;
         T000842_A23EntradaId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.entrada__default(),
            new Object[][] {
                new Object[] {
               T00082_A23EntradaId, T00082_A42EntradaFecha, T00082_A43EntradaPaisOrigenId, T00082_A44EntradaPaisOrigenName, T00082_A9ClienteId, T00082_A15FuncionId, T00082_A27LugarSectorId
               }
               , new Object[] {
               T00083_A23EntradaId, T00083_A42EntradaFecha, T00083_A43EntradaPaisOrigenId, T00083_A44EntradaPaisOrigenName, T00083_A9ClienteId, T00083_A15FuncionId, T00083_A27LugarSectorId
               }
               , new Object[] {
               T00084_A3PaisId, T00084_A10ClienteName
               }
               , new Object[] {
               T00085_A22FuncionName, T00085_A1EspectaculoId
               }
               , new Object[] {
               T00086_A6PaisName
               }
               , new Object[] {
               T00087_A4LugarId, T00087_A7TipoEspectaculoId, T00087_A2EspectaculoName, T00087_A16EspectaculoFecha
               }
               , new Object[] {
               T00088_A5LugarName
               }
               , new Object[] {
               T00089_A8TipoEspectaculoName
               }
               , new Object[] {
               T000810_A28LugarSectorName, T000810_A30LugarSectorPrecio
               }
               , new Object[] {
               T000811_A40LugarSectorCantidadAsientos
               }
               , new Object[] {
               T000813_A37LugarSectorVendidas, T000813_n37LugarSectorVendidas
               }
               , new Object[] {
               T000815_A3PaisId, T000815_A4LugarId, T000815_A7TipoEspectaculoId, T000815_A23EntradaId, T000815_A42EntradaFecha, T000815_A10ClienteName, T000815_A2EspectaculoName, T000815_A16EspectaculoFecha, T000815_A22FuncionName, T000815_A6PaisName,
               T000815_A5LugarName, T000815_A28LugarSectorName, T000815_A30LugarSectorPrecio, T000815_A8TipoEspectaculoName, T000815_A43EntradaPaisOrigenId, T000815_A44EntradaPaisOrigenName, T000815_A40LugarSectorCantidadAsientos, T000815_A9ClienteId, T000815_A15FuncionId, T000815_A1EspectaculoId,
               T000815_A27LugarSectorId, T000815_n27LugarSectorId, T000815_A37LugarSectorVendidas, T000815_n37LugarSectorVendidas
               }
               , new Object[] {
               T000816_A3PaisId, T000816_A10ClienteName
               }
               , new Object[] {
               T000817_A6PaisName
               }
               , new Object[] {
               T000818_A22FuncionName, T000818_A1EspectaculoId
               }
               , new Object[] {
               T000819_A4LugarId, T000819_A7TipoEspectaculoId, T000819_A2EspectaculoName, T000819_A16EspectaculoFecha
               }
               , new Object[] {
               T000820_A5LugarName
               }
               , new Object[] {
               T000821_A28LugarSectorName, T000821_A30LugarSectorPrecio
               }
               , new Object[] {
               T000822_A8TipoEspectaculoName
               }
               , new Object[] {
               T000823_A40LugarSectorCantidadAsientos
               }
               , new Object[] {
               T000825_A37LugarSectorVendidas, T000825_n37LugarSectorVendidas
               }
               , new Object[] {
               T000826_A23EntradaId
               }
               , new Object[] {
               T000827_A23EntradaId
               }
               , new Object[] {
               T000828_A23EntradaId
               }
               , new Object[] {
               T000829_A23EntradaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000832_A3PaisId, T000832_A10ClienteName
               }
               , new Object[] {
               T000833_A6PaisName
               }
               , new Object[] {
               T000834_A22FuncionName, T000834_A1EspectaculoId
               }
               , new Object[] {
               T000835_A4LugarId, T000835_A7TipoEspectaculoId, T000835_A2EspectaculoName, T000835_A16EspectaculoFecha
               }
               , new Object[] {
               T000836_A5LugarName
               }
               , new Object[] {
               T000837_A8TipoEspectaculoName
               }
               , new Object[] {
               T000838_A28LugarSectorName, T000838_A30LugarSectorPrecio
               }
               , new Object[] {
               T000839_A40LugarSectorCantidadAsientos
               }
               , new Object[] {
               T000841_A37LugarSectorVendidas, T000841_n37LugarSectorVendidas
               }
               , new Object[] {
               T000842_A23EntradaId
               }
            }
         );
         AV14Pgmname = "Entrada";
      }

      private short wcpOAV7EntradaId ;
      private short Z23EntradaId ;
      private short Z43EntradaPaisOrigenId ;
      private short Z9ClienteId ;
      private short Z15FuncionId ;
      private short Z27LugarSectorId ;
      private short N9ClienteId ;
      private short N15FuncionId ;
      private short GxWebError ;
      private short A9ClienteId ;
      private short A3PaisId ;
      private short A15FuncionId ;
      private short A1EspectaculoId ;
      private short A4LugarId ;
      private short A27LugarSectorId ;
      private short A7TipoEspectaculoId ;
      private short AV7EntradaId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A23EntradaId ;
      private short A30LugarSectorPrecio ;
      private short A38LugarSectorDisponibles ;
      private short A43EntradaPaisOrigenId ;
      private short A40LugarSectorCantidadAsientos ;
      private short A37LugarSectorVendidas ;
      private short AV11Insert_ClienteId ;
      private short AV12Insert_FuncionId ;
      private short RcdFound9 ;
      private short GX_JID ;
      private short Z3PaisId ;
      private short Z1EspectaculoId ;
      private short Z4LugarId ;
      private short Z7TipoEspectaculoId ;
      private short Z30LugarSectorPrecio ;
      private short Z40LugarSectorCantidadAsientos ;
      private short Z37LugarSectorVendidas ;
      private short Gx_BScreen ;
      private short nIsDirty_9 ;
      private short gxajaxcallmode ;
      private short Z38LugarSectorDisponibles ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtEntradaId_Enabled ;
      private int edtEntradaFecha_Enabled ;
      private int edtClienteId_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtClienteName_Enabled ;
      private int edtEspectaculoId_Enabled ;
      private int edtEspectaculoName_Enabled ;
      private int edtEspectaculoFecha_Enabled ;
      private int edtFuncionId_Enabled ;
      private int imgprompt_15_Visible ;
      private int edtFuncionName_Enabled ;
      private int edtPaisName_Enabled ;
      private int edtLugarName_Enabled ;
      private int edtLugarSectorId_Enabled ;
      private int edtLugarSectorName_Enabled ;
      private int edtLugarSectorPrecio_Enabled ;
      private int edtLugarSectorDisponibles_Enabled ;
      private int edtTipoEspectaculoName_Enabled ;
      private int edtEntradaPaisOrigenId_Enabled ;
      private int edtEntradaPaisOrigenName_Enabled ;
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
      private string edtEntradaFecha_Internalname ;
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
      private string edtEntradaFecha_Jsonclick ;
      private string edtClienteId_Internalname ;
      private string edtClienteId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_9_Internalname ;
      private string imgprompt_9_Link ;
      private string edtClienteName_Internalname ;
      private string edtClienteName_Jsonclick ;
      private string edtEspectaculoId_Internalname ;
      private string edtEspectaculoId_Jsonclick ;
      private string edtEspectaculoName_Internalname ;
      private string edtEspectaculoName_Jsonclick ;
      private string edtEspectaculoFecha_Internalname ;
      private string edtEspectaculoFecha_Jsonclick ;
      private string edtFuncionId_Internalname ;
      private string edtFuncionId_Jsonclick ;
      private string imgprompt_15_Internalname ;
      private string imgprompt_15_Link ;
      private string edtFuncionName_Internalname ;
      private string edtFuncionName_Jsonclick ;
      private string edtPaisName_Internalname ;
      private string edtPaisName_Jsonclick ;
      private string edtLugarName_Internalname ;
      private string edtLugarName_Jsonclick ;
      private string edtLugarSectorId_Internalname ;
      private string edtLugarSectorId_Jsonclick ;
      private string edtLugarSectorName_Internalname ;
      private string edtLugarSectorName_Jsonclick ;
      private string edtLugarSectorPrecio_Internalname ;
      private string edtLugarSectorPrecio_Jsonclick ;
      private string edtLugarSectorDisponibles_Internalname ;
      private string edtLugarSectorDisponibles_Jsonclick ;
      private string edtTipoEspectaculoName_Internalname ;
      private string edtTipoEspectaculoName_Jsonclick ;
      private string edtEntradaPaisOrigenId_Internalname ;
      private string edtEntradaPaisOrigenId_Jsonclick ;
      private string edtEntradaPaisOrigenName_Internalname ;
      private string edtEntradaPaisOrigenName_Jsonclick ;
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
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z42EntradaFecha ;
      private DateTime A42EntradaFecha ;
      private DateTime A16EspectaculoFecha ;
      private DateTime Z16EspectaculoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n27LugarSectorId ;
      private bool wbErr ;
      private bool n37LugarSectorVendidas ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z44EntradaPaisOrigenName ;
      private string A10ClienteName ;
      private string A2EspectaculoName ;
      private string A22FuncionName ;
      private string A6PaisName ;
      private string A5LugarName ;
      private string A28LugarSectorName ;
      private string A8TipoEspectaculoName ;
      private string A44EntradaPaisOrigenName ;
      private string Z10ClienteName ;
      private string Z6PaisName ;
      private string Z22FuncionName ;
      private string Z2EspectaculoName ;
      private string Z5LugarName ;
      private string Z8TipoEspectaculoName ;
      private string Z28LugarSectorName ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00085_A22FuncionName ;
      private short[] T00085_A1EspectaculoId ;
      private short[] T00087_A4LugarId ;
      private short[] T00087_A7TipoEspectaculoId ;
      private string[] T00087_A2EspectaculoName ;
      private DateTime[] T00087_A16EspectaculoFecha ;
      private string[] T00088_A5LugarName ;
      private string[] T00089_A8TipoEspectaculoName ;
      private short[] T00084_A3PaisId ;
      private string[] T00084_A10ClienteName ;
      private string[] T00086_A6PaisName ;
      private short[] T000815_A3PaisId ;
      private short[] T000815_A4LugarId ;
      private short[] T000815_A7TipoEspectaculoId ;
      private short[] T000815_A23EntradaId ;
      private DateTime[] T000815_A42EntradaFecha ;
      private string[] T000815_A10ClienteName ;
      private string[] T000815_A2EspectaculoName ;
      private DateTime[] T000815_A16EspectaculoFecha ;
      private string[] T000815_A22FuncionName ;
      private string[] T000815_A6PaisName ;
      private string[] T000815_A5LugarName ;
      private string[] T000815_A28LugarSectorName ;
      private short[] T000815_A30LugarSectorPrecio ;
      private string[] T000815_A8TipoEspectaculoName ;
      private short[] T000815_A43EntradaPaisOrigenId ;
      private string[] T000815_A44EntradaPaisOrigenName ;
      private short[] T000815_A40LugarSectorCantidadAsientos ;
      private short[] T000815_A9ClienteId ;
      private short[] T000815_A15FuncionId ;
      private short[] T000815_A1EspectaculoId ;
      private short[] T000815_A27LugarSectorId ;
      private bool[] T000815_n27LugarSectorId ;
      private short[] T000815_A37LugarSectorVendidas ;
      private bool[] T000815_n37LugarSectorVendidas ;
      private string[] T000810_A28LugarSectorName ;
      private short[] T000810_A30LugarSectorPrecio ;
      private short[] T000811_A40LugarSectorCantidadAsientos ;
      private short[] T000813_A37LugarSectorVendidas ;
      private bool[] T000813_n37LugarSectorVendidas ;
      private short[] T000816_A3PaisId ;
      private string[] T000816_A10ClienteName ;
      private string[] T000817_A6PaisName ;
      private string[] T000818_A22FuncionName ;
      private short[] T000818_A1EspectaculoId ;
      private short[] T000819_A4LugarId ;
      private short[] T000819_A7TipoEspectaculoId ;
      private string[] T000819_A2EspectaculoName ;
      private DateTime[] T000819_A16EspectaculoFecha ;
      private string[] T000820_A5LugarName ;
      private string[] T000821_A28LugarSectorName ;
      private short[] T000821_A30LugarSectorPrecio ;
      private string[] T000822_A8TipoEspectaculoName ;
      private short[] T000823_A40LugarSectorCantidadAsientos ;
      private short[] T000825_A37LugarSectorVendidas ;
      private bool[] T000825_n37LugarSectorVendidas ;
      private short[] T000826_A23EntradaId ;
      private short[] T00083_A23EntradaId ;
      private DateTime[] T00083_A42EntradaFecha ;
      private short[] T00083_A43EntradaPaisOrigenId ;
      private string[] T00083_A44EntradaPaisOrigenName ;
      private short[] T00083_A9ClienteId ;
      private short[] T00083_A15FuncionId ;
      private short[] T00083_A27LugarSectorId ;
      private bool[] T00083_n27LugarSectorId ;
      private short[] T000827_A23EntradaId ;
      private short[] T000828_A23EntradaId ;
      private short[] T00082_A23EntradaId ;
      private DateTime[] T00082_A42EntradaFecha ;
      private short[] T00082_A43EntradaPaisOrigenId ;
      private string[] T00082_A44EntradaPaisOrigenName ;
      private short[] T00082_A9ClienteId ;
      private short[] T00082_A15FuncionId ;
      private short[] T00082_A27LugarSectorId ;
      private bool[] T00082_n27LugarSectorId ;
      private short[] T000829_A23EntradaId ;
      private short[] T000832_A3PaisId ;
      private string[] T000832_A10ClienteName ;
      private string[] T000833_A6PaisName ;
      private string[] T000834_A22FuncionName ;
      private short[] T000834_A1EspectaculoId ;
      private short[] T000835_A4LugarId ;
      private short[] T000835_A7TipoEspectaculoId ;
      private string[] T000835_A2EspectaculoName ;
      private DateTime[] T000835_A16EspectaculoFecha ;
      private string[] T000836_A5LugarName ;
      private string[] T000837_A8TipoEspectaculoName ;
      private string[] T000838_A28LugarSectorName ;
      private short[] T000838_A30LugarSectorPrecio ;
      private short[] T000839_A40LugarSectorCantidadAsientos ;
      private short[] T000841_A37LugarSectorVendidas ;
      private bool[] T000841_n37LugarSectorVendidas ;
      private short[] T000842_A23EntradaId ;
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
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
         ,new ForEachCursor(def[33])
         ,new ForEachCursor(def[34])
         ,new ForEachCursor(def[35])
         ,new ForEachCursor(def[36])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000815;
          prmT000815 = new Object[] {
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
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT00089;
          prmT00089 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000811;
          prmT000811 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000813;
          prmT000813 = new Object[] {
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000816;
          prmT000816 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000817;
          prmT000817 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000818;
          prmT000818 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmT000819;
          prmT000819 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000820;
          prmT000820 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000821;
          prmT000821 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000822;
          prmT000822 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000823;
          prmT000823 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000825;
          prmT000825 = new Object[] {
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000826;
          prmT000826 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT00083;
          prmT00083 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT000827;
          prmT000827 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT000828;
          prmT000828 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT00082;
          prmT00082 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT000829;
          prmT000829 = new Object[] {
          new ParDef("@EntradaFecha",GXType.Date,8,0) ,
          new ParDef("@EntradaPaisOrigenId",GXType.Int16,4,0) ,
          new ParDef("@EntradaPaisOrigenName",GXType.NVarChar,40,0) ,
          new ParDef("@ClienteId",GXType.Int16,4,0) ,
          new ParDef("@FuncionId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000830;
          prmT000830 = new Object[] {
          new ParDef("@EntradaFecha",GXType.Date,8,0) ,
          new ParDef("@EntradaPaisOrigenId",GXType.Int16,4,0) ,
          new ParDef("@EntradaPaisOrigenName",GXType.NVarChar,40,0) ,
          new ParDef("@ClienteId",GXType.Int16,4,0) ,
          new ParDef("@FuncionId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT000831;
          prmT000831 = new Object[] {
          new ParDef("@EntradaId",GXType.Int16,4,0)
          };
          Object[] prmT000842;
          prmT000842 = new Object[] {
          };
          Object[] prmT000832;
          prmT000832 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000833;
          prmT000833 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000835;
          prmT000835 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000836;
          prmT000836 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000837;
          prmT000837 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000834;
          prmT000834 = new Object[] {
          new ParDef("@FuncionId",GXType.Int16,4,0)
          };
          Object[] prmT000838;
          prmT000838 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000839;
          prmT000839 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000841;
          prmT000841 = new Object[] {
          new ParDef("@LugarSectorId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00082", "SELECT [EntradaId], [EntradaFecha], [EntradaPaisOrigenId], [EntradaPaisOrigenName], [ClienteId], [FuncionId], [LugarSectorId] FROM [Entrada] WITH (UPDLOCK) WHERE [EntradaId] = @EntradaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00082,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00083", "SELECT [EntradaId], [EntradaFecha], [EntradaPaisOrigenId], [EntradaPaisOrigenName], [ClienteId], [FuncionId], [LugarSectorId] FROM [Entrada] WHERE [EntradaId] = @EntradaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00083,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00084", "SELECT [PaisId], [ClienteName] FROM [Cliente] WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00084,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00085", "SELECT [FuncionName], [EspectaculoId] FROM [Funcion] WHERE [FuncionId] = @FuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00085,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00086", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00086,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00087", "SELECT [LugarId], [TipoEspectaculoId], [EspectaculoName], [EspectaculoFecha] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00087,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00088", "SELECT [LugarName] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00088,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00089", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00089,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000810", "SELECT [LugarSectorName], [LugarSectorPrecio] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000810,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000811", "SELECT [LugarSectorCantidadAsientos] FROM [EspectaculoLugarSector] WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000811,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000813", "SELECT COALESCE( T1.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (SELECT COUNT(*) AS LugarSectorVendidas, T2.[LugarSectorId], T3.[EspectaculoId] FROM ([Entrada] T2 WITH (UPDLOCK) INNER JOIN [Funcion] T3 ON T3.[FuncionId] = T2.[FuncionId]) GROUP BY T2.[LugarSectorId], T3.[EspectaculoId] ) T1 WHERE T1.[LugarSectorId] = @LugarSectorId AND T1.[EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000813,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000815", "SELECT T2.[PaisId], T5.[LugarId], T5.[TipoEspectaculoId], TM1.[EntradaId], TM1.[EntradaFecha], T2.[ClienteName], T5.[EspectaculoName], T5.[EspectaculoFecha], T4.[FuncionName], T3.[PaisName], T6.[LugarName], T8.[LugarSectorName], T8.[LugarSectorPrecio], T7.[TipoEspectaculoName], TM1.[EntradaPaisOrigenId], TM1.[EntradaPaisOrigenName], T9.[LugarSectorCantidadAsientos], TM1.[ClienteId], TM1.[FuncionId], T4.[EspectaculoId], TM1.[LugarSectorId], COALESCE( T10.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM ((((((((([Entrada] TM1 INNER JOIN [Cliente] T2 ON T2.[ClienteId] = TM1.[ClienteId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = T2.[PaisId]) INNER JOIN [Funcion] T4 ON T4.[FuncionId] = TM1.[FuncionId]) INNER JOIN [Espectaculo] T5 ON T5.[EspectaculoId] = T4.[EspectaculoId]) INNER JOIN [Lugar] T6 ON T6.[LugarId] = T5.[LugarId]) INNER JOIN [TipoEspectaculo] T7 ON T7.[TipoEspectaculoId] = T5.[TipoEspectaculoId]) LEFT JOIN [LugarSector] T8 ON T8.[LugarId] = T5.[LugarId] AND T8.[LugarSectorId] = TM1.[LugarSectorId]) LEFT JOIN [EspectaculoLugarSector] T9 ON T9.[EspectaculoId] = T4.[EspectaculoId] AND T9.[LugarSectorId] = TM1.[LugarSectorId]) LEFT JOIN (SELECT COUNT(*) AS LugarSectorVendidas, TM1.[LugarSectorId], T12.[EspectaculoId] FROM ([Entrada] TM1 INNER JOIN [Funcion] T12 ON T12.[FuncionId] = TM1.[FuncionId]) GROUP BY TM1.[LugarSectorId], T12.[EspectaculoId] ) T10 ON T10.[LugarSectorId] = TM1.[LugarSectorId] AND T10.[EspectaculoId] = T4.[EspectaculoId]) WHERE TM1.[EntradaId] = @EntradaId ORDER BY TM1.[EntradaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000815,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000816", "SELECT [PaisId], [ClienteName] FROM [Cliente] WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000816,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000817", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000817,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000818", "SELECT [FuncionName], [EspectaculoId] FROM [Funcion] WHERE [FuncionId] = @FuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000818,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000819", "SELECT [LugarId], [TipoEspectaculoId], [EspectaculoName], [EspectaculoFecha] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000819,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000820", "SELECT [LugarName] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000820,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000821", "SELECT [LugarSectorName], [LugarSectorPrecio] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000821,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000822", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000822,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000823", "SELECT [LugarSectorCantidadAsientos] FROM [EspectaculoLugarSector] WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000823,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000825", "SELECT COALESCE( T1.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (SELECT COUNT(*) AS LugarSectorVendidas, T2.[LugarSectorId], T3.[EspectaculoId] FROM ([Entrada] T2 WITH (UPDLOCK) INNER JOIN [Funcion] T3 ON T3.[FuncionId] = T2.[FuncionId]) GROUP BY T2.[LugarSectorId], T3.[EspectaculoId] ) T1 WHERE T1.[LugarSectorId] = @LugarSectorId AND T1.[EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000825,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000826", "SELECT [EntradaId] FROM [Entrada] WHERE [EntradaId] = @EntradaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000826,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000827", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE ( [EntradaId] > @EntradaId) ORDER BY [EntradaId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000827,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000828", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE ( [EntradaId] < @EntradaId) ORDER BY [EntradaId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000828,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000829", "INSERT INTO [Entrada]([EntradaFecha], [EntradaPaisOrigenId], [EntradaPaisOrigenName], [ClienteId], [FuncionId], [LugarSectorId]) VALUES(@EntradaFecha, @EntradaPaisOrigenId, @EntradaPaisOrigenName, @ClienteId, @FuncionId, @LugarSectorId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000829,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000830", "UPDATE [Entrada] SET [EntradaFecha]=@EntradaFecha, [EntradaPaisOrigenId]=@EntradaPaisOrigenId, [EntradaPaisOrigenName]=@EntradaPaisOrigenName, [ClienteId]=@ClienteId, [FuncionId]=@FuncionId, [LugarSectorId]=@LugarSectorId  WHERE [EntradaId] = @EntradaId", GxErrorMask.GX_NOMASK,prmT000830)
             ,new CursorDef("T000831", "DELETE FROM [Entrada]  WHERE [EntradaId] = @EntradaId", GxErrorMask.GX_NOMASK,prmT000831)
             ,new CursorDef("T000832", "SELECT [PaisId], [ClienteName] FROM [Cliente] WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000832,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000833", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000833,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000834", "SELECT [FuncionName], [EspectaculoId] FROM [Funcion] WHERE [FuncionId] = @FuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000834,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000835", "SELECT [LugarId], [TipoEspectaculoId], [EspectaculoName], [EspectaculoFecha] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000835,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000836", "SELECT [LugarName] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000836,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000837", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000837,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000838", "SELECT [LugarSectorName], [LugarSectorPrecio] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000838,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000839", "SELECT [LugarSectorCantidadAsientos] FROM [EspectaculoLugarSector] WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000839,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000841", "SELECT COALESCE( T1.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (SELECT COUNT(*) AS LugarSectorVendidas, T2.[LugarSectorId], T3.[EspectaculoId] FROM ([Entrada] T2 WITH (UPDLOCK) INNER JOIN [Funcion] T3 ON T3.[FuncionId] = T2.[FuncionId]) GROUP BY T2.[LugarSectorId], T3.[EspectaculoId] ) T1 WHERE T1.[LugarSectorId] = @LugarSectorId AND T1.[EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000841,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000842", "SELECT [EntradaId] FROM [Entrada] ORDER BY [EntradaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000842,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
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
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((short[]) buf[12])[0] = rslt.getShort(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((short[]) buf[14])[0] = rslt.getShort(15);
                ((string[]) buf[15])[0] = rslt.getVarchar(16);
                ((short[]) buf[16])[0] = rslt.getShort(17);
                ((short[]) buf[17])[0] = rslt.getShort(18);
                ((short[]) buf[18])[0] = rslt.getShort(19);
                ((short[]) buf[19])[0] = rslt.getShort(20);
                ((short[]) buf[20])[0] = rslt.getShort(21);
                ((bool[]) buf[21])[0] = rslt.wasNull(21);
                ((short[]) buf[22])[0] = rslt.getShort(22);
                ((bool[]) buf[23])[0] = rslt.wasNull(22);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 18 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 21 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 27 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 28 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 29 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                return;
             case 31 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 32 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 33 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 34 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 35 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 36 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
