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
   public class espectaculo : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            A4LugarId = (short)(NumberUtil.Val( GetPar( "LugarId"), "."));
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A4LugarId) ;
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
            A7TipoEspectaculoId = (short)(NumberUtil.Val( GetPar( "TipoEspectaculoId"), "."));
            AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A7TipoEspectaculoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A4LugarId = (short)(NumberUtil.Val( GetPar( "LugarId"), "."));
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            A27LugarSectorId = (short)(NumberUtil.Val( GetPar( "LugarSectorId"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A4LugarId, A27LugarSectorId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A1EspectaculoId = (short)(NumberUtil.Val( GetPar( "EspectaculoId"), "."));
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            A27LugarSectorId = (short)(NumberUtil.Val( GetPar( "LugarSectorId"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A1EspectaculoId, A27LugarSectorId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridespectaculo_lugarsector") == 0 )
         {
            gxnrGridespectaculo_lugarsector_newrow_invoke( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridespectaculo_espectaculofuncion") == 0 )
         {
            gxnrGridespectaculo_espectaculofuncion_newrow_invoke( ) ;
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
               AV7EspectaculoId = (short)(NumberUtil.Val( GetPar( "EspectaculoId"), "."));
               AssignAttri("", false, "AV7EspectaculoId", StringUtil.LTrimStr( (decimal)(AV7EspectaculoId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vESPECTACULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EspectaculoId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Espectaculo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEspectaculoName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridespectaculo_lugarsector_newrow_invoke( )
      {
         nRC_GXsfl_88 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_88"), "."));
         nGXsfl_88_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_88_idx"), "."));
         sGXsfl_88_idx = GetPar( "sGXsfl_88_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridespectaculo_lugarsector_newrow( ) ;
         /* End function gxnrGridespectaculo_lugarsector_newrow_invoke */
      }

      protected void gxnrGridespectaculo_espectaculofuncion_newrow_invoke( )
      {
         nRC_GXsfl_104 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_104"), "."));
         nGXsfl_104_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_104_idx"), "."));
         sGXsfl_104_idx = GetPar( "sGXsfl_104_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridespectaculo_espectaculofuncion_newrow( ) ;
         /* End function gxnrGridespectaculo_espectaculofuncion_newrow_invoke */
      }

      public espectaculo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public espectaculo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_EspectaculoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EspectaculoId = aP1_EspectaculoId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkLugarSectorEstadoSector = new GXCheckbox();
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Espectaculo", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Espectaculo.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Espectaculo.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEspectaculoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEspectaculoId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1EspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( ((edtEspectaculoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9") : context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Espectaculo.htm");
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
         GxWebStd.gx_label_element( context, edtEspectaculoName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEspectaculoName_Internalname, A2EspectaculoName, StringUtil.RTrim( context.localUtil.Format( A2EspectaculoName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Espectaculo.htm");
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
         GxWebStd.gx_label_element( context, edtEspectaculoFecha_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtEspectaculoFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtEspectaculoFecha_Internalname, context.localUtil.Format(A16EspectaculoFecha, "99/99/99"), context.localUtil.Format( A16EspectaculoFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEspectaculoFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEspectaculoFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_bitmap( context, edtEspectaculoFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtEspectaculoFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Espectaculo.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLugarId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLugarId_Internalname, "Lugar Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLugarId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A4LugarId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Espectaculo.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_4_Internalname, sImgUrl, imgprompt_4_Link, "", "", context.GetTheme( ), imgprompt_4_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Espectaculo.htm");
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
         GxWebStd.gx_single_line_edit( context, edtLugarName_Internalname, A5LugarName, StringUtil.RTrim( context.localUtil.Format( A5LugarName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLugarName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLugarName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Espectaculo.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPaisId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ",", "")), StringUtil.LTrim( ((edtPaisId_Enabled!=0) ? context.localUtil.Format( (decimal)(A3PaisId), "ZZZ9") : context.localUtil.Format( (decimal)(A3PaisId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Espectaculo.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPaisName_Internalname, A6PaisName, StringUtil.RTrim( context.localUtil.Format( A6PaisName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipoEspectaculoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipoEspectaculoId_Internalname, "Tipo Espectaculo Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipoEspectaculoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7TipoEspectaculoId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A7TipoEspectaculoId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoEspectaculoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipoEspectaculoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_Espectaculo.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_7_Internalname, sImgUrl, imgprompt_7_Link, "", "", context.GetTheme( ), imgprompt_7_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Espectaculo.htm");
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
         GxWebStd.gx_single_line_edit( context, edtTipoEspectaculoName_Internalname, A8TipoEspectaculoName, StringUtil.RTrim( context.localUtil.Format( A8TipoEspectaculoName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipoEspectaculoName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipoEspectaculoName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgEspectaculoImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Imagen", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A26EspectaculoImagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000EspectaculoImagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.PathToRelativeUrl( A26EspectaculoImagen));
         GxWebStd.gx_bitmap( context, imgEspectaculoImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgEspectaculoImagen_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", "", "", 0, A26EspectaculoImagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Espectaculo.htm");
         AssignProp("", false, imgEspectaculoImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.PathToRelativeUrl( A26EspectaculoImagen)), true);
         AssignProp("", false, imgEspectaculoImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A26EspectaculoImagen_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLugarsectortable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlelugarsector_Internalname, "Lugar Sector", "", "", lblTitlelugarsector_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridespectaculo_lugarsector( ) ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divEspectaculofunciontable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleespectaculofuncion_Internalname, "Espectaculo Funcion", "", "", lblTitleespectaculofuncion_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridespectaculo_espectaculofuncion( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Espectaculo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridespectaculo_lugarsector( )
      {
         /*  Grid Control  */
         StartGridControl88( ) ;
         nGXsfl_88_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount16 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_16 = 1;
               ScanStart0A16( ) ;
               while ( RcdFound16 != 0 )
               {
                  init_level_properties16( ) ;
                  getByPrimaryKey0A16( ) ;
                  AddRow0A16( ) ;
                  ScanNext0A16( ) ;
               }
               ScanEnd0A16( ) ;
               nBlankRcdCount16 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0A16( ) ;
            standaloneModal0A16( ) ;
            sMode16 = Gx_mode;
            while ( nGXsfl_88_idx < nRC_GXsfl_88 )
            {
               bGXsfl_88_Refreshing = true;
               ReadRow0A16( ) ;
               edtLugarSectorId_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORID_"+sGXsfl_88_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtLugarSectorName_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORNAME_"+sGXsfl_88_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtLugarSectorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorName_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtLugarSectorCantidad_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORCANTIDAD_"+sGXsfl_88_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtLugarSectorCantidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorCantidad_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               chkLugarSectorEstadoSector.Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORESTADOSECTOR_"+sGXsfl_88_idx+"Enabled"), ",", "."));
               AssignProp("", false, chkLugarSectorEstadoSector_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkLugarSectorEstadoSector.Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtLugarSectorPrecio_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORPRECIO_"+sGXsfl_88_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtLugarSectorPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtLugarSectorVendidas_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORVENDIDAS_"+sGXsfl_88_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtLugarSectorVendidas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorVendidas_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtLugarSectorDisponibles_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORDISPONIBLES_"+sGXsfl_88_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtLugarSectorDisponibles_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorDisponibles_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               imgprompt_4_Link = cgiGet( "PROMPT_27_"+sGXsfl_88_idx+"Link");
               if ( ( nRcdExists_16 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0A16( ) ;
               }
               SendRow0A16( ) ;
               bGXsfl_88_Refreshing = false;
            }
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount16 = 5;
            nRcdExists_16 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0A16( ) ;
               while ( RcdFound16 != 0 )
               {
                  sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_8816( ) ;
                  init_level_properties16( ) ;
                  standaloneNotModal0A16( ) ;
                  getByPrimaryKey0A16( ) ;
                  standaloneModal0A16( ) ;
                  AddRow0A16( ) ;
                  ScanNext0A16( ) ;
               }
               ScanEnd0A16( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode16 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx+1), 4, 0), 4, "0");
            SubsflControlProps_8816( ) ;
            InitAll0A16( ) ;
            init_level_properties16( ) ;
            nRcdExists_16 = 0;
            nIsMod_16 = 0;
            nRcdDeleted_16 = 0;
            nBlankRcdCount16 = (short)(nBlankRcdUsr16+nBlankRcdCount16);
            fRowAdded = 0;
            while ( nBlankRcdCount16 > 0 )
            {
               standaloneNotModal0A16( ) ;
               standaloneModal0A16( ) ;
               AddRow0A16( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtLugarSectorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount16 = (short)(nBlankRcdCount16-1);
            }
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridespectaculo_lugarsectorContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridespectaculo_lugarsector", Gridespectaculo_lugarsectorContainer, subGridespectaculo_lugarsector_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridespectaculo_lugarsectorContainerData", Gridespectaculo_lugarsectorContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridespectaculo_lugarsectorContainerData"+"V", Gridespectaculo_lugarsectorContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridespectaculo_lugarsectorContainerData"+"V"+"\" value='"+Gridespectaculo_lugarsectorContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void gxdraw_Gridespectaculo_espectaculofuncion( )
      {
         /*  Grid Control  */
         StartGridControl104( ) ;
         nGXsfl_104_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount18 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_18 = 1;
               ScanStart0A18( ) ;
               while ( RcdFound18 != 0 )
               {
                  init_level_properties18( ) ;
                  getByPrimaryKey0A18( ) ;
                  AddRow0A18( ) ;
                  ScanNext0A18( ) ;
               }
               ScanEnd0A18( ) ;
               nBlankRcdCount18 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0A18( ) ;
            standaloneModal0A18( ) ;
            sMode18 = Gx_mode;
            while ( nGXsfl_104_idx < nRC_GXsfl_104 )
            {
               bGXsfl_104_Refreshing = true;
               ReadRow0A18( ) ;
               edtEspectaculoFuncionId_Enabled = (int)(context.localUtil.CToN( cgiGet( "ESPECTACULOFUNCIONID_"+sGXsfl_104_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtEspectaculoFuncionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoFuncionId_Enabled), 5, 0), !bGXsfl_104_Refreshing);
               edtEspectaculoFuncionName_Enabled = (int)(context.localUtil.CToN( cgiGet( "ESPECTACULOFUNCIONNAME_"+sGXsfl_104_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtEspectaculoFuncionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoFuncionName_Enabled), 5, 0), !bGXsfl_104_Refreshing);
               edtEspectaculoFuncionPrecio_Enabled = (int)(context.localUtil.CToN( cgiGet( "ESPECTACULOFUNCIONPRECIO_"+sGXsfl_104_idx+"Enabled"), ",", "."));
               AssignProp("", false, edtEspectaculoFuncionPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoFuncionPrecio_Enabled), 5, 0), !bGXsfl_104_Refreshing);
               if ( ( nRcdExists_18 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0A18( ) ;
               }
               SendRow0A18( ) ;
               bGXsfl_104_Refreshing = false;
            }
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount18 = 5;
            nRcdExists_18 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0A18( ) ;
               while ( RcdFound18 != 0 )
               {
                  sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_10418( ) ;
                  init_level_properties18( ) ;
                  standaloneNotModal0A18( ) ;
                  getByPrimaryKey0A18( ) ;
                  standaloneModal0A18( ) ;
                  AddRow0A18( ) ;
                  ScanNext0A18( ) ;
               }
               ScanEnd0A18( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode18 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx+1), 4, 0), 4, "0");
            SubsflControlProps_10418( ) ;
            InitAll0A18( ) ;
            init_level_properties18( ) ;
            nRcdExists_18 = 0;
            nIsMod_18 = 0;
            nRcdDeleted_18 = 0;
            nBlankRcdCount18 = (short)(nBlankRcdUsr18+nBlankRcdCount18);
            fRowAdded = 0;
            while ( nBlankRcdCount18 > 0 )
            {
               standaloneNotModal0A18( ) ;
               standaloneModal0A18( ) ;
               AddRow0A18( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtEspectaculoFuncionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount18 = (short)(nBlankRcdCount18-1);
            }
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridespectaculo_espectaculofuncionContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridespectaculo_espectaculofuncion", Gridespectaculo_espectaculofuncionContainer, subGridespectaculo_espectaculofuncion_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridespectaculo_espectaculofuncionContainerData", Gridespectaculo_espectaculofuncionContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridespectaculo_espectaculofuncionContainerData"+"V", Gridespectaculo_espectaculofuncionContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridespectaculo_espectaculofuncionContainerData"+"V"+"\" value='"+Gridespectaculo_espectaculofuncionContainer.GridValuesHidden()+"'/>") ;
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
         E110A2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( "Z1EspectaculoId"), ",", "."));
               Z2EspectaculoName = cgiGet( "Z2EspectaculoName");
               Z16EspectaculoFecha = context.localUtil.CToD( cgiGet( "Z16EspectaculoFecha"), 0);
               Z4LugarId = (short)(context.localUtil.CToN( cgiGet( "Z4LugarId"), ",", "."));
               Z7TipoEspectaculoId = (short)(context.localUtil.CToN( cgiGet( "Z7TipoEspectaculoId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_88 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_88"), ",", "."));
               nRC_GXsfl_104 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_104"), ",", "."));
               N4LugarId = (short)(context.localUtil.CToN( cgiGet( "N4LugarId"), ",", "."));
               N7TipoEspectaculoId = (short)(context.localUtil.CToN( cgiGet( "N7TipoEspectaculoId"), ",", "."));
               AV7EspectaculoId = (short)(context.localUtil.CToN( cgiGet( "vESPECTACULOID"), ",", "."));
               AV11Insert_LugarId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_LUGARID"), ",", "."));
               AV12Insert_TipoEspectaculoId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_TIPOESPECTACULOID"), ",", "."));
               A40000EspectaculoImagen_GXI = cgiGet( "ESPECTACULOIMAGEN_GXI");
               AV14Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               A1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."));
               AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
               A2EspectaculoName = cgiGet( edtEspectaculoName_Internalname);
               AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
               if ( context.localUtil.VCDate( cgiGet( edtEspectaculoFecha_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Espectaculo Fecha"}), 1, "ESPECTACULOFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtEspectaculoFecha_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A16EspectaculoFecha = DateTime.MinValue;
                  AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
               }
               else
               {
                  A16EspectaculoFecha = context.localUtil.CToD( cgiGet( edtEspectaculoFecha_Internalname), 2);
                  AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtLugarId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLugarId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LUGARID");
                  AnyError = 1;
                  GX_FocusControl = edtLugarId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A4LugarId = 0;
                  AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
               }
               else
               {
                  A4LugarId = (short)(context.localUtil.CToN( cgiGet( edtLugarId_Internalname), ",", "."));
                  AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
               }
               A5LugarName = cgiGet( edtLugarName_Internalname);
               AssignAttri("", false, "A5LugarName", A5LugarName);
               A3PaisId = (short)(context.localUtil.CToN( cgiGet( edtPaisId_Internalname), ",", "."));
               AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
               A6PaisName = cgiGet( edtPaisName_Internalname);
               AssignAttri("", false, "A6PaisName", A6PaisName);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipoEspectaculoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipoEspectaculoId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPOESPECTACULOID");
                  AnyError = 1;
                  GX_FocusControl = edtTipoEspectaculoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A7TipoEspectaculoId = 0;
                  AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
               }
               else
               {
                  A7TipoEspectaculoId = (short)(context.localUtil.CToN( cgiGet( edtTipoEspectaculoId_Internalname), ",", "."));
                  AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
               }
               A8TipoEspectaculoName = cgiGet( edtTipoEspectaculoName_Internalname);
               AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
               A26EspectaculoImagen = cgiGet( imgEspectaculoImagen_Internalname);
               AssignAttri("", false, "A26EspectaculoImagen", A26EspectaculoImagen);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgEspectaculoImagen_Internalname, ref  A26EspectaculoImagen, ref  A40000EspectaculoImagen_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Espectaculo");
               A1EspectaculoId = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoId_Internalname), ",", "."));
               AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
               forbiddenHiddens.Add("EspectaculoId", context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A1EspectaculoId != Z1EspectaculoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("espectaculo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A1EspectaculoId = (short)(NumberUtil.Val( GetPar( "EspectaculoId"), "."));
                  AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
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
                     sMode15 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode15;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound15 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0A0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ESPECTACULOID");
                        AnyError = 1;
                        GX_FocusControl = edtEspectaculoId_Internalname;
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
                           E110A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120A2 ();
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
            E120A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0A15( ) ;
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
            DisableAttributes0A15( ) ;
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
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  IsConfirmed = 1;
                  AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
               }
            }
            /* Restore parent mode. */
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0A18( )
      {
         nGXsfl_104_idx = 0;
         while ( nGXsfl_104_idx < nRC_GXsfl_104 )
         {
            ReadRow0A18( ) ;
            if ( ( nRcdExists_18 != 0 ) || ( nIsMod_18 != 0 ) )
            {
               GetKey0A18( ) ;
               if ( ( nRcdExists_18 == 0 ) && ( nRcdDeleted_18 == 0 ) )
               {
                  if ( RcdFound18 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0A18( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0A18( ) ;
                        CloseExtendedTableCursors0A18( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "ESPECTACULOFUNCIONID_" + sGXsfl_104_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtEspectaculoFuncionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound18 != 0 )
                  {
                     if ( nRcdDeleted_18 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
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
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0A18( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0A18( ) ;
                              CloseExtendedTableCursors0A18( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_18 == 0 )
                     {
                        GXCCtl = "ESPECTACULOFUNCIONID_" + sGXsfl_104_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtEspectaculoFuncionId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtEspectaculoFuncionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A47EspectaculoFuncionId), 4, 0, ",", ""))) ;
            ChangePostValue( edtEspectaculoFuncionName_Internalname, A48EspectaculoFuncionName) ;
            ChangePostValue( edtEspectaculoFuncionPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A49EspectaculoFuncionPrecio), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z47EspectaculoFuncionId_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z47EspectaculoFuncionId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z48EspectaculoFuncionName_"+sGXsfl_104_idx, Z48EspectaculoFuncionName) ;
            ChangePostValue( "ZT_"+"Z49EspectaculoFuncionPrecio_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z49EspectaculoFuncionPrecio), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_18_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_18), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_18_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_18), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_18_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_18), 4, 0, ",", ""))) ;
            if ( nIsMod_18 != 0 )
            {
               ChangePostValue( "ESPECTACULOFUNCIONID_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEspectaculoFuncionId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESPECTACULOFUNCIONNAME_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEspectaculoFuncionName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESPECTACULOFUNCIONPRECIO_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEspectaculoFuncionPrecio_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void CONFIRM_0A16( )
      {
         nGXsfl_88_idx = 0;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            ReadRow0A16( ) ;
            if ( ( nRcdExists_16 != 0 ) || ( nIsMod_16 != 0 ) )
            {
               GetKey0A16( ) ;
               if ( ( nRcdExists_16 == 0 ) && ( nRcdDeleted_16 == 0 ) )
               {
                  if ( RcdFound16 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0A16( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0A16( ) ;
                        CloseExtendedTableCursors0A16( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "LUGARSECTORID_" + sGXsfl_88_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtLugarSectorId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound16 != 0 )
                  {
                     if ( nRcdDeleted_16 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
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
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0A16( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0A16( ) ;
                              CloseExtendedTableCursors0A16( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_16 == 0 )
                     {
                        GXCCtl = "LUGARSECTORID_" + sGXsfl_88_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtLugarSectorId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtLugarSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A27LugarSectorId), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorName_Internalname, A28LugarSectorName) ;
            ChangePostValue( edtLugarSectorCantidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A29LugarSectorCantidad), 4, 0, ",", ""))) ;
            ChangePostValue( chkLugarSectorEstadoSector_Internalname, StringUtil.BoolToStr( A41LugarSectorEstadoSector)) ;
            ChangePostValue( edtLugarSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorVendidas_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorDisponibles_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A38LugarSectorDisponibles), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z27LugarSectorId_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z27LugarSectorId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z41LugarSectorEstadoSector_"+sGXsfl_88_idx, StringUtil.BoolToStr( Z41LugarSectorEstadoSector)) ;
            ChangePostValue( "nRcdDeleted_16_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_16), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_16_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_16), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_16_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_16), 4, 0, ",", ""))) ;
            if ( nIsMod_16 != 0 )
            {
               ChangePostValue( "LUGARSECTORID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORNAME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORCANTIDAD_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorCantidad_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORESTADOSECTOR_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkLugarSectorEstadoSector.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORPRECIO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORVENDIDAS_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorVendidas_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORDISPONIBLES_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorDisponibles_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0A0( )
      {
      }

      protected void E110A2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_LugarId = 0;
         AssignAttri("", false, "AV11Insert_LugarId", StringUtil.LTrimStr( (decimal)(AV11Insert_LugarId), 4, 0));
         AV12Insert_TipoEspectaculoId = 0;
         AssignAttri("", false, "AV12Insert_TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(AV12Insert_TipoEspectaculoId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV14Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV15GXV1 = 1;
            AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            while ( AV15GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "LugarId") == 0 )
               {
                  AV11Insert_LugarId = (short)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_LugarId", StringUtil.LTrimStr( (decimal)(AV11Insert_LugarId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "TipoEspectaculoId") == 0 )
               {
                  AV12Insert_TipoEspectaculoId = (short)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV12Insert_TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(AV12Insert_TipoEspectaculoId), 4, 0));
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

      protected void E120A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwespectaculo.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0A15( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2EspectaculoName = T000A10_A2EspectaculoName[0];
               Z16EspectaculoFecha = T000A10_A16EspectaculoFecha[0];
               Z4LugarId = T000A10_A4LugarId[0];
               Z7TipoEspectaculoId = T000A10_A7TipoEspectaculoId[0];
            }
            else
            {
               Z2EspectaculoName = A2EspectaculoName;
               Z16EspectaculoFecha = A16EspectaculoFecha;
               Z4LugarId = A4LugarId;
               Z7TipoEspectaculoId = A7TipoEspectaculoId;
            }
         }
         if ( GX_JID == -13 )
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
         edtEspectaculoId_Enabled = 0;
         AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         imgprompt_4_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"LUGARID"+"'), id:'"+"LUGARID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_7_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0040.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TIPOESPECTACULOID"+"'), id:'"+"TIPOESPECTACULOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         edtEspectaculoId_Enabled = 0;
         AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7EspectaculoId) )
         {
            A1EspectaculoId = AV7EspectaculoId;
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_LugarId) )
         {
            edtLugarId_Enabled = 0;
            AssignProp("", false, edtLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarId_Enabled), 5, 0), true);
         }
         else
         {
            edtLugarId_Enabled = 1;
            AssignProp("", false, edtLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_TipoEspectaculoId) )
         {
            edtTipoEspectaculoId_Enabled = 0;
            AssignProp("", false, edtTipoEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoId_Enabled), 5, 0), true);
         }
         else
         {
            edtTipoEspectaculoId_Enabled = 1;
            AssignProp("", false, edtTipoEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_TipoEspectaculoId) )
         {
            A7TipoEspectaculoId = AV12Insert_TipoEspectaculoId;
            AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_LugarId) )
         {
            A4LugarId = AV11Insert_LugarId;
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
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
            AV14Pgmname = "Espectaculo";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T000A12 */
            pr_default.execute(9, new Object[] {A7TipoEspectaculoId});
            A8TipoEspectaculoName = T000A12_A8TipoEspectaculoName[0];
            AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            pr_default.close(9);
            /* Using cursor T000A11 */
            pr_default.execute(8, new Object[] {A4LugarId});
            A5LugarName = T000A11_A5LugarName[0];
            AssignAttri("", false, "A5LugarName", A5LugarName);
            A3PaisId = T000A11_A3PaisId[0];
            AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            pr_default.close(8);
            /* Using cursor T000A13 */
            pr_default.execute(10, new Object[] {A3PaisId});
            A6PaisName = T000A13_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            pr_default.close(10);
         }
      }

      protected void Load0A15( )
      {
         /* Using cursor T000A14 */
         pr_default.execute(11, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound15 = 1;
            A2EspectaculoName = T000A14_A2EspectaculoName[0];
            AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
            A16EspectaculoFecha = T000A14_A16EspectaculoFecha[0];
            AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
            A5LugarName = T000A14_A5LugarName[0];
            AssignAttri("", false, "A5LugarName", A5LugarName);
            A6PaisName = T000A14_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            A8TipoEspectaculoName = T000A14_A8TipoEspectaculoName[0];
            AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            A40000EspectaculoImagen_GXI = T000A14_A40000EspectaculoImagen_GXI[0];
            AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
            A4LugarId = T000A14_A4LugarId[0];
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            A7TipoEspectaculoId = T000A14_A7TipoEspectaculoId[0];
            AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
            A3PaisId = T000A14_A3PaisId[0];
            AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            A26EspectaculoImagen = T000A14_A26EspectaculoImagen[0];
            AssignAttri("", false, "A26EspectaculoImagen", A26EspectaculoImagen);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
            ZM0A15( -13) ;
         }
         pr_default.close(11);
         OnLoadActions0A15( ) ;
      }

      protected void OnLoadActions0A15( )
      {
         AV14Pgmname = "Espectaculo";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable0A15( )
      {
         nIsDirty_15 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV14Pgmname = "Espectaculo";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         if ( ! ( (DateTime.MinValue==A16EspectaculoFecha) || ( DateTimeUtil.ResetTime ( A16EspectaculoFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Espectaculo Fecha fuera de rango", "OutOfRange", 1, "ESPECTACULOFECHA");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000A11 */
         pr_default.execute(8, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
            GX_FocusControl = edtLugarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A5LugarName = T000A11_A5LugarName[0];
         AssignAttri("", false, "A5LugarName", A5LugarName);
         A3PaisId = T000A11_A3PaisId[0];
         AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
         pr_default.close(8);
         /* Using cursor T000A13 */
         pr_default.execute(10, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = T000A13_A6PaisName[0];
         AssignAttri("", false, "A6PaisName", A6PaisName);
         pr_default.close(10);
         /* Using cursor T000A12 */
         pr_default.execute(9, new Object[] {A7TipoEspectaculoId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtTipoEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8TipoEspectaculoName = T000A12_A8TipoEspectaculoName[0];
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
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

      protected void gxLoad_14( short A4LugarId )
      {
         /* Using cursor T000A15 */
         pr_default.execute(12, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
            GX_FocusControl = edtLugarId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A5LugarName = T000A15_A5LugarName[0];
         AssignAttri("", false, "A5LugarName", A5LugarName);
         A3PaisId = T000A15_A3PaisId[0];
         AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A5LugarName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ".", "")))+"\"") ;
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
         /* Using cursor T000A16 */
         pr_default.execute(13, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = T000A16_A6PaisName[0];
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

      protected void gxLoad_15( short A7TipoEspectaculoId )
      {
         /* Using cursor T000A17 */
         pr_default.execute(14, new Object[] {A7TipoEspectaculoId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtTipoEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A8TipoEspectaculoName = T000A17_A8TipoEspectaculoName[0];
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A8TipoEspectaculoName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey0A15( )
      {
         /* Using cursor T000A18 */
         pr_default.execute(15, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000A10 */
         pr_default.execute(7, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            ZM0A15( 13) ;
            RcdFound15 = 1;
            A1EspectaculoId = T000A10_A1EspectaculoId[0];
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            A2EspectaculoName = T000A10_A2EspectaculoName[0];
            AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
            A16EspectaculoFecha = T000A10_A16EspectaculoFecha[0];
            AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
            A40000EspectaculoImagen_GXI = T000A10_A40000EspectaculoImagen_GXI[0];
            AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
            A4LugarId = T000A10_A4LugarId[0];
            AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
            A7TipoEspectaculoId = T000A10_A7TipoEspectaculoId[0];
            AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
            A26EspectaculoImagen = T000A10_A26EspectaculoImagen[0];
            AssignAttri("", false, "A26EspectaculoImagen", A26EspectaculoImagen);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
            AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
            Z1EspectaculoId = A1EspectaculoId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0A15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0A15( ) ;
            }
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0A15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(7);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A15( ) ;
         if ( RcdFound15 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound15 = 0;
         /* Using cursor T000A19 */
         pr_default.execute(16, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( T000A19_A1EspectaculoId[0] < A1EspectaculoId ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( T000A19_A1EspectaculoId[0] > A1EspectaculoId ) ) )
            {
               A1EspectaculoId = T000A19_A1EspectaculoId[0];
               AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void move_previous( )
      {
         RcdFound15 = 0;
         /* Using cursor T000A20 */
         pr_default.execute(17, new Object[] {A1EspectaculoId});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( T000A20_A1EspectaculoId[0] > A1EspectaculoId ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( T000A20_A1EspectaculoId[0] < A1EspectaculoId ) ) )
            {
               A1EspectaculoId = T000A20_A1EspectaculoId[0];
               AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(17);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0A15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEspectaculoName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0A15( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A1EspectaculoId != Z1EspectaculoId )
               {
                  A1EspectaculoId = Z1EspectaculoId;
                  AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ESPECTACULOID");
                  AnyError = 1;
                  GX_FocusControl = edtEspectaculoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEspectaculoName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0A15( ) ;
                  GX_FocusControl = edtEspectaculoName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A1EspectaculoId != Z1EspectaculoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtEspectaculoName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0A15( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ESPECTACULOID");
                     AnyError = 1;
                     GX_FocusControl = edtEspectaculoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEspectaculoName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0A15( ) ;
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
         if ( A1EspectaculoId != Z1EspectaculoId )
         {
            A1EspectaculoId = Z1EspectaculoId;
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtEspectaculoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEspectaculoName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0A15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000A9 */
            pr_default.execute(6, new Object[] {A1EspectaculoId});
            if ( (pr_default.getStatus(6) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Espectaculo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(6) == 101) || ( StringUtil.StrCmp(Z2EspectaculoName, T000A9_A2EspectaculoName[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z16EspectaculoFecha ) != DateTimeUtil.ResetTime ( T000A9_A16EspectaculoFecha[0] ) ) || ( Z4LugarId != T000A9_A4LugarId[0] ) || ( Z7TipoEspectaculoId != T000A9_A7TipoEspectaculoId[0] ) )
            {
               if ( StringUtil.StrCmp(Z2EspectaculoName, T000A9_A2EspectaculoName[0]) != 0 )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"EspectaculoName");
                  GXUtil.WriteLogRaw("Old: ",Z2EspectaculoName);
                  GXUtil.WriteLogRaw("Current: ",T000A9_A2EspectaculoName[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z16EspectaculoFecha ) != DateTimeUtil.ResetTime ( T000A9_A16EspectaculoFecha[0] ) )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"EspectaculoFecha");
                  GXUtil.WriteLogRaw("Old: ",Z16EspectaculoFecha);
                  GXUtil.WriteLogRaw("Current: ",T000A9_A16EspectaculoFecha[0]);
               }
               if ( Z4LugarId != T000A9_A4LugarId[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"LugarId");
                  GXUtil.WriteLogRaw("Old: ",Z4LugarId);
                  GXUtil.WriteLogRaw("Current: ",T000A9_A4LugarId[0]);
               }
               if ( Z7TipoEspectaculoId != T000A9_A7TipoEspectaculoId[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"TipoEspectaculoId");
                  GXUtil.WriteLogRaw("Old: ",Z7TipoEspectaculoId);
                  GXUtil.WriteLogRaw("Current: ",T000A9_A7TipoEspectaculoId[0]);
               }
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
                     /* Using cursor T000A21 */
                     pr_default.execute(18, new Object[] {A2EspectaculoName, A16EspectaculoFecha, A26EspectaculoImagen, A40000EspectaculoImagen_GXI, A4LugarId, A7TipoEspectaculoId});
                     A1EspectaculoId = T000A21_A1EspectaculoId[0];
                     AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
                     pr_default.close(18);
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
                              ResetCaption0A0( ) ;
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
                     /* Using cursor T000A22 */
                     pr_default.execute(19, new Object[] {A2EspectaculoName, A16EspectaculoFecha, A4LugarId, A7TipoEspectaculoId, A1EspectaculoId});
                     pr_default.close(19);
                     dsDefault.SmartCacheProvider.SetUpdated("Espectaculo");
                     if ( (pr_default.getStatus(19) == 103) )
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
            EndLevel0A15( ) ;
         }
         CloseExtendedTableCursors0A15( ) ;
      }

      protected void DeferredUpdate0A15( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000A23 */
            pr_default.execute(20, new Object[] {A26EspectaculoImagen, A40000EspectaculoImagen_GXI, A1EspectaculoId});
            pr_default.close(20);
            dsDefault.SmartCacheProvider.SetUpdated("Espectaculo");
         }
      }

      protected void delete( )
      {
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
                  ScanStart0A18( ) ;
                  while ( RcdFound18 != 0 )
                  {
                     getByPrimaryKey0A18( ) ;
                     Delete0A18( ) ;
                     ScanNext0A18( ) ;
                  }
                  ScanEnd0A18( ) ;
                  ScanStart0A16( ) ;
                  while ( RcdFound16 != 0 )
                  {
                     getByPrimaryKey0A16( ) ;
                     Delete0A16( ) ;
                     ScanNext0A16( ) ;
                  }
                  ScanEnd0A16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A24 */
                     pr_default.execute(21, new Object[] {A1EspectaculoId});
                     pr_default.close(21);
                     dsDefault.SmartCacheProvider.SetUpdated("Espectaculo");
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A15( ) ;
         Gx_mode = sMode15;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "Espectaculo";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T000A25 */
            pr_default.execute(22, new Object[] {A4LugarId});
            A5LugarName = T000A25_A5LugarName[0];
            AssignAttri("", false, "A5LugarName", A5LugarName);
            A3PaisId = T000A25_A3PaisId[0];
            AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
            pr_default.close(22);
            /* Using cursor T000A26 */
            pr_default.execute(23, new Object[] {A3PaisId});
            A6PaisName = T000A26_A6PaisName[0];
            AssignAttri("", false, "A6PaisName", A6PaisName);
            pr_default.close(23);
            /* Using cursor T000A27 */
            pr_default.execute(24, new Object[] {A7TipoEspectaculoId});
            A8TipoEspectaculoName = T000A27_A8TipoEspectaculoName[0];
            AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
            pr_default.close(24);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000A28 */
            pr_default.execute(25, new Object[] {A1EspectaculoId});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Entrada"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T000A29 */
            pr_default.execute(26, new Object[] {A1EspectaculoId});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Entrada"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
         }
      }

      protected void ProcessNestedLevel0A16( )
      {
         nGXsfl_88_idx = 0;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            ReadRow0A16( ) ;
            if ( ( nRcdExists_16 != 0 ) || ( nIsMod_16 != 0 ) )
            {
               standaloneNotModal0A16( ) ;
               GetKey0A16( ) ;
               if ( ( nRcdExists_16 == 0 ) && ( nRcdDeleted_16 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0A16( ) ;
               }
               else
               {
                  if ( RcdFound16 != 0 )
                  {
                     if ( ( nRcdDeleted_16 != 0 ) && ( nRcdExists_16 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0A16( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_16 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0A16( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_16 == 0 )
                     {
                        GXCCtl = "LUGARSECTORID_" + sGXsfl_88_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtLugarSectorId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtLugarSectorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A27LugarSectorId), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorName_Internalname, A28LugarSectorName) ;
            ChangePostValue( edtLugarSectorCantidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A29LugarSectorCantidad), 4, 0, ",", ""))) ;
            ChangePostValue( chkLugarSectorEstadoSector_Internalname, StringUtil.BoolToStr( A41LugarSectorEstadoSector)) ;
            ChangePostValue( edtLugarSectorPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorVendidas_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ",", ""))) ;
            ChangePostValue( edtLugarSectorDisponibles_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A38LugarSectorDisponibles), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z27LugarSectorId_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z27LugarSectorId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z41LugarSectorEstadoSector_"+sGXsfl_88_idx, StringUtil.BoolToStr( Z41LugarSectorEstadoSector)) ;
            ChangePostValue( "nRcdDeleted_16_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_16), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_16_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_16), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_16_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_16), 4, 0, ",", ""))) ;
            if ( nIsMod_16 != 0 )
            {
               ChangePostValue( "LUGARSECTORID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORNAME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORCANTIDAD_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorCantidad_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORESTADOSECTOR_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkLugarSectorEstadoSector.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORPRECIO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORVENDIDAS_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorVendidas_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "LUGARSECTORDISPONIBLES_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorDisponibles_Enabled), 5, 0, ".", ""))) ;
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
         nRcdDeleted_16 = 0;
      }

      protected void ProcessNestedLevel0A18( )
      {
         nGXsfl_104_idx = 0;
         while ( nGXsfl_104_idx < nRC_GXsfl_104 )
         {
            ReadRow0A18( ) ;
            if ( ( nRcdExists_18 != 0 ) || ( nIsMod_18 != 0 ) )
            {
               standaloneNotModal0A18( ) ;
               GetKey0A18( ) ;
               if ( ( nRcdExists_18 == 0 ) && ( nRcdDeleted_18 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0A18( ) ;
               }
               else
               {
                  if ( RcdFound18 != 0 )
                  {
                     if ( ( nRcdDeleted_18 != 0 ) && ( nRcdExists_18 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0A18( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_18 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0A18( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_18 == 0 )
                     {
                        GXCCtl = "ESPECTACULOFUNCIONID_" + sGXsfl_104_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtEspectaculoFuncionId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtEspectaculoFuncionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A47EspectaculoFuncionId), 4, 0, ",", ""))) ;
            ChangePostValue( edtEspectaculoFuncionName_Internalname, A48EspectaculoFuncionName) ;
            ChangePostValue( edtEspectaculoFuncionPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A49EspectaculoFuncionPrecio), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z47EspectaculoFuncionId_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z47EspectaculoFuncionId), 4, 0, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z48EspectaculoFuncionName_"+sGXsfl_104_idx, Z48EspectaculoFuncionName) ;
            ChangePostValue( "ZT_"+"Z49EspectaculoFuncionPrecio_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z49EspectaculoFuncionPrecio), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdDeleted_18_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_18), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_18_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_18), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_18_"+sGXsfl_104_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_18), 4, 0, ",", ""))) ;
            if ( nIsMod_18 != 0 )
            {
               ChangePostValue( "ESPECTACULOFUNCIONID_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEspectaculoFuncionId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESPECTACULOFUNCIONNAME_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEspectaculoFuncionName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "ESPECTACULOFUNCIONPRECIO_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEspectaculoFuncionPrecio_Enabled), 5, 0, ".", ""))) ;
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
         nRcdDeleted_18 = 0;
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
         AssignAttri("", false, "Gx_mode", Gx_mode);
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
            pr_default.close(7);
            pr_default.close(3);
            pr_default.close(2);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(22);
            pr_default.close(24);
            pr_default.close(23);
            pr_default.close(4);
            pr_default.close(5);
            context.CommitDataStores("espectaculo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(7);
            pr_default.close(3);
            pr_default.close(2);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(22);
            pr_default.close(24);
            pr_default.close(23);
            pr_default.close(4);
            pr_default.close(5);
            context.RollbackDataStores("espectaculo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0A15( )
      {
         /* Scan By routine */
         /* Using cursor T000A30 */
         pr_default.execute(27);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound15 = 1;
            A1EspectaculoId = T000A30_A1EspectaculoId[0];
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A15( )
      {
         /* Scan next routine */
         pr_default.readNext(27);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(27) != 101) )
         {
            RcdFound15 = 1;
            A1EspectaculoId = T000A30_A1EspectaculoId[0];
            AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
         }
      }

      protected void ScanEnd0A15( )
      {
         pr_default.close(27);
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
         edtEspectaculoId_Enabled = 0;
         AssignProp("", false, edtEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoId_Enabled), 5, 0), true);
         edtEspectaculoName_Enabled = 0;
         AssignProp("", false, edtEspectaculoName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoName_Enabled), 5, 0), true);
         edtEspectaculoFecha_Enabled = 0;
         AssignProp("", false, edtEspectaculoFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoFecha_Enabled), 5, 0), true);
         edtLugarId_Enabled = 0;
         AssignProp("", false, edtLugarId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarId_Enabled), 5, 0), true);
         edtLugarName_Enabled = 0;
         AssignProp("", false, edtLugarName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarName_Enabled), 5, 0), true);
         edtPaisId_Enabled = 0;
         AssignProp("", false, edtPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisId_Enabled), 5, 0), true);
         edtPaisName_Enabled = 0;
         AssignProp("", false, edtPaisName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisName_Enabled), 5, 0), true);
         edtTipoEspectaculoId_Enabled = 0;
         AssignProp("", false, edtTipoEspectaculoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoId_Enabled), 5, 0), true);
         edtTipoEspectaculoName_Enabled = 0;
         AssignProp("", false, edtTipoEspectaculoName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipoEspectaculoName_Enabled), 5, 0), true);
         imgEspectaculoImagen_Enabled = 0;
         AssignProp("", false, imgEspectaculoImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgEspectaculoImagen_Enabled), 5, 0), true);
      }

      protected void ZM0A16( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z41LugarSectorEstadoSector = T000A5_A41LugarSectorEstadoSector[0];
            }
            else
            {
               Z41LugarSectorEstadoSector = A41LugarSectorEstadoSector;
            }
         }
         if ( GX_JID == -17 )
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
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtLugarSectorId_Enabled = 0;
            AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         }
         else
         {
            edtLugarSectorId_Enabled = 1;
            AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         }
      }

      protected void Load0A16( )
      {
         /* Using cursor T000A32 */
         pr_default.execute(28, new Object[] {A4LugarId, A1EspectaculoId, A27LugarSectorId});
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound16 = 1;
            A28LugarSectorName = T000A32_A28LugarSectorName[0];
            A29LugarSectorCantidad = T000A32_A29LugarSectorCantidad[0];
            A41LugarSectorEstadoSector = T000A32_A41LugarSectorEstadoSector[0];
            A30LugarSectorPrecio = T000A32_A30LugarSectorPrecio[0];
            A37LugarSectorVendidas = T000A32_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = T000A32_n37LugarSectorVendidas[0];
            ZM0A16( -17) ;
         }
         pr_default.close(28);
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
         /* Using cursor T000A6 */
         pr_default.execute(4, new Object[] {A4LugarId, A27LugarSectorId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GXCCtl = "LUGARSECTORID_" + sGXsfl_88_idx;
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A28LugarSectorName = T000A6_A28LugarSectorName[0];
         A29LugarSectorCantidad = T000A6_A29LugarSectorCantidad[0];
         A30LugarSectorPrecio = T000A6_A30LugarSectorPrecio[0];
         pr_default.close(4);
         /* Using cursor T000A8 */
         pr_default.execute(5, new Object[] {A1EspectaculoId, A27LugarSectorId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A37LugarSectorVendidas = T000A8_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = T000A8_n37LugarSectorVendidas[0];
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

      protected void gxLoad_18( short A4LugarId ,
                                short A27LugarSectorId )
      {
         /* Using cursor T000A33 */
         pr_default.execute(29, new Object[] {A4LugarId, A27LugarSectorId});
         if ( (pr_default.getStatus(29) == 101) )
         {
            GXCCtl = "LUGARSECTORID_" + sGXsfl_88_idx;
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A28LugarSectorName = T000A33_A28LugarSectorName[0];
         A29LugarSectorCantidad = T000A33_A29LugarSectorCantidad[0];
         A30LugarSectorPrecio = T000A33_A30LugarSectorPrecio[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A28LugarSectorName)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A29LugarSectorCantidad), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(29) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(29);
      }

      protected void gxLoad_19( short A1EspectaculoId ,
                                short A27LugarSectorId )
      {
         /* Using cursor T000A35 */
         pr_default.execute(30, new Object[] {A1EspectaculoId, A27LugarSectorId});
         if ( (pr_default.getStatus(30) != 101) )
         {
            A37LugarSectorVendidas = T000A35_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = T000A35_n37LugarSectorVendidas[0];
         }
         else
         {
            A37LugarSectorVendidas = 0;
            n37LugarSectorVendidas = false;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(30) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(30);
      }

      protected void GetKey0A16( )
      {
         /* Using cursor T000A36 */
         pr_default.execute(31, new Object[] {A1EspectaculoId, A27LugarSectorId});
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(31);
      }

      protected void getByPrimaryKey0A16( )
      {
         /* Using cursor T000A5 */
         pr_default.execute(3, new Object[] {A1EspectaculoId, A27LugarSectorId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0A16( 17) ;
            RcdFound16 = 1;
            InitializeNonKey0A16( ) ;
            A41LugarSectorEstadoSector = T000A5_A41LugarSectorEstadoSector[0];
            A27LugarSectorId = T000A5_A27LugarSectorId[0];
            Z1EspectaculoId = A1EspectaculoId;
            Z27LugarSectorId = A27LugarSectorId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0A16( ) ;
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0A16( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0A16( ) ;
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
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
            /* Using cursor T000A4 */
            pr_default.execute(2, new Object[] {A1EspectaculoId, A27LugarSectorId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EspectaculoLugarSector"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( Z41LugarSectorEstadoSector != T000A4_A41LugarSectorEstadoSector[0] ) )
            {
               if ( Z41LugarSectorEstadoSector != T000A4_A41LugarSectorEstadoSector[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"LugarSectorEstadoSector");
                  GXUtil.WriteLogRaw("Old: ",Z41LugarSectorEstadoSector);
                  GXUtil.WriteLogRaw("Current: ",T000A4_A41LugarSectorEstadoSector[0]);
               }
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
                     /* Using cursor T000A37 */
                     pr_default.execute(32, new Object[] {A1EspectaculoId, A41LugarSectorEstadoSector, A27LugarSectorId});
                     pr_default.close(32);
                     dsDefault.SmartCacheProvider.SetUpdated("EspectaculoLugarSector");
                     if ( (pr_default.getStatus(32) == 1) )
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
         if ( ( nIsMod_16 != 0 ) || ( nIsDirty_16 != 0 ) )
         {
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
                        /* Using cursor T000A38 */
                        pr_default.execute(33, new Object[] {A41LugarSectorEstadoSector, A1EspectaculoId, A27LugarSectorId});
                        pr_default.close(33);
                        dsDefault.SmartCacheProvider.SetUpdated("EspectaculoLugarSector");
                        if ( (pr_default.getStatus(33) == 103) )
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
         }
         CloseExtendedTableCursors0A16( ) ;
      }

      protected void DeferredUpdate0A16( )
      {
      }

      protected void Delete0A16( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
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
                  /* Using cursor T000A39 */
                  pr_default.execute(34, new Object[] {A1EspectaculoId, A27LugarSectorId});
                  pr_default.close(34);
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
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A16( ) ;
         Gx_mode = sMode16;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A16( )
      {
         standaloneModal0A16( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000A40 */
            pr_default.execute(35, new Object[] {A4LugarId, A27LugarSectorId});
            A28LugarSectorName = T000A40_A28LugarSectorName[0];
            A29LugarSectorCantidad = T000A40_A29LugarSectorCantidad[0];
            A30LugarSectorPrecio = T000A40_A30LugarSectorPrecio[0];
            pr_default.close(35);
            /* Using cursor T000A42 */
            pr_default.execute(36, new Object[] {A1EspectaculoId, A27LugarSectorId});
            if ( (pr_default.getStatus(36) != 101) )
            {
               A37LugarSectorVendidas = T000A42_A37LugarSectorVendidas[0];
               n37LugarSectorVendidas = T000A42_n37LugarSectorVendidas[0];
            }
            else
            {
               A37LugarSectorVendidas = 0;
               n37LugarSectorVendidas = false;
            }
            pr_default.close(36);
            A38LugarSectorDisponibles = (short)(A29LugarSectorCantidad-A37LugarSectorVendidas);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000A43 */
            pr_default.execute(37, new Object[] {A1EspectaculoId, A27LugarSectorId});
            if ( (pr_default.getStatus(37) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Invitacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(37);
            /* Using cursor T000A44 */
            pr_default.execute(38, new Object[] {A1EspectaculoId, A27LugarSectorId});
            if ( (pr_default.getStatus(38) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Entrada"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(38);
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

      public void ScanStart0A16( )
      {
         /* Scan By routine */
         /* Using cursor T000A45 */
         pr_default.execute(39, new Object[] {A1EspectaculoId});
         RcdFound16 = 0;
         if ( (pr_default.getStatus(39) != 101) )
         {
            RcdFound16 = 1;
            A27LugarSectorId = T000A45_A27LugarSectorId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A16( )
      {
         /* Scan next routine */
         pr_default.readNext(39);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(39) != 101) )
         {
            RcdFound16 = 1;
            A27LugarSectorId = T000A45_A27LugarSectorId[0];
         }
      }

      protected void ScanEnd0A16( )
      {
         pr_default.close(39);
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
         edtLugarSectorId_Enabled = 0;
         AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtLugarSectorName_Enabled = 0;
         AssignProp("", false, edtLugarSectorName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorName_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtLugarSectorCantidad_Enabled = 0;
         AssignProp("", false, edtLugarSectorCantidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorCantidad_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         chkLugarSectorEstadoSector.Enabled = 0;
         AssignProp("", false, chkLugarSectorEstadoSector_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkLugarSectorEstadoSector.Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtLugarSectorPrecio_Enabled = 0;
         AssignProp("", false, edtLugarSectorPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtLugarSectorVendidas_Enabled = 0;
         AssignProp("", false, edtLugarSectorVendidas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorVendidas_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtLugarSectorDisponibles_Enabled = 0;
         AssignProp("", false, edtLugarSectorDisponibles_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorDisponibles_Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void send_integrity_lvl_hashes0A16( )
      {
      }

      protected void ZM0A18( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z48EspectaculoFuncionName = T000A3_A48EspectaculoFuncionName[0];
               Z49EspectaculoFuncionPrecio = T000A3_A49EspectaculoFuncionPrecio[0];
            }
            else
            {
               Z48EspectaculoFuncionName = A48EspectaculoFuncionName;
               Z49EspectaculoFuncionPrecio = A49EspectaculoFuncionPrecio;
            }
         }
         if ( GX_JID == -20 )
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
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtEspectaculoFuncionId_Enabled = 0;
            AssignProp("", false, edtEspectaculoFuncionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoFuncionId_Enabled), 5, 0), !bGXsfl_104_Refreshing);
         }
         else
         {
            edtEspectaculoFuncionId_Enabled = 1;
            AssignProp("", false, edtEspectaculoFuncionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoFuncionId_Enabled), 5, 0), !bGXsfl_104_Refreshing);
         }
      }

      protected void Load0A18( )
      {
         /* Using cursor T000A46 */
         pr_default.execute(40, new Object[] {A1EspectaculoId, A47EspectaculoFuncionId});
         if ( (pr_default.getStatus(40) != 101) )
         {
            RcdFound18 = 1;
            A48EspectaculoFuncionName = T000A46_A48EspectaculoFuncionName[0];
            A49EspectaculoFuncionPrecio = T000A46_A49EspectaculoFuncionPrecio[0];
            ZM0A18( -20) ;
         }
         pr_default.close(40);
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
      }

      protected void CloseExtendedTableCursors0A18( )
      {
      }

      protected void enableDisable0A18( )
      {
      }

      protected void GetKey0A18( )
      {
         /* Using cursor T000A47 */
         pr_default.execute(41, new Object[] {A1EspectaculoId, A47EspectaculoFuncionId});
         if ( (pr_default.getStatus(41) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(41);
      }

      protected void getByPrimaryKey0A18( )
      {
         /* Using cursor T000A3 */
         pr_default.execute(1, new Object[] {A1EspectaculoId, A47EspectaculoFuncionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A18( 20) ;
            RcdFound18 = 1;
            InitializeNonKey0A18( ) ;
            A47EspectaculoFuncionId = T000A3_A47EspectaculoFuncionId[0];
            A48EspectaculoFuncionName = T000A3_A48EspectaculoFuncionName[0];
            A49EspectaculoFuncionPrecio = T000A3_A49EspectaculoFuncionPrecio[0];
            Z1EspectaculoId = A1EspectaculoId;
            Z47EspectaculoFuncionId = A47EspectaculoFuncionId;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0A18( ) ;
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0A18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0A18( ) ;
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
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
            /* Using cursor T000A2 */
            pr_default.execute(0, new Object[] {A1EspectaculoId, A47EspectaculoFuncionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EspectaculoFuncion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z48EspectaculoFuncionName, T000A2_A48EspectaculoFuncionName[0]) != 0 ) || ( Z49EspectaculoFuncionPrecio != T000A2_A49EspectaculoFuncionPrecio[0] ) )
            {
               if ( StringUtil.StrCmp(Z48EspectaculoFuncionName, T000A2_A48EspectaculoFuncionName[0]) != 0 )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"EspectaculoFuncionName");
                  GXUtil.WriteLogRaw("Old: ",Z48EspectaculoFuncionName);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A48EspectaculoFuncionName[0]);
               }
               if ( Z49EspectaculoFuncionPrecio != T000A2_A49EspectaculoFuncionPrecio[0] )
               {
                  GXUtil.WriteLog("espectaculo:[seudo value changed for attri]"+"EspectaculoFuncionPrecio");
                  GXUtil.WriteLogRaw("Old: ",Z49EspectaculoFuncionPrecio);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A49EspectaculoFuncionPrecio[0]);
               }
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
                     /* Using cursor T000A48 */
                     pr_default.execute(42, new Object[] {A1EspectaculoId, A47EspectaculoFuncionId, A48EspectaculoFuncionName, A49EspectaculoFuncionPrecio});
                     pr_default.close(42);
                     dsDefault.SmartCacheProvider.SetUpdated("EspectaculoFuncion");
                     if ( (pr_default.getStatus(42) == 1) )
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
         if ( ( nIsMod_18 != 0 ) || ( nIsDirty_18 != 0 ) )
         {
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
                        /* Using cursor T000A49 */
                        pr_default.execute(43, new Object[] {A48EspectaculoFuncionName, A49EspectaculoFuncionPrecio, A1EspectaculoId, A47EspectaculoFuncionId});
                        pr_default.close(43);
                        dsDefault.SmartCacheProvider.SetUpdated("EspectaculoFuncion");
                        if ( (pr_default.getStatus(43) == 103) )
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
         }
         CloseExtendedTableCursors0A18( ) ;
      }

      protected void DeferredUpdate0A18( )
      {
      }

      protected void Delete0A18( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
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
                  /* Using cursor T000A50 */
                  pr_default.execute(44, new Object[] {A1EspectaculoId, A47EspectaculoFuncionId});
                  pr_default.close(44);
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
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A18( ) ;
         Gx_mode = sMode18;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A18( )
      {
         standaloneModal0A18( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000A51 */
            pr_default.execute(45, new Object[] {A1EspectaculoId, A47EspectaculoFuncionId});
            if ( (pr_default.getStatus(45) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Invitacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(45);
            /* Using cursor T000A52 */
            pr_default.execute(46, new Object[] {A1EspectaculoId, A47EspectaculoFuncionId});
            if ( (pr_default.getStatus(46) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Entrada"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(46);
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

      public void ScanStart0A18( )
      {
         /* Scan By routine */
         /* Using cursor T000A53 */
         pr_default.execute(47, new Object[] {A1EspectaculoId});
         RcdFound18 = 0;
         if ( (pr_default.getStatus(47) != 101) )
         {
            RcdFound18 = 1;
            A47EspectaculoFuncionId = T000A53_A47EspectaculoFuncionId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A18( )
      {
         /* Scan next routine */
         pr_default.readNext(47);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(47) != 101) )
         {
            RcdFound18 = 1;
            A47EspectaculoFuncionId = T000A53_A47EspectaculoFuncionId[0];
         }
      }

      protected void ScanEnd0A18( )
      {
         pr_default.close(47);
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
         edtEspectaculoFuncionId_Enabled = 0;
         AssignProp("", false, edtEspectaculoFuncionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoFuncionId_Enabled), 5, 0), !bGXsfl_104_Refreshing);
         edtEspectaculoFuncionName_Enabled = 0;
         AssignProp("", false, edtEspectaculoFuncionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoFuncionName_Enabled), 5, 0), !bGXsfl_104_Refreshing);
         edtEspectaculoFuncionPrecio_Enabled = 0;
         AssignProp("", false, edtEspectaculoFuncionPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoFuncionPrecio_Enabled), 5, 0), !bGXsfl_104_Refreshing);
      }

      protected void send_integrity_lvl_hashes0A18( )
      {
      }

      protected void send_integrity_lvl_hashes0A15( )
      {
      }

      protected void SubsflControlProps_8816( )
      {
         edtLugarSectorId_Internalname = "LUGARSECTORID_"+sGXsfl_88_idx;
         imgprompt_27_Internalname = "PROMPT_27_"+sGXsfl_88_idx;
         edtLugarSectorName_Internalname = "LUGARSECTORNAME_"+sGXsfl_88_idx;
         edtLugarSectorCantidad_Internalname = "LUGARSECTORCANTIDAD_"+sGXsfl_88_idx;
         chkLugarSectorEstadoSector_Internalname = "LUGARSECTORESTADOSECTOR_"+sGXsfl_88_idx;
         edtLugarSectorPrecio_Internalname = "LUGARSECTORPRECIO_"+sGXsfl_88_idx;
         edtLugarSectorVendidas_Internalname = "LUGARSECTORVENDIDAS_"+sGXsfl_88_idx;
         edtLugarSectorDisponibles_Internalname = "LUGARSECTORDISPONIBLES_"+sGXsfl_88_idx;
      }

      protected void SubsflControlProps_fel_8816( )
      {
         edtLugarSectorId_Internalname = "LUGARSECTORID_"+sGXsfl_88_fel_idx;
         imgprompt_27_Internalname = "PROMPT_27_"+sGXsfl_88_fel_idx;
         edtLugarSectorName_Internalname = "LUGARSECTORNAME_"+sGXsfl_88_fel_idx;
         edtLugarSectorCantidad_Internalname = "LUGARSECTORCANTIDAD_"+sGXsfl_88_fel_idx;
         chkLugarSectorEstadoSector_Internalname = "LUGARSECTORESTADOSECTOR_"+sGXsfl_88_fel_idx;
         edtLugarSectorPrecio_Internalname = "LUGARSECTORPRECIO_"+sGXsfl_88_fel_idx;
         edtLugarSectorVendidas_Internalname = "LUGARSECTORVENDIDAS_"+sGXsfl_88_fel_idx;
         edtLugarSectorDisponibles_Internalname = "LUGARSECTORDISPONIBLES_"+sGXsfl_88_fel_idx;
      }

      protected void AddRow0A16( )
      {
         nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8816( ) ;
         SendRow0A16( ) ;
      }

      protected void SendRow0A16( )
      {
         Gridespectaculo_lugarsectorRow = GXWebRow.GetNew(context);
         if ( subGridespectaculo_lugarsector_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridespectaculo_lugarsector_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridespectaculo_lugarsector_Class, "") != 0 )
            {
               subGridespectaculo_lugarsector_Linesclass = subGridespectaculo_lugarsector_Class+"Odd";
            }
         }
         else if ( subGridespectaculo_lugarsector_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridespectaculo_lugarsector_Backstyle = 0;
            subGridespectaculo_lugarsector_Backcolor = subGridespectaculo_lugarsector_Allbackcolor;
            if ( StringUtil.StrCmp(subGridespectaculo_lugarsector_Class, "") != 0 )
            {
               subGridespectaculo_lugarsector_Linesclass = subGridespectaculo_lugarsector_Class+"Uniform";
            }
         }
         else if ( subGridespectaculo_lugarsector_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridespectaculo_lugarsector_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridespectaculo_lugarsector_Class, "") != 0 )
            {
               subGridespectaculo_lugarsector_Linesclass = subGridespectaculo_lugarsector_Class+"Odd";
            }
            subGridespectaculo_lugarsector_Backcolor = (int)(0x0);
         }
         else if ( subGridespectaculo_lugarsector_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridespectaculo_lugarsector_Backstyle = 1;
            if ( ((int)((nGXsfl_88_idx) % (2))) == 0 )
            {
               subGridespectaculo_lugarsector_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridespectaculo_lugarsector_Class, "") != 0 )
               {
                  subGridespectaculo_lugarsector_Linesclass = subGridespectaculo_lugarsector_Class+"Even";
               }
            }
            else
            {
               subGridespectaculo_lugarsector_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridespectaculo_lugarsector_Class, "") != 0 )
               {
                  subGridespectaculo_lugarsector_Linesclass = subGridespectaculo_lugarsector_Class+"Odd";
               }
            }
         }
         imgprompt_27_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00b1.aspx"+"',["+"{Ctrl:gx.dom.el('"+"LUGARID"+"'), id:'"+"LUGARID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+"LUGARSECTORID_"+sGXsfl_88_idx+"'), id:'"+"LUGARSECTORID_"+sGXsfl_88_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_16_"+sGXsfl_88_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridespectaculo_lugarsectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarSectorId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A27LugarSectorId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A27LugarSectorId), "ZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,89);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarSectorId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtLugarSectorId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)88,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridespectaculo_lugarsectorRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_27_Internalname,(string)sImgUrl,(string)imgprompt_27_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_27_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridespectaculo_lugarsectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarSectorName_Internalname,(string)A28LugarSectorName,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarSectorName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtLugarSectorName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)88,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridespectaculo_lugarsectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarSectorCantidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A29LugarSectorCantidad), 4, 0, ",", "")),StringUtil.LTrim( ((edtLugarSectorCantidad_Enabled!=0) ? context.localUtil.Format( (decimal)(A29LugarSectorCantidad), "ZZZ9") : context.localUtil.Format( (decimal)(A29LugarSectorCantidad), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarSectorCantidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtLugarSectorCantidad_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)88,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Check box */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 92,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "LUGARSECTORESTADOSECTOR_" + sGXsfl_88_idx;
         chkLugarSectorEstadoSector.Name = GXCCtl;
         chkLugarSectorEstadoSector.WebTags = "";
         chkLugarSectorEstadoSector.Caption = "";
         AssignProp("", false, chkLugarSectorEstadoSector_Internalname, "TitleCaption", chkLugarSectorEstadoSector.Caption, !bGXsfl_88_Refreshing);
         chkLugarSectorEstadoSector.CheckedValue = "false";
         A41LugarSectorEstadoSector = StringUtil.StrToBool( StringUtil.BoolToStr( A41LugarSectorEstadoSector));
         Gridespectaculo_lugarsectorRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkLugarSectorEstadoSector_Internalname,StringUtil.BoolToStr( A41LugarSectorEstadoSector),(string)"",(string)"",(short)-1,chkLugarSectorEstadoSector.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(92, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,92);\""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridespectaculo_lugarsectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarSectorPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ",", "")),StringUtil.LTrim( ((edtLugarSectorPrecio_Enabled!=0) ? context.localUtil.Format( (decimal)(A30LugarSectorPrecio), "ZZZ9") : context.localUtil.Format( (decimal)(A30LugarSectorPrecio), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarSectorPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtLugarSectorPrecio_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)88,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridespectaculo_lugarsectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarSectorVendidas_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ",", "")),StringUtil.LTrim( ((edtLugarSectorVendidas_Enabled!=0) ? context.localUtil.Format( (decimal)(A37LugarSectorVendidas), "ZZZ9") : context.localUtil.Format( (decimal)(A37LugarSectorVendidas), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarSectorVendidas_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtLugarSectorVendidas_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)88,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridespectaculo_lugarsectorRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtLugarSectorDisponibles_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A38LugarSectorDisponibles), 4, 0, ",", "")),StringUtil.LTrim( ((edtLugarSectorDisponibles_Enabled!=0) ? context.localUtil.Format( (decimal)(A38LugarSectorDisponibles), "ZZZ9") : context.localUtil.Format( (decimal)(A38LugarSectorDisponibles), "ZZZ9"))),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtLugarSectorDisponibles_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtLugarSectorDisponibles_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)88,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridespectaculo_lugarsectorRow);
         send_integrity_lvl_hashes0A16( ) ;
         GXCCtl = "Z27LugarSectorId_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z27LugarSectorId), 4, 0, ",", "")));
         GXCCtl = "Z41LugarSectorEstadoSector_" + sGXsfl_88_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, Z41LugarSectorEstadoSector);
         GXCCtl = "nRcdDeleted_16_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_16), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_16_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_16), 4, 0, ",", "")));
         GXCCtl = "nIsMod_16_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_16), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_88_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vESPECTACULOID_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORNAME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORCANTIDAD_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorCantidad_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORESTADOSECTOR_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkLugarSectorEstadoSector.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORPRECIO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORVENDIDAS_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorVendidas_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LUGARSECTORDISPONIBLES_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorDisponibles_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_27_"+sGXsfl_88_idx+"Link", StringUtil.RTrim( imgprompt_27_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridespectaculo_lugarsectorContainer.AddRow(Gridespectaculo_lugarsectorRow);
      }

      protected void ReadRow0A16( )
      {
         nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8816( ) ;
         edtLugarSectorId_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORID_"+sGXsfl_88_idx+"Enabled"), ",", "."));
         edtLugarSectorName_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORNAME_"+sGXsfl_88_idx+"Enabled"), ",", "."));
         edtLugarSectorCantidad_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORCANTIDAD_"+sGXsfl_88_idx+"Enabled"), ",", "."));
         chkLugarSectorEstadoSector.Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORESTADOSECTOR_"+sGXsfl_88_idx+"Enabled"), ",", "."));
         edtLugarSectorPrecio_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORPRECIO_"+sGXsfl_88_idx+"Enabled"), ",", "."));
         edtLugarSectorVendidas_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORVENDIDAS_"+sGXsfl_88_idx+"Enabled"), ",", "."));
         edtLugarSectorDisponibles_Enabled = (int)(context.localUtil.CToN( cgiGet( "LUGARSECTORDISPONIBLES_"+sGXsfl_88_idx+"Enabled"), ",", "."));
         imgprompt_4_Link = cgiGet( "PROMPT_27_"+sGXsfl_88_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtLugarSectorId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLugarSectorId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "LUGARSECTORID_" + sGXsfl_88_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
            wbErr = true;
            A27LugarSectorId = 0;
         }
         else
         {
            A27LugarSectorId = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorId_Internalname), ",", "."));
         }
         A28LugarSectorName = cgiGet( edtLugarSectorName_Internalname);
         A29LugarSectorCantidad = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorCantidad_Internalname), ",", "."));
         A41LugarSectorEstadoSector = StringUtil.StrToBool( cgiGet( chkLugarSectorEstadoSector_Internalname));
         A30LugarSectorPrecio = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorPrecio_Internalname), ",", "."));
         A37LugarSectorVendidas = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorVendidas_Internalname), ",", "."));
         n37LugarSectorVendidas = false;
         A38LugarSectorDisponibles = (short)(context.localUtil.CToN( cgiGet( edtLugarSectorDisponibles_Internalname), ",", "."));
         GXCCtl = "Z27LugarSectorId_" + sGXsfl_88_idx;
         Z27LugarSectorId = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "Z41LugarSectorEstadoSector_" + sGXsfl_88_idx;
         Z41LugarSectorEstadoSector = StringUtil.StrToBool( cgiGet( GXCCtl));
         GXCCtl = "nRcdDeleted_16_" + sGXsfl_88_idx;
         nRcdDeleted_16 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdExists_16_" + sGXsfl_88_idx;
         nRcdExists_16 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nIsMod_16_" + sGXsfl_88_idx;
         nIsMod_16 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
      }

      protected void SubsflControlProps_10418( )
      {
         edtEspectaculoFuncionId_Internalname = "ESPECTACULOFUNCIONID_"+sGXsfl_104_idx;
         edtEspectaculoFuncionName_Internalname = "ESPECTACULOFUNCIONNAME_"+sGXsfl_104_idx;
         edtEspectaculoFuncionPrecio_Internalname = "ESPECTACULOFUNCIONPRECIO_"+sGXsfl_104_idx;
      }

      protected void SubsflControlProps_fel_10418( )
      {
         edtEspectaculoFuncionId_Internalname = "ESPECTACULOFUNCIONID_"+sGXsfl_104_fel_idx;
         edtEspectaculoFuncionName_Internalname = "ESPECTACULOFUNCIONNAME_"+sGXsfl_104_fel_idx;
         edtEspectaculoFuncionPrecio_Internalname = "ESPECTACULOFUNCIONPRECIO_"+sGXsfl_104_fel_idx;
      }

      protected void AddRow0A18( )
      {
         nGXsfl_104_idx = (int)(nGXsfl_104_idx+1);
         sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
         SubsflControlProps_10418( ) ;
         SendRow0A18( ) ;
      }

      protected void SendRow0A18( )
      {
         Gridespectaculo_espectaculofuncionRow = GXWebRow.GetNew(context);
         if ( subGridespectaculo_espectaculofuncion_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridespectaculo_espectaculofuncion_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridespectaculo_espectaculofuncion_Class, "") != 0 )
            {
               subGridespectaculo_espectaculofuncion_Linesclass = subGridespectaculo_espectaculofuncion_Class+"Odd";
            }
         }
         else if ( subGridespectaculo_espectaculofuncion_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridespectaculo_espectaculofuncion_Backstyle = 0;
            subGridespectaculo_espectaculofuncion_Backcolor = subGridespectaculo_espectaculofuncion_Allbackcolor;
            if ( StringUtil.StrCmp(subGridespectaculo_espectaculofuncion_Class, "") != 0 )
            {
               subGridespectaculo_espectaculofuncion_Linesclass = subGridespectaculo_espectaculofuncion_Class+"Uniform";
            }
         }
         else if ( subGridespectaculo_espectaculofuncion_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridespectaculo_espectaculofuncion_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridespectaculo_espectaculofuncion_Class, "") != 0 )
            {
               subGridespectaculo_espectaculofuncion_Linesclass = subGridespectaculo_espectaculofuncion_Class+"Odd";
            }
            subGridespectaculo_espectaculofuncion_Backcolor = (int)(0x0);
         }
         else if ( subGridespectaculo_espectaculofuncion_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridespectaculo_espectaculofuncion_Backstyle = 1;
            if ( ((int)((nGXsfl_104_idx) % (2))) == 0 )
            {
               subGridespectaculo_espectaculofuncion_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridespectaculo_espectaculofuncion_Class, "") != 0 )
               {
                  subGridespectaculo_espectaculofuncion_Linesclass = subGridespectaculo_espectaculofuncion_Class+"Even";
               }
            }
            else
            {
               subGridespectaculo_espectaculofuncion_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridespectaculo_espectaculofuncion_Class, "") != 0 )
               {
                  subGridespectaculo_espectaculofuncion_Linesclass = subGridespectaculo_espectaculofuncion_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_18_" + sGXsfl_104_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 105,'',false,'" + sGXsfl_104_idx + "',104)\"";
         ROClassString = "Attribute";
         Gridespectaculo_espectaculofuncionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEspectaculoFuncionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A47EspectaculoFuncionId), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A47EspectaculoFuncionId), "ZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,105);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEspectaculoFuncionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtEspectaculoFuncionId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)104,(short)1,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_18_" + sGXsfl_104_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 106,'',false,'" + sGXsfl_104_idx + "',104)\"";
         ROClassString = "Attribute";
         Gridespectaculo_espectaculofuncionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEspectaculoFuncionName_Internalname,(string)A48EspectaculoFuncionName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEspectaculoFuncionName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtEspectaculoFuncionName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)104,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_18_" + sGXsfl_104_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 107,'',false,'" + sGXsfl_104_idx + "',104)\"";
         ROClassString = "Attribute";
         Gridespectaculo_espectaculofuncionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEspectaculoFuncionPrecio_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A49EspectaculoFuncionPrecio), 4, 0, ",", "")),StringUtil.LTrim( ((edtEspectaculoFuncionPrecio_Enabled!=0) ? context.localUtil.Format( (decimal)(A49EspectaculoFuncionPrecio), "ZZZ9") : context.localUtil.Format( (decimal)(A49EspectaculoFuncionPrecio), "ZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,107);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEspectaculoFuncionPrecio_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtEspectaculoFuncionPrecio_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)104,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridespectaculo_espectaculofuncionRow);
         send_integrity_lvl_hashes0A18( ) ;
         GXCCtl = "Z47EspectaculoFuncionId_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z47EspectaculoFuncionId), 4, 0, ",", "")));
         GXCCtl = "Z48EspectaculoFuncionName_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z48EspectaculoFuncionName);
         GXCCtl = "Z49EspectaculoFuncionPrecio_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z49EspectaculoFuncionPrecio), 4, 0, ",", "")));
         GXCCtl = "nRcdDeleted_18_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_18), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_18_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_18), 4, 0, ",", "")));
         GXCCtl = "nIsMod_18_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_18), 4, 0, ",", "")));
         GXCCtl = "vMODE_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_104_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vESPECTACULOID_" + sGXsfl_104_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOFUNCIONID_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEspectaculoFuncionId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOFUNCIONNAME_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEspectaculoFuncionName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOFUNCIONPRECIO_"+sGXsfl_104_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEspectaculoFuncionPrecio_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridespectaculo_espectaculofuncionContainer.AddRow(Gridespectaculo_espectaculofuncionRow);
      }

      protected void ReadRow0A18( )
      {
         nGXsfl_104_idx = (int)(nGXsfl_104_idx+1);
         sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
         SubsflControlProps_10418( ) ;
         edtEspectaculoFuncionId_Enabled = (int)(context.localUtil.CToN( cgiGet( "ESPECTACULOFUNCIONID_"+sGXsfl_104_idx+"Enabled"), ",", "."));
         edtEspectaculoFuncionName_Enabled = (int)(context.localUtil.CToN( cgiGet( "ESPECTACULOFUNCIONNAME_"+sGXsfl_104_idx+"Enabled"), ",", "."));
         edtEspectaculoFuncionPrecio_Enabled = (int)(context.localUtil.CToN( cgiGet( "ESPECTACULOFUNCIONPRECIO_"+sGXsfl_104_idx+"Enabled"), ",", "."));
         if ( ( ( context.localUtil.CToN( cgiGet( edtEspectaculoFuncionId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEspectaculoFuncionId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "ESPECTACULOFUNCIONID_" + sGXsfl_104_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtEspectaculoFuncionId_Internalname;
            wbErr = true;
            A47EspectaculoFuncionId = 0;
         }
         else
         {
            A47EspectaculoFuncionId = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoFuncionId_Internalname), ",", "."));
         }
         A48EspectaculoFuncionName = cgiGet( edtEspectaculoFuncionName_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtEspectaculoFuncionPrecio_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEspectaculoFuncionPrecio_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "ESPECTACULOFUNCIONPRECIO_" + sGXsfl_104_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtEspectaculoFuncionPrecio_Internalname;
            wbErr = true;
            A49EspectaculoFuncionPrecio = 0;
         }
         else
         {
            A49EspectaculoFuncionPrecio = (short)(context.localUtil.CToN( cgiGet( edtEspectaculoFuncionPrecio_Internalname), ",", "."));
         }
         GXCCtl = "Z47EspectaculoFuncionId_" + sGXsfl_104_idx;
         Z47EspectaculoFuncionId = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "Z48EspectaculoFuncionName_" + sGXsfl_104_idx;
         Z48EspectaculoFuncionName = cgiGet( GXCCtl);
         GXCCtl = "Z49EspectaculoFuncionPrecio_" + sGXsfl_104_idx;
         Z49EspectaculoFuncionPrecio = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdDeleted_18_" + sGXsfl_104_idx;
         nRcdDeleted_18 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nRcdExists_18_" + sGXsfl_104_idx;
         nRcdExists_18 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
         GXCCtl = "nIsMod_18_" + sGXsfl_104_idx;
         nIsMod_18 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."));
      }

      protected void assign_properties_default( )
      {
         defedtEspectaculoFuncionId_Enabled = edtEspectaculoFuncionId_Enabled;
         defedtLugarSectorId_Enabled = edtLugarSectorId_Enabled;
      }

      protected void ConfirmValues0A0( )
      {
         nGXsfl_88_idx = 0;
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8816( ) ;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_8816( ) ;
            ChangePostValue( "Z27LugarSectorId_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z27LugarSectorId_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z27LugarSectorId_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z41LugarSectorEstadoSector_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z41LugarSectorEstadoSector_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z41LugarSectorEstadoSector_"+sGXsfl_88_idx) ;
         }
         nGXsfl_104_idx = 0;
         sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
         SubsflControlProps_10418( ) ;
         while ( nGXsfl_104_idx < nRC_GXsfl_104 )
         {
            nGXsfl_104_idx = (int)(nGXsfl_104_idx+1);
            sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
            SubsflControlProps_10418( ) ;
            ChangePostValue( "Z47EspectaculoFuncionId_"+sGXsfl_104_idx, cgiGet( "ZT_"+"Z47EspectaculoFuncionId_"+sGXsfl_104_idx)) ;
            DeletePostValue( "ZT_"+"Z47EspectaculoFuncionId_"+sGXsfl_104_idx) ;
            ChangePostValue( "Z48EspectaculoFuncionName_"+sGXsfl_104_idx, cgiGet( "ZT_"+"Z48EspectaculoFuncionName_"+sGXsfl_104_idx)) ;
            DeletePostValue( "ZT_"+"Z48EspectaculoFuncionName_"+sGXsfl_104_idx) ;
            ChangePostValue( "Z49EspectaculoFuncionPrecio_"+sGXsfl_104_idx, cgiGet( "ZT_"+"Z49EspectaculoFuncionPrecio_"+sGXsfl_104_idx)) ;
            DeletePostValue( "ZT_"+"Z49EspectaculoFuncionPrecio_"+sGXsfl_104_idx) ;
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 552120), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 552120), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 552120), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20228102084564", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("espectaculo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EspectaculoId,4,0))}, new string[] {"Gx_mode","EspectaculoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Espectaculo");
         forbiddenHiddens.Add("EspectaculoId", context.localUtil.Format( (decimal)(A1EspectaculoId), "ZZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("espectaculo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z1EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z2EspectaculoName", Z2EspectaculoName);
         GxWebStd.gx_hidden_field( context, "Z16EspectaculoFecha", context.localUtil.DToC( Z16EspectaculoFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z4LugarId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4LugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z7TipoEspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7TipoEspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_88", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_88_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_104", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_104_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N4LugarId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A4LugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "N7TipoEspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7TipoEspectaculoId), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "vESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vESPECTACULOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7EspectaculoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_LUGARID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_LugarId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_TIPOESPECTACULOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_TipoEspectaculoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ESPECTACULOIMAGEN_GXI", A40000EspectaculoImagen_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
         GXCCtlgxBlob = "ESPECTACULOIMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A26EspectaculoImagen);
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
         return formatLink("espectaculo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EspectaculoId,4,0))}, new string[] {"Gx_mode","EspectaculoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Espectaculo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Espectaculo" ;
      }

      protected void InitializeNonKey0A15( )
      {
         A4LugarId = 0;
         AssignAttri("", false, "A4LugarId", StringUtil.LTrimStr( (decimal)(A4LugarId), 4, 0));
         A7TipoEspectaculoId = 0;
         AssignAttri("", false, "A7TipoEspectaculoId", StringUtil.LTrimStr( (decimal)(A7TipoEspectaculoId), 4, 0));
         A2EspectaculoName = "";
         AssignAttri("", false, "A2EspectaculoName", A2EspectaculoName);
         A16EspectaculoFecha = DateTime.MinValue;
         AssignAttri("", false, "A16EspectaculoFecha", context.localUtil.Format(A16EspectaculoFecha, "99/99/99"));
         A5LugarName = "";
         AssignAttri("", false, "A5LugarName", A5LugarName);
         A3PaisId = 0;
         AssignAttri("", false, "A3PaisId", StringUtil.LTrimStr( (decimal)(A3PaisId), 4, 0));
         A6PaisName = "";
         AssignAttri("", false, "A6PaisName", A6PaisName);
         A8TipoEspectaculoName = "";
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
         A26EspectaculoImagen = "";
         AssignAttri("", false, "A26EspectaculoImagen", A26EspectaculoImagen);
         AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
         AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
         A40000EspectaculoImagen_GXI = "";
         AssignProp("", false, imgEspectaculoImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A26EspectaculoImagen)) ? A40000EspectaculoImagen_GXI : context.convertURL( context.PathToRelativeUrl( A26EspectaculoImagen))), true);
         AssignProp("", false, imgEspectaculoImagen_Internalname, "SrcSet", context.GetImageSrcSet( A26EspectaculoImagen), true);
         Z2EspectaculoName = "";
         Z16EspectaculoFecha = DateTime.MinValue;
         Z4LugarId = 0;
         Z7TipoEspectaculoId = 0;
      }

      protected void InitAll0A15( )
      {
         A1EspectaculoId = 0;
         AssignAttri("", false, "A1EspectaculoId", StringUtil.LTrimStr( (decimal)(A1EspectaculoId), 4, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228102084664", true, true);
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
         context.AddJavascriptSource("espectaculo.js", "?20228102084667", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties16( )
      {
         edtLugarSectorId_Enabled = defedtLugarSectorId_Enabled;
         AssignProp("", false, edtLugarSectorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLugarSectorId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void init_level_properties18( )
      {
         edtEspectaculoFuncionId_Enabled = defedtEspectaculoFuncionId_Enabled;
         AssignProp("", false, edtEspectaculoFuncionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEspectaculoFuncionId_Enabled), 5, 0), !bGXsfl_104_Refreshing);
      }

      protected void StartGridControl88( )
      {
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("GridName", "Gridespectaculo_lugarsector");
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Header", subGridespectaculo_lugarsector_Header);
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Class", "Grid");
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_lugarsector_Backcolorstyle), 1, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("CmpContext", "");
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("InMasterPage", "false");
         Gridespectaculo_lugarsectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A27LugarSectorId), 4, 0, ".", "")));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorId_Enabled), 5, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddColumnProperties(Gridespectaculo_lugarsectorColumn);
         Gridespectaculo_lugarsectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_lugarsectorContainer.AddColumnProperties(Gridespectaculo_lugarsectorColumn);
         Gridespectaculo_lugarsectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Value", A28LugarSectorName);
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorName_Enabled), 5, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddColumnProperties(Gridespectaculo_lugarsectorColumn);
         Gridespectaculo_lugarsectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29LugarSectorCantidad), 4, 0, ".", "")));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorCantidad_Enabled), 5, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddColumnProperties(Gridespectaculo_lugarsectorColumn);
         Gridespectaculo_lugarsectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Value", StringUtil.BoolToStr( A41LugarSectorEstadoSector));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkLugarSectorEstadoSector.Enabled), 5, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddColumnProperties(Gridespectaculo_lugarsectorColumn);
         Gridespectaculo_lugarsectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ".", "")));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorPrecio_Enabled), 5, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddColumnProperties(Gridespectaculo_lugarsectorColumn);
         Gridespectaculo_lugarsectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ".", "")));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorVendidas_Enabled), 5, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddColumnProperties(Gridespectaculo_lugarsectorColumn);
         Gridespectaculo_lugarsectorColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A38LugarSectorDisponibles), 4, 0, ".", "")));
         Gridespectaculo_lugarsectorColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtLugarSectorDisponibles_Enabled), 5, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddColumnProperties(Gridespectaculo_lugarsectorColumn);
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_lugarsector_Selectedindex), 4, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_lugarsector_Allowselection), 1, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_lugarsector_Selectioncolor), 9, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_lugarsector_Allowhovering), 1, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_lugarsector_Hoveringcolor), 9, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_lugarsector_Allowcollapsing), 1, 0, ".", "")));
         Gridespectaculo_lugarsectorContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_lugarsector_Collapsed), 1, 0, ".", "")));
      }

      protected void StartGridControl104( )
      {
         Gridespectaculo_espectaculofuncionContainer.AddObjectProperty("GridName", "Gridespectaculo_espectaculofuncion");
         Gridespectaculo_espectaculofuncionContainer.AddObjectProperty("Header", subGridespectaculo_espectaculofuncion_Header);
         Gridespectaculo_espectaculofuncionContainer.AddObjectProperty("Class", "Grid");
         Gridespectaculo_espectaculofuncionContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridespectaculo_espectaculofuncionContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridespectaculo_espectaculofuncionContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_espectaculofuncion_Backcolorstyle), 1, 0, ".", "")));
         Gridespectaculo_espectaculofuncionContainer.AddObjectProperty("CmpContext", "");
         Gridespectaculo_espectaculofuncionContainer.AddObjectProperty("InMasterPage", "false");
         Gridespectaculo_espectaculofuncionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_espectaculofuncionColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A47EspectaculoFuncionId), 4, 0, ".", "")));
         Gridespectaculo_espectaculofuncionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEspectaculoFuncionId_Enabled), 5, 0, ".", "")));
         Gridespectaculo_espectaculofuncionContainer.AddColumnProperties(Gridespectaculo_espectaculofuncionColumn);
         Gridespectaculo_espectaculofuncionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_espectaculofuncionColumn.AddObjectProperty("Value", A48EspectaculoFuncionName);
         Gridespectaculo_espectaculofuncionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEspectaculoFuncionName_Enabled), 5, 0, ".", "")));
         Gridespectaculo_espectaculofuncionContainer.AddColumnProperties(Gridespectaculo_espectaculofuncionColumn);
         Gridespectaculo_espectaculofuncionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridespectaculo_espectaculofuncionColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A49EspectaculoFuncionPrecio), 4, 0, ".", "")));
         Gridespectaculo_espectaculofuncionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEspectaculoFuncionPrecio_Enabled), 5, 0, ".", "")));
         Gridespectaculo_espectaculofuncionContainer.AddColumnProperties(Gridespectaculo_espectaculofuncionColumn);
         Gridespectaculo_espectaculofuncionContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_espectaculofuncion_Selectedindex), 4, 0, ".", "")));
         Gridespectaculo_espectaculofuncionContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_espectaculofuncion_Allowselection), 1, 0, ".", "")));
         Gridespectaculo_espectaculofuncionContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_espectaculofuncion_Selectioncolor), 9, 0, ".", "")));
         Gridespectaculo_espectaculofuncionContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_espectaculofuncion_Allowhovering), 1, 0, ".", "")));
         Gridespectaculo_espectaculofuncionContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_espectaculofuncion_Hoveringcolor), 9, 0, ".", "")));
         Gridespectaculo_espectaculofuncionContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_espectaculofuncion_Allowcollapsing), 1, 0, ".", "")));
         Gridespectaculo_espectaculofuncionContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridespectaculo_espectaculofuncion_Collapsed), 1, 0, ".", "")));
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
         edtEspectaculoId_Internalname = "ESPECTACULOID";
         edtEspectaculoName_Internalname = "ESPECTACULONAME";
         edtEspectaculoFecha_Internalname = "ESPECTACULOFECHA";
         edtLugarId_Internalname = "LUGARID";
         edtLugarName_Internalname = "LUGARNAME";
         edtPaisId_Internalname = "PAISID";
         edtPaisName_Internalname = "PAISNAME";
         edtTipoEspectaculoId_Internalname = "TIPOESPECTACULOID";
         edtTipoEspectaculoName_Internalname = "TIPOESPECTACULONAME";
         imgEspectaculoImagen_Internalname = "ESPECTACULOIMAGEN";
         lblTitlelugarsector_Internalname = "TITLELUGARSECTOR";
         edtLugarSectorId_Internalname = "LUGARSECTORID";
         edtLugarSectorName_Internalname = "LUGARSECTORNAME";
         edtLugarSectorCantidad_Internalname = "LUGARSECTORCANTIDAD";
         chkLugarSectorEstadoSector_Internalname = "LUGARSECTORESTADOSECTOR";
         edtLugarSectorPrecio_Internalname = "LUGARSECTORPRECIO";
         edtLugarSectorVendidas_Internalname = "LUGARSECTORVENDIDAS";
         edtLugarSectorDisponibles_Internalname = "LUGARSECTORDISPONIBLES";
         divLugarsectortable_Internalname = "LUGARSECTORTABLE";
         lblTitleespectaculofuncion_Internalname = "TITLEESPECTACULOFUNCION";
         edtEspectaculoFuncionId_Internalname = "ESPECTACULOFUNCIONID";
         edtEspectaculoFuncionName_Internalname = "ESPECTACULOFUNCIONNAME";
         edtEspectaculoFuncionPrecio_Internalname = "ESPECTACULOFUNCIONPRECIO";
         divEspectaculofunciontable_Internalname = "ESPECTACULOFUNCIONTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_4_Internalname = "PROMPT_4";
         imgprompt_7_Internalname = "PROMPT_7";
         imgprompt_27_Internalname = "PROMPT_27";
         subGridespectaculo_lugarsector_Internalname = "GRIDESPECTACULO_LUGARSECTOR";
         subGridespectaculo_espectaculofuncion_Internalname = "GRIDESPECTACULO_ESPECTACULOFUNCION";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridespectaculo_espectaculofuncion_Allowcollapsing = 0;
         subGridespectaculo_espectaculofuncion_Allowselection = 0;
         subGridespectaculo_espectaculofuncion_Header = "";
         subGridespectaculo_lugarsector_Allowcollapsing = 0;
         subGridespectaculo_lugarsector_Allowselection = 0;
         subGridespectaculo_lugarsector_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Espectaculo";
         edtEspectaculoFuncionPrecio_Jsonclick = "";
         edtEspectaculoFuncionName_Jsonclick = "";
         edtEspectaculoFuncionId_Jsonclick = "";
         subGridespectaculo_espectaculofuncion_Class = "Grid";
         subGridespectaculo_espectaculofuncion_Backcolorstyle = 0;
         edtLugarSectorDisponibles_Jsonclick = "";
         edtLugarSectorVendidas_Jsonclick = "";
         edtLugarSectorPrecio_Jsonclick = "";
         chkLugarSectorEstadoSector.Caption = "";
         edtLugarSectorCantidad_Jsonclick = "";
         edtLugarSectorName_Jsonclick = "";
         imgprompt_27_Visible = 1;
         imgprompt_27_Link = "";
         imgprompt_4_Visible = 1;
         edtLugarSectorId_Jsonclick = "";
         subGridespectaculo_lugarsector_Class = "Grid";
         subGridespectaculo_lugarsector_Backcolorstyle = 0;
         edtEspectaculoFuncionPrecio_Enabled = 1;
         edtEspectaculoFuncionName_Enabled = 1;
         edtEspectaculoFuncionId_Enabled = 1;
         edtLugarSectorDisponibles_Enabled = 0;
         edtLugarSectorVendidas_Enabled = 0;
         edtLugarSectorPrecio_Enabled = 0;
         chkLugarSectorEstadoSector.Enabled = 1;
         edtLugarSectorCantidad_Enabled = 0;
         edtLugarSectorName_Enabled = 0;
         edtLugarSectorId_Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirmar";
         bttBtn_enter_Caption = "Confirmar";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         imgEspectaculoImagen_Enabled = 1;
         edtTipoEspectaculoName_Jsonclick = "";
         edtTipoEspectaculoName_Enabled = 0;
         imgprompt_7_Visible = 1;
         imgprompt_7_Link = "";
         edtTipoEspectaculoId_Jsonclick = "";
         edtTipoEspectaculoId_Enabled = 1;
         edtPaisName_Jsonclick = "";
         edtPaisName_Enabled = 0;
         edtPaisId_Jsonclick = "";
         edtPaisId_Enabled = 0;
         edtLugarName_Jsonclick = "";
         edtLugarName_Enabled = 0;
         imgprompt_4_Visible = 1;
         imgprompt_4_Link = "";
         edtLugarId_Jsonclick = "";
         edtLugarId_Enabled = 1;
         edtEspectaculoFecha_Jsonclick = "";
         edtEspectaculoFecha_Enabled = 1;
         edtEspectaculoName_Jsonclick = "";
         edtEspectaculoName_Enabled = 1;
         edtEspectaculoId_Jsonclick = "";
         edtEspectaculoId_Enabled = 0;
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

      protected void gxnrGridespectaculo_lugarsector_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_8816( ) ;
         while ( nGXsfl_88_idx <= nRC_GXsfl_88 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0A16( ) ;
            standaloneModal0A16( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0A16( ) ;
            nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_8816( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridespectaculo_lugarsectorContainer)) ;
         /* End function gxnrGridespectaculo_lugarsector_newrow */
      }

      protected void gxnrGridespectaculo_espectaculofuncion_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_10418( ) ;
         while ( nGXsfl_104_idx <= nRC_GXsfl_104 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0A18( ) ;
            standaloneModal0A18( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0A18( ) ;
            nGXsfl_104_idx = (int)(nGXsfl_104_idx+1);
            sGXsfl_104_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_104_idx), 4, 0), 4, "0");
            SubsflControlProps_10418( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridespectaculo_espectaculofuncionContainer)) ;
         /* End function gxnrGridespectaculo_espectaculofuncion_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "LUGARSECTORESTADOSECTOR_" + sGXsfl_88_idx;
         chkLugarSectorEstadoSector.Name = GXCCtl;
         chkLugarSectorEstadoSector.WebTags = "";
         chkLugarSectorEstadoSector.Caption = "";
         AssignProp("", false, chkLugarSectorEstadoSector_Internalname, "TitleCaption", chkLugarSectorEstadoSector.Caption, !bGXsfl_88_Refreshing);
         chkLugarSectorEstadoSector.CheckedValue = "false";
         A41LugarSectorEstadoSector = StringUtil.StrToBool( StringUtil.BoolToStr( A41LugarSectorEstadoSector));
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
         /* Using cursor T000A25 */
         pr_default.execute(22, new Object[] {A4LugarId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Lugar'.", "ForeignKeyNotFound", 1, "LUGARID");
            AnyError = 1;
            GX_FocusControl = edtLugarId_Internalname;
         }
         A5LugarName = T000A25_A5LugarName[0];
         A3PaisId = T000A25_A3PaisId[0];
         pr_default.close(22);
         /* Using cursor T000A26 */
         pr_default.execute(23, new Object[] {A3PaisId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Pais'.", "ForeignKeyNotFound", 1, "PAISID");
            AnyError = 1;
         }
         A6PaisName = T000A26_A6PaisName[0];
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A5LugarName", A5LugarName);
         AssignAttri("", false, "A3PaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A3PaisId), 4, 0, ".", "")));
         AssignAttri("", false, "A6PaisName", A6PaisName);
      }

      public void Valid_Tipoespectaculoid( )
      {
         /* Using cursor T000A27 */
         pr_default.execute(24, new Object[] {A7TipoEspectaculoId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Espectaculo'.", "ForeignKeyNotFound", 1, "TIPOESPECTACULOID");
            AnyError = 1;
            GX_FocusControl = edtTipoEspectaculoId_Internalname;
         }
         A8TipoEspectaculoName = T000A27_A8TipoEspectaculoName[0];
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A8TipoEspectaculoName", A8TipoEspectaculoName);
      }

      public void Valid_Lugarsectorid( )
      {
         n37LugarSectorVendidas = false;
         /* Using cursor T000A40 */
         pr_default.execute(35, new Object[] {A4LugarId, A27LugarSectorId});
         if ( (pr_default.getStatus(35) == 101) )
         {
            GX_msglist.addItem("No existe 'Sector'.", "ForeignKeyNotFound", 1, "LUGARSECTORID");
            AnyError = 1;
            GX_FocusControl = edtLugarSectorId_Internalname;
         }
         A28LugarSectorName = T000A40_A28LugarSectorName[0];
         A29LugarSectorCantidad = T000A40_A29LugarSectorCantidad[0];
         A30LugarSectorPrecio = T000A40_A30LugarSectorPrecio[0];
         pr_default.close(35);
         /* Using cursor T000A42 */
         pr_default.execute(36, new Object[] {A1EspectaculoId, A27LugarSectorId});
         if ( (pr_default.getStatus(36) != 101) )
         {
            A37LugarSectorVendidas = T000A42_A37LugarSectorVendidas[0];
            n37LugarSectorVendidas = T000A42_n37LugarSectorVendidas[0];
         }
         else
         {
            A37LugarSectorVendidas = 0;
            n37LugarSectorVendidas = false;
         }
         pr_default.close(36);
         A38LugarSectorDisponibles = (short)(A29LugarSectorCantidad-A37LugarSectorVendidas);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A28LugarSectorName", A28LugarSectorName);
         AssignAttri("", false, "A29LugarSectorCantidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29LugarSectorCantidad), 4, 0, ".", "")));
         AssignAttri("", false, "A30LugarSectorPrecio", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30LugarSectorPrecio), 4, 0, ".", "")));
         AssignAttri("", false, "A37LugarSectorVendidas", StringUtil.LTrim( StringUtil.NToC( (decimal)(A37LugarSectorVendidas), 4, 0, ".", "")));
         AssignAttri("", false, "A38LugarSectorDisponibles", StringUtil.LTrim( StringUtil.NToC( (decimal)(A38LugarSectorDisponibles), 4, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7EspectaculoId',fld:'vESPECTACULOID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7EspectaculoId',fld:'vESPECTACULOID',pic:'ZZZ9',hsh:true},{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120A2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOID","{handler:'Valid_Espectaculoid',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOID",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOFECHA","{handler:'Valid_Espectaculofecha',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOFECHA",",oparms:[]}");
         setEventMetadata("VALID_LUGARID","{handler:'Valid_Lugarid',iparms:[{av:'A4LugarId',fld:'LUGARID',pic:'ZZZ9'},{av:'A3PaisId',fld:'PAISID',pic:'ZZZ9'},{av:'A5LugarName',fld:'LUGARNAME',pic:''},{av:'A6PaisName',fld:'PAISNAME',pic:''}]");
         setEventMetadata("VALID_LUGARID",",oparms:[{av:'A5LugarName',fld:'LUGARNAME',pic:''},{av:'A3PaisId',fld:'PAISID',pic:'ZZZ9'},{av:'A6PaisName',fld:'PAISNAME',pic:''}]}");
         setEventMetadata("VALID_PAISID","{handler:'Valid_Paisid',iparms:[]");
         setEventMetadata("VALID_PAISID",",oparms:[]}");
         setEventMetadata("VALID_TIPOESPECTACULOID","{handler:'Valid_Tipoespectaculoid',iparms:[{av:'A7TipoEspectaculoId',fld:'TIPOESPECTACULOID',pic:'ZZZ9'},{av:'A8TipoEspectaculoName',fld:'TIPOESPECTACULONAME',pic:''}]");
         setEventMetadata("VALID_TIPOESPECTACULOID",",oparms:[{av:'A8TipoEspectaculoName',fld:'TIPOESPECTACULONAME',pic:''}]}");
         setEventMetadata("VALID_LUGARSECTORID","{handler:'Valid_Lugarsectorid',iparms:[{av:'A4LugarId',fld:'LUGARID',pic:'ZZZ9'},{av:'A27LugarSectorId',fld:'LUGARSECTORID',pic:'ZZZ9'},{av:'A1EspectaculoId',fld:'ESPECTACULOID',pic:'ZZZ9'},{av:'A29LugarSectorCantidad',fld:'LUGARSECTORCANTIDAD',pic:'ZZZ9'},{av:'A37LugarSectorVendidas',fld:'LUGARSECTORVENDIDAS',pic:'ZZZ9'},{av:'A28LugarSectorName',fld:'LUGARSECTORNAME',pic:''},{av:'A30LugarSectorPrecio',fld:'LUGARSECTORPRECIO',pic:'ZZZ9'},{av:'A38LugarSectorDisponibles',fld:'LUGARSECTORDISPONIBLES',pic:'ZZZ9'}]");
         setEventMetadata("VALID_LUGARSECTORID",",oparms:[{av:'A28LugarSectorName',fld:'LUGARSECTORNAME',pic:''},{av:'A29LugarSectorCantidad',fld:'LUGARSECTORCANTIDAD',pic:'ZZZ9'},{av:'A30LugarSectorPrecio',fld:'LUGARSECTORPRECIO',pic:'ZZZ9'},{av:'A37LugarSectorVendidas',fld:'LUGARSECTORVENDIDAS',pic:'ZZZ9'},{av:'A38LugarSectorDisponibles',fld:'LUGARSECTORDISPONIBLES',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_LUGARSECTORCANTIDAD","{handler:'Valid_Lugarsectorcantidad',iparms:[]");
         setEventMetadata("VALID_LUGARSECTORCANTIDAD",",oparms:[]}");
         setEventMetadata("VALID_LUGARSECTORVENDIDAS","{handler:'Valid_Lugarsectorvendidas',iparms:[]");
         setEventMetadata("VALID_LUGARSECTORVENDIDAS",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Lugarsectordisponibles',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALID_ESPECTACULOFUNCIONID","{handler:'Valid_Espectaculofuncionid',iparms:[]");
         setEventMetadata("VALID_ESPECTACULOFUNCIONID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Espectaculofuncionprecio',iparms:[]");
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
         pr_default.close(3);
         pr_default.close(35);
         pr_default.close(36);
         pr_default.close(7);
         pr_default.close(22);
         pr_default.close(24);
         pr_default.close(23);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z2EspectaculoName = "";
         Z16EspectaculoFecha = DateTime.MinValue;
         Z48EspectaculoFuncionName = "";
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
         A2EspectaculoName = "";
         A16EspectaculoFecha = DateTime.MinValue;
         sImgUrl = "";
         A5LugarName = "";
         A6PaisName = "";
         A8TipoEspectaculoName = "";
         A26EspectaculoImagen = "";
         A40000EspectaculoImagen_GXI = "";
         lblTitlelugarsector_Jsonclick = "";
         lblTitleespectaculofuncion_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridespectaculo_lugarsectorContainer = new GXWebGrid( context);
         sMode16 = "";
         sStyleString = "";
         Gridespectaculo_espectaculofuncionContainer = new GXWebGrid( context);
         sMode18 = "";
         AV14Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode15 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A48EspectaculoFuncionName = "";
         A28LugarSectorName = "";
         AV9TrnContext = new SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new SdtTransactionContext_Attribute(context);
         Z26EspectaculoImagen = "";
         Z40000EspectaculoImagen_GXI = "";
         Z5LugarName = "";
         Z6PaisName = "";
         Z8TipoEspectaculoName = "";
         T000A12_A8TipoEspectaculoName = new string[] {""} ;
         T000A11_A5LugarName = new string[] {""} ;
         T000A11_A3PaisId = new short[1] ;
         T000A13_A6PaisName = new string[] {""} ;
         T000A14_A1EspectaculoId = new short[1] ;
         T000A14_A2EspectaculoName = new string[] {""} ;
         T000A14_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T000A14_A5LugarName = new string[] {""} ;
         T000A14_A6PaisName = new string[] {""} ;
         T000A14_A8TipoEspectaculoName = new string[] {""} ;
         T000A14_A40000EspectaculoImagen_GXI = new string[] {""} ;
         T000A14_A4LugarId = new short[1] ;
         T000A14_A7TipoEspectaculoId = new short[1] ;
         T000A14_A3PaisId = new short[1] ;
         T000A14_A26EspectaculoImagen = new string[] {""} ;
         T000A15_A5LugarName = new string[] {""} ;
         T000A15_A3PaisId = new short[1] ;
         T000A16_A6PaisName = new string[] {""} ;
         T000A17_A8TipoEspectaculoName = new string[] {""} ;
         T000A18_A1EspectaculoId = new short[1] ;
         T000A10_A1EspectaculoId = new short[1] ;
         T000A10_A2EspectaculoName = new string[] {""} ;
         T000A10_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T000A10_A40000EspectaculoImagen_GXI = new string[] {""} ;
         T000A10_A4LugarId = new short[1] ;
         T000A10_A7TipoEspectaculoId = new short[1] ;
         T000A10_A26EspectaculoImagen = new string[] {""} ;
         T000A19_A1EspectaculoId = new short[1] ;
         T000A20_A1EspectaculoId = new short[1] ;
         T000A9_A1EspectaculoId = new short[1] ;
         T000A9_A2EspectaculoName = new string[] {""} ;
         T000A9_A16EspectaculoFecha = new DateTime[] {DateTime.MinValue} ;
         T000A9_A40000EspectaculoImagen_GXI = new string[] {""} ;
         T000A9_A4LugarId = new short[1] ;
         T000A9_A7TipoEspectaculoId = new short[1] ;
         T000A9_A26EspectaculoImagen = new string[] {""} ;
         T000A21_A1EspectaculoId = new short[1] ;
         T000A25_A5LugarName = new string[] {""} ;
         T000A25_A3PaisId = new short[1] ;
         T000A26_A6PaisName = new string[] {""} ;
         T000A27_A8TipoEspectaculoName = new string[] {""} ;
         T000A28_A23EntradaId = new short[1] ;
         T000A29_A23EntradaId = new short[1] ;
         T000A30_A1EspectaculoId = new short[1] ;
         Z28LugarSectorName = "";
         T000A32_A4LugarId = new short[1] ;
         T000A32_A1EspectaculoId = new short[1] ;
         T000A32_A28LugarSectorName = new string[] {""} ;
         T000A32_A29LugarSectorCantidad = new short[1] ;
         T000A32_A41LugarSectorEstadoSector = new bool[] {false} ;
         T000A32_A30LugarSectorPrecio = new short[1] ;
         T000A32_A27LugarSectorId = new short[1] ;
         T000A32_A37LugarSectorVendidas = new short[1] ;
         T000A32_n37LugarSectorVendidas = new bool[] {false} ;
         T000A6_A28LugarSectorName = new string[] {""} ;
         T000A6_A29LugarSectorCantidad = new short[1] ;
         T000A6_A30LugarSectorPrecio = new short[1] ;
         T000A8_A37LugarSectorVendidas = new short[1] ;
         T000A8_n37LugarSectorVendidas = new bool[] {false} ;
         T000A33_A28LugarSectorName = new string[] {""} ;
         T000A33_A29LugarSectorCantidad = new short[1] ;
         T000A33_A30LugarSectorPrecio = new short[1] ;
         T000A35_A37LugarSectorVendidas = new short[1] ;
         T000A35_n37LugarSectorVendidas = new bool[] {false} ;
         T000A36_A1EspectaculoId = new short[1] ;
         T000A36_A27LugarSectorId = new short[1] ;
         T000A5_A1EspectaculoId = new short[1] ;
         T000A5_A41LugarSectorEstadoSector = new bool[] {false} ;
         T000A5_A27LugarSectorId = new short[1] ;
         T000A4_A1EspectaculoId = new short[1] ;
         T000A4_A41LugarSectorEstadoSector = new bool[] {false} ;
         T000A4_A27LugarSectorId = new short[1] ;
         T000A40_A28LugarSectorName = new string[] {""} ;
         T000A40_A29LugarSectorCantidad = new short[1] ;
         T000A40_A30LugarSectorPrecio = new short[1] ;
         T000A42_A37LugarSectorVendidas = new short[1] ;
         T000A42_n37LugarSectorVendidas = new bool[] {false} ;
         T000A43_A24InvitacionId = new short[1] ;
         T000A44_A23EntradaId = new short[1] ;
         T000A45_A1EspectaculoId = new short[1] ;
         T000A45_A27LugarSectorId = new short[1] ;
         T000A46_A1EspectaculoId = new short[1] ;
         T000A46_A47EspectaculoFuncionId = new short[1] ;
         T000A46_A48EspectaculoFuncionName = new string[] {""} ;
         T000A46_A49EspectaculoFuncionPrecio = new short[1] ;
         T000A47_A1EspectaculoId = new short[1] ;
         T000A47_A47EspectaculoFuncionId = new short[1] ;
         T000A3_A1EspectaculoId = new short[1] ;
         T000A3_A47EspectaculoFuncionId = new short[1] ;
         T000A3_A48EspectaculoFuncionName = new string[] {""} ;
         T000A3_A49EspectaculoFuncionPrecio = new short[1] ;
         T000A2_A1EspectaculoId = new short[1] ;
         T000A2_A47EspectaculoFuncionId = new short[1] ;
         T000A2_A48EspectaculoFuncionName = new string[] {""} ;
         T000A2_A49EspectaculoFuncionPrecio = new short[1] ;
         T000A51_A24InvitacionId = new short[1] ;
         T000A52_A23EntradaId = new short[1] ;
         T000A53_A1EspectaculoId = new short[1] ;
         T000A53_A47EspectaculoFuncionId = new short[1] ;
         Gridespectaculo_lugarsectorRow = new GXWebRow();
         subGridespectaculo_lugarsector_Linesclass = "";
         ROClassString = "";
         Gridespectaculo_espectaculofuncionRow = new GXWebRow();
         subGridespectaculo_espectaculofuncion_Linesclass = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         Gridespectaculo_lugarsectorColumn = new GXWebColumn();
         Gridespectaculo_espectaculofuncionColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.espectaculo__default(),
            new Object[][] {
                new Object[] {
               T000A2_A1EspectaculoId, T000A2_A47EspectaculoFuncionId, T000A2_A48EspectaculoFuncionName, T000A2_A49EspectaculoFuncionPrecio
               }
               , new Object[] {
               T000A3_A1EspectaculoId, T000A3_A47EspectaculoFuncionId, T000A3_A48EspectaculoFuncionName, T000A3_A49EspectaculoFuncionPrecio
               }
               , new Object[] {
               T000A4_A1EspectaculoId, T000A4_A41LugarSectorEstadoSector, T000A4_A27LugarSectorId
               }
               , new Object[] {
               T000A5_A1EspectaculoId, T000A5_A41LugarSectorEstadoSector, T000A5_A27LugarSectorId
               }
               , new Object[] {
               T000A6_A28LugarSectorName, T000A6_A29LugarSectorCantidad, T000A6_A30LugarSectorPrecio
               }
               , new Object[] {
               T000A8_A37LugarSectorVendidas, T000A8_n37LugarSectorVendidas
               }
               , new Object[] {
               T000A9_A1EspectaculoId, T000A9_A2EspectaculoName, T000A9_A16EspectaculoFecha, T000A9_A40000EspectaculoImagen_GXI, T000A9_A4LugarId, T000A9_A7TipoEspectaculoId, T000A9_A26EspectaculoImagen
               }
               , new Object[] {
               T000A10_A1EspectaculoId, T000A10_A2EspectaculoName, T000A10_A16EspectaculoFecha, T000A10_A40000EspectaculoImagen_GXI, T000A10_A4LugarId, T000A10_A7TipoEspectaculoId, T000A10_A26EspectaculoImagen
               }
               , new Object[] {
               T000A11_A5LugarName, T000A11_A3PaisId
               }
               , new Object[] {
               T000A12_A8TipoEspectaculoName
               }
               , new Object[] {
               T000A13_A6PaisName
               }
               , new Object[] {
               T000A14_A1EspectaculoId, T000A14_A2EspectaculoName, T000A14_A16EspectaculoFecha, T000A14_A5LugarName, T000A14_A6PaisName, T000A14_A8TipoEspectaculoName, T000A14_A40000EspectaculoImagen_GXI, T000A14_A4LugarId, T000A14_A7TipoEspectaculoId, T000A14_A3PaisId,
               T000A14_A26EspectaculoImagen
               }
               , new Object[] {
               T000A15_A5LugarName, T000A15_A3PaisId
               }
               , new Object[] {
               T000A16_A6PaisName
               }
               , new Object[] {
               T000A17_A8TipoEspectaculoName
               }
               , new Object[] {
               T000A18_A1EspectaculoId
               }
               , new Object[] {
               T000A19_A1EspectaculoId
               }
               , new Object[] {
               T000A20_A1EspectaculoId
               }
               , new Object[] {
               T000A21_A1EspectaculoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A25_A5LugarName, T000A25_A3PaisId
               }
               , new Object[] {
               T000A26_A6PaisName
               }
               , new Object[] {
               T000A27_A8TipoEspectaculoName
               }
               , new Object[] {
               T000A28_A23EntradaId
               }
               , new Object[] {
               T000A29_A23EntradaId
               }
               , new Object[] {
               T000A30_A1EspectaculoId
               }
               , new Object[] {
               T000A32_A4LugarId, T000A32_A1EspectaculoId, T000A32_A28LugarSectorName, T000A32_A29LugarSectorCantidad, T000A32_A41LugarSectorEstadoSector, T000A32_A30LugarSectorPrecio, T000A32_A27LugarSectorId, T000A32_A37LugarSectorVendidas, T000A32_n37LugarSectorVendidas
               }
               , new Object[] {
               T000A33_A28LugarSectorName, T000A33_A29LugarSectorCantidad, T000A33_A30LugarSectorPrecio
               }
               , new Object[] {
               T000A35_A37LugarSectorVendidas, T000A35_n37LugarSectorVendidas
               }
               , new Object[] {
               T000A36_A1EspectaculoId, T000A36_A27LugarSectorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A40_A28LugarSectorName, T000A40_A29LugarSectorCantidad, T000A40_A30LugarSectorPrecio
               }
               , new Object[] {
               T000A42_A37LugarSectorVendidas, T000A42_n37LugarSectorVendidas
               }
               , new Object[] {
               T000A43_A24InvitacionId
               }
               , new Object[] {
               T000A44_A23EntradaId
               }
               , new Object[] {
               T000A45_A1EspectaculoId, T000A45_A27LugarSectorId
               }
               , new Object[] {
               T000A46_A1EspectaculoId, T000A46_A47EspectaculoFuncionId, T000A46_A48EspectaculoFuncionName, T000A46_A49EspectaculoFuncionPrecio
               }
               , new Object[] {
               T000A47_A1EspectaculoId, T000A47_A47EspectaculoFuncionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A51_A24InvitacionId
               }
               , new Object[] {
               T000A52_A23EntradaId
               }
               , new Object[] {
               T000A53_A1EspectaculoId, T000A53_A47EspectaculoFuncionId
               }
            }
         );
         AV14Pgmname = "Espectaculo";
      }

      private short nIsMod_16 ;
      private short wcpOAV7EspectaculoId ;
      private short Z1EspectaculoId ;
      private short Z4LugarId ;
      private short Z7TipoEspectaculoId ;
      private short N4LugarId ;
      private short N7TipoEspectaculoId ;
      private short Z27LugarSectorId ;
      private short nRcdDeleted_16 ;
      private short nRcdExists_16 ;
      private short Z47EspectaculoFuncionId ;
      private short Z49EspectaculoFuncionPrecio ;
      private short nRcdDeleted_18 ;
      private short nRcdExists_18 ;
      private short nIsMod_18 ;
      private short GxWebError ;
      private short A4LugarId ;
      private short A3PaisId ;
      private short A7TipoEspectaculoId ;
      private short A27LugarSectorId ;
      private short A1EspectaculoId ;
      private short AV7EspectaculoId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nBlankRcdCount16 ;
      private short RcdFound16 ;
      private short nBlankRcdUsr16 ;
      private short nBlankRcdCount18 ;
      private short RcdFound18 ;
      private short nBlankRcdUsr18 ;
      private short AV11Insert_LugarId ;
      private short AV12Insert_TipoEspectaculoId ;
      private short RcdFound15 ;
      private short A47EspectaculoFuncionId ;
      private short A49EspectaculoFuncionPrecio ;
      private short A29LugarSectorCantidad ;
      private short A30LugarSectorPrecio ;
      private short A37LugarSectorVendidas ;
      private short A38LugarSectorDisponibles ;
      private short GX_JID ;
      private short Z3PaisId ;
      private short Gx_BScreen ;
      private short nIsDirty_15 ;
      private short Z29LugarSectorCantidad ;
      private short Z30LugarSectorPrecio ;
      private short Z37LugarSectorVendidas ;
      private short nIsDirty_16 ;
      private short nIsDirty_18 ;
      private short subGridespectaculo_lugarsector_Backcolorstyle ;
      private short subGridespectaculo_lugarsector_Backstyle ;
      private short subGridespectaculo_espectaculofuncion_Backcolorstyle ;
      private short subGridespectaculo_espectaculofuncion_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridespectaculo_lugarsector_Allowselection ;
      private short subGridespectaculo_lugarsector_Allowhovering ;
      private short subGridespectaculo_lugarsector_Allowcollapsing ;
      private short subGridespectaculo_lugarsector_Collapsed ;
      private short subGridespectaculo_espectaculofuncion_Allowselection ;
      private short subGridespectaculo_espectaculofuncion_Allowhovering ;
      private short subGridespectaculo_espectaculofuncion_Allowcollapsing ;
      private short subGridespectaculo_espectaculofuncion_Collapsed ;
      private short Z38LugarSectorDisponibles ;
      private int nRC_GXsfl_88 ;
      private int nGXsfl_88_idx=1 ;
      private int nRC_GXsfl_104 ;
      private int nGXsfl_104_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtEspectaculoId_Enabled ;
      private int edtEspectaculoName_Enabled ;
      private int edtEspectaculoFecha_Enabled ;
      private int edtLugarId_Enabled ;
      private int imgprompt_4_Visible ;
      private int edtLugarName_Enabled ;
      private int edtPaisId_Enabled ;
      private int edtPaisName_Enabled ;
      private int edtTipoEspectaculoId_Enabled ;
      private int imgprompt_7_Visible ;
      private int edtTipoEspectaculoName_Enabled ;
      private int imgEspectaculoImagen_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtLugarSectorId_Enabled ;
      private int edtLugarSectorName_Enabled ;
      private int edtLugarSectorCantidad_Enabled ;
      private int edtLugarSectorPrecio_Enabled ;
      private int edtLugarSectorVendidas_Enabled ;
      private int edtLugarSectorDisponibles_Enabled ;
      private int fRowAdded ;
      private int edtEspectaculoFuncionId_Enabled ;
      private int edtEspectaculoFuncionName_Enabled ;
      private int edtEspectaculoFuncionPrecio_Enabled ;
      private int AV15GXV1 ;
      private int subGridespectaculo_lugarsector_Backcolor ;
      private int subGridespectaculo_lugarsector_Allbackcolor ;
      private int imgprompt_27_Visible ;
      private int subGridespectaculo_espectaculofuncion_Backcolor ;
      private int subGridespectaculo_espectaculofuncion_Allbackcolor ;
      private int defedtEspectaculoFuncionId_Enabled ;
      private int defedtLugarSectorId_Enabled ;
      private int idxLst ;
      private int subGridespectaculo_lugarsector_Selectedindex ;
      private int subGridespectaculo_lugarsector_Selectioncolor ;
      private int subGridespectaculo_lugarsector_Hoveringcolor ;
      private int subGridespectaculo_espectaculofuncion_Selectedindex ;
      private int subGridespectaculo_espectaculofuncion_Selectioncolor ;
      private int subGridespectaculo_espectaculofuncion_Hoveringcolor ;
      private long GRIDESPECTACULO_LUGARSECTOR_nFirstRecordOnPage ;
      private long GRIDESPECTACULO_ESPECTACULOFUNCION_nFirstRecordOnPage ;
      private string sPrefix ;
      private string sGXsfl_88_idx="0001" ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEspectaculoName_Internalname ;
      private string sGXsfl_104_idx="0001" ;
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
      private string edtEspectaculoId_Internalname ;
      private string edtEspectaculoId_Jsonclick ;
      private string edtEspectaculoName_Jsonclick ;
      private string edtEspectaculoFecha_Internalname ;
      private string edtEspectaculoFecha_Jsonclick ;
      private string edtLugarId_Internalname ;
      private string edtLugarId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_4_Internalname ;
      private string imgprompt_4_Link ;
      private string edtLugarName_Internalname ;
      private string edtLugarName_Jsonclick ;
      private string edtPaisId_Internalname ;
      private string edtPaisId_Jsonclick ;
      private string edtPaisName_Internalname ;
      private string edtPaisName_Jsonclick ;
      private string edtTipoEspectaculoId_Internalname ;
      private string edtTipoEspectaculoId_Jsonclick ;
      private string imgprompt_7_Internalname ;
      private string imgprompt_7_Link ;
      private string edtTipoEspectaculoName_Internalname ;
      private string edtTipoEspectaculoName_Jsonclick ;
      private string imgEspectaculoImagen_Internalname ;
      private string divLugarsectortable_Internalname ;
      private string lblTitlelugarsector_Internalname ;
      private string lblTitlelugarsector_Jsonclick ;
      private string divEspectaculofunciontable_Internalname ;
      private string lblTitleespectaculofuncion_Internalname ;
      private string lblTitleespectaculofuncion_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode16 ;
      private string edtLugarSectorId_Internalname ;
      private string edtLugarSectorName_Internalname ;
      private string edtLugarSectorCantidad_Internalname ;
      private string chkLugarSectorEstadoSector_Internalname ;
      private string edtLugarSectorPrecio_Internalname ;
      private string edtLugarSectorVendidas_Internalname ;
      private string edtLugarSectorDisponibles_Internalname ;
      private string sStyleString ;
      private string subGridespectaculo_lugarsector_Internalname ;
      private string sMode18 ;
      private string edtEspectaculoFuncionId_Internalname ;
      private string edtEspectaculoFuncionName_Internalname ;
      private string edtEspectaculoFuncionPrecio_Internalname ;
      private string subGridespectaculo_espectaculofuncion_Internalname ;
      private string AV14Pgmname ;
      private string hsh ;
      private string sMode15 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string imgprompt_27_Internalname ;
      private string sGXsfl_88_fel_idx="0001" ;
      private string subGridespectaculo_lugarsector_Class ;
      private string subGridespectaculo_lugarsector_Linesclass ;
      private string imgprompt_27_Link ;
      private string ROClassString ;
      private string edtLugarSectorId_Jsonclick ;
      private string edtLugarSectorName_Jsonclick ;
      private string edtLugarSectorCantidad_Jsonclick ;
      private string edtLugarSectorPrecio_Jsonclick ;
      private string edtLugarSectorVendidas_Jsonclick ;
      private string edtLugarSectorDisponibles_Jsonclick ;
      private string sGXsfl_104_fel_idx="0001" ;
      private string subGridespectaculo_espectaculofuncion_Class ;
      private string subGridespectaculo_espectaculofuncion_Linesclass ;
      private string edtEspectaculoFuncionId_Jsonclick ;
      private string edtEspectaculoFuncionName_Jsonclick ;
      private string edtEspectaculoFuncionPrecio_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string subGridespectaculo_lugarsector_Header ;
      private string subGridespectaculo_espectaculofuncion_Header ;
      private DateTime Z16EspectaculoFecha ;
      private DateTime A16EspectaculoFecha ;
      private bool Z41LugarSectorEstadoSector ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A26EspectaculoImagen_IsBlob ;
      private bool bGXsfl_88_Refreshing=false ;
      private bool bGXsfl_104_Refreshing=false ;
      private bool A41LugarSectorEstadoSector ;
      private bool returnInSub ;
      private bool n37LugarSectorVendidas ;
      private string Z2EspectaculoName ;
      private string Z48EspectaculoFuncionName ;
      private string A2EspectaculoName ;
      private string A5LugarName ;
      private string A6PaisName ;
      private string A8TipoEspectaculoName ;
      private string A40000EspectaculoImagen_GXI ;
      private string A48EspectaculoFuncionName ;
      private string A28LugarSectorName ;
      private string Z40000EspectaculoImagen_GXI ;
      private string Z5LugarName ;
      private string Z6PaisName ;
      private string Z8TipoEspectaculoName ;
      private string Z28LugarSectorName ;
      private string A26EspectaculoImagen ;
      private string Z26EspectaculoImagen ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridespectaculo_lugarsectorContainer ;
      private GXWebGrid Gridespectaculo_espectaculofuncionContainer ;
      private GXWebRow Gridespectaculo_lugarsectorRow ;
      private GXWebRow Gridespectaculo_espectaculofuncionRow ;
      private GXWebColumn Gridespectaculo_lugarsectorColumn ;
      private GXWebColumn Gridespectaculo_espectaculofuncionColumn ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkLugarSectorEstadoSector ;
      private IDataStoreProvider pr_default ;
      private string[] T000A12_A8TipoEspectaculoName ;
      private string[] T000A11_A5LugarName ;
      private short[] T000A11_A3PaisId ;
      private string[] T000A13_A6PaisName ;
      private short[] T000A14_A1EspectaculoId ;
      private string[] T000A14_A2EspectaculoName ;
      private DateTime[] T000A14_A16EspectaculoFecha ;
      private string[] T000A14_A5LugarName ;
      private string[] T000A14_A6PaisName ;
      private string[] T000A14_A8TipoEspectaculoName ;
      private string[] T000A14_A40000EspectaculoImagen_GXI ;
      private short[] T000A14_A4LugarId ;
      private short[] T000A14_A7TipoEspectaculoId ;
      private short[] T000A14_A3PaisId ;
      private string[] T000A14_A26EspectaculoImagen ;
      private string[] T000A15_A5LugarName ;
      private short[] T000A15_A3PaisId ;
      private string[] T000A16_A6PaisName ;
      private string[] T000A17_A8TipoEspectaculoName ;
      private short[] T000A18_A1EspectaculoId ;
      private short[] T000A10_A1EspectaculoId ;
      private string[] T000A10_A2EspectaculoName ;
      private DateTime[] T000A10_A16EspectaculoFecha ;
      private string[] T000A10_A40000EspectaculoImagen_GXI ;
      private short[] T000A10_A4LugarId ;
      private short[] T000A10_A7TipoEspectaculoId ;
      private string[] T000A10_A26EspectaculoImagen ;
      private short[] T000A19_A1EspectaculoId ;
      private short[] T000A20_A1EspectaculoId ;
      private short[] T000A9_A1EspectaculoId ;
      private string[] T000A9_A2EspectaculoName ;
      private DateTime[] T000A9_A16EspectaculoFecha ;
      private string[] T000A9_A40000EspectaculoImagen_GXI ;
      private short[] T000A9_A4LugarId ;
      private short[] T000A9_A7TipoEspectaculoId ;
      private string[] T000A9_A26EspectaculoImagen ;
      private short[] T000A21_A1EspectaculoId ;
      private string[] T000A25_A5LugarName ;
      private short[] T000A25_A3PaisId ;
      private string[] T000A26_A6PaisName ;
      private string[] T000A27_A8TipoEspectaculoName ;
      private short[] T000A28_A23EntradaId ;
      private short[] T000A29_A23EntradaId ;
      private short[] T000A30_A1EspectaculoId ;
      private short[] T000A32_A4LugarId ;
      private short[] T000A32_A1EspectaculoId ;
      private string[] T000A32_A28LugarSectorName ;
      private short[] T000A32_A29LugarSectorCantidad ;
      private bool[] T000A32_A41LugarSectorEstadoSector ;
      private short[] T000A32_A30LugarSectorPrecio ;
      private short[] T000A32_A27LugarSectorId ;
      private short[] T000A32_A37LugarSectorVendidas ;
      private bool[] T000A32_n37LugarSectorVendidas ;
      private string[] T000A6_A28LugarSectorName ;
      private short[] T000A6_A29LugarSectorCantidad ;
      private short[] T000A6_A30LugarSectorPrecio ;
      private short[] T000A8_A37LugarSectorVendidas ;
      private bool[] T000A8_n37LugarSectorVendidas ;
      private string[] T000A33_A28LugarSectorName ;
      private short[] T000A33_A29LugarSectorCantidad ;
      private short[] T000A33_A30LugarSectorPrecio ;
      private short[] T000A35_A37LugarSectorVendidas ;
      private bool[] T000A35_n37LugarSectorVendidas ;
      private short[] T000A36_A1EspectaculoId ;
      private short[] T000A36_A27LugarSectorId ;
      private short[] T000A5_A1EspectaculoId ;
      private bool[] T000A5_A41LugarSectorEstadoSector ;
      private short[] T000A5_A27LugarSectorId ;
      private short[] T000A4_A1EspectaculoId ;
      private bool[] T000A4_A41LugarSectorEstadoSector ;
      private short[] T000A4_A27LugarSectorId ;
      private string[] T000A40_A28LugarSectorName ;
      private short[] T000A40_A29LugarSectorCantidad ;
      private short[] T000A40_A30LugarSectorPrecio ;
      private short[] T000A42_A37LugarSectorVendidas ;
      private bool[] T000A42_n37LugarSectorVendidas ;
      private short[] T000A43_A24InvitacionId ;
      private short[] T000A44_A23EntradaId ;
      private short[] T000A45_A1EspectaculoId ;
      private short[] T000A45_A27LugarSectorId ;
      private short[] T000A46_A1EspectaculoId ;
      private short[] T000A46_A47EspectaculoFuncionId ;
      private string[] T000A46_A48EspectaculoFuncionName ;
      private short[] T000A46_A49EspectaculoFuncionPrecio ;
      private short[] T000A47_A1EspectaculoId ;
      private short[] T000A47_A47EspectaculoFuncionId ;
      private short[] T000A3_A1EspectaculoId ;
      private short[] T000A3_A47EspectaculoFuncionId ;
      private string[] T000A3_A48EspectaculoFuncionName ;
      private short[] T000A3_A49EspectaculoFuncionPrecio ;
      private short[] T000A2_A1EspectaculoId ;
      private short[] T000A2_A47EspectaculoFuncionId ;
      private string[] T000A2_A48EspectaculoFuncionName ;
      private short[] T000A2_A49EspectaculoFuncionPrecio ;
      private short[] T000A51_A24InvitacionId ;
      private short[] T000A52_A23EntradaId ;
      private short[] T000A53_A1EspectaculoId ;
      private short[] T000A53_A47EspectaculoFuncionId ;
      private GXWebForm Form ;
      private SdtTransactionContext AV9TrnContext ;
      private SdtTransactionContext_Attribute AV13TrnContextAtt ;
   }

   public class espectaculo__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new UpdateCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new ForEachCursor(def[27])
         ,new ForEachCursor(def[28])
         ,new ForEachCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new UpdateCursor(def[32])
         ,new UpdateCursor(def[33])
         ,new UpdateCursor(def[34])
         ,new ForEachCursor(def[35])
         ,new ForEachCursor(def[36])
         ,new ForEachCursor(def[37])
         ,new ForEachCursor(def[38])
         ,new ForEachCursor(def[39])
         ,new ForEachCursor(def[40])
         ,new ForEachCursor(def[41])
         ,new UpdateCursor(def[42])
         ,new UpdateCursor(def[43])
         ,new UpdateCursor(def[44])
         ,new ForEachCursor(def[45])
         ,new ForEachCursor(def[46])
         ,new ForEachCursor(def[47])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000A14;
          prmT000A14 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000A11;
          prmT000A11 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000A13;
          prmT000A13 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000A12;
          prmT000A12 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000A15;
          prmT000A15 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000A16;
          prmT000A16 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000A17;
          prmT000A17 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000A18;
          prmT000A18 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000A10;
          prmT000A10 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000A19;
          prmT000A19 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000A20;
          prmT000A20 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000A9;
          prmT000A9 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000A21;
          prmT000A21 = new Object[] {
          new ParDef("@EspectaculoName",GXType.NVarChar,40,0) ,
          new ParDef("@EspectaculoFecha",GXType.Date,8,0) ,
          new ParDef("@EspectaculoImagen",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@EspectaculoImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="Espectaculo", Fld="EspectaculoImagen"} ,
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000A22;
          prmT000A22 = new Object[] {
          new ParDef("@EspectaculoName",GXType.NVarChar,40,0) ,
          new ParDef("@EspectaculoFecha",GXType.Date,8,0) ,
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000A23;
          prmT000A23 = new Object[] {
          new ParDef("@EspectaculoImagen",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@EspectaculoImagen_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Espectaculo", Fld="EspectaculoImagen"} ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000A24;
          prmT000A24 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000A28;
          prmT000A28 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000A29;
          prmT000A29 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000A30;
          prmT000A30 = new Object[] {
          };
          Object[] prmT000A32;
          prmT000A32 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000A6;
          prmT000A6 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000A8;
          prmT000A8 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000A33;
          prmT000A33 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000A35;
          prmT000A35 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000A36;
          prmT000A36 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000A5;
          prmT000A5 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000A4;
          prmT000A4 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000A37;
          prmT000A37 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorEstadoSector",GXType.Boolean,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000A38;
          prmT000A38 = new Object[] {
          new ParDef("@LugarSectorEstadoSector",GXType.Boolean,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000A39;
          prmT000A39 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000A43;
          prmT000A43 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000A44;
          prmT000A44 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000A45;
          prmT000A45 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000A46;
          prmT000A46 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmT000A47;
          prmT000A47 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmT000A3;
          prmT000A3 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmT000A2;
          prmT000A2 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmT000A48;
          prmT000A48 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionName",GXType.NVarChar,40,0) ,
          new ParDef("@EspectaculoFuncionPrecio",GXType.Int16,4,0)
          };
          Object[] prmT000A49;
          prmT000A49 = new Object[] {
          new ParDef("@EspectaculoFuncionName",GXType.NVarChar,40,0) ,
          new ParDef("@EspectaculoFuncionPrecio",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmT000A50;
          prmT000A50 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmT000A51;
          prmT000A51 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmT000A52;
          prmT000A52 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@EspectaculoFuncionId",GXType.Int16,4,0)
          };
          Object[] prmT000A53;
          prmT000A53 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000A25;
          prmT000A25 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0)
          };
          Object[] prmT000A26;
          prmT000A26 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmT000A27;
          prmT000A27 = new Object[] {
          new ParDef("@TipoEspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmT000A40;
          prmT000A40 = new Object[] {
          new ParDef("@LugarId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          Object[] prmT000A42;
          prmT000A42 = new Object[] {
          new ParDef("@EspectaculoId",GXType.Int16,4,0) ,
          new ParDef("@LugarSectorId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000A2", "SELECT [EspectaculoId], [EspectaculoFuncionId], [EspectaculoFuncionName], [EspectaculoFuncionPrecio] FROM [EspectaculoFuncion] WITH (UPDLOCK) WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoFuncionId] = @EspectaculoFuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A3", "SELECT [EspectaculoId], [EspectaculoFuncionId], [EspectaculoFuncionName], [EspectaculoFuncionPrecio] FROM [EspectaculoFuncion] WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoFuncionId] = @EspectaculoFuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A4", "SELECT [EspectaculoId], [LugarSectorEstadoSector], [LugarSectorId] FROM [EspectaculoLugarSector] WITH (UPDLOCK) WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A5", "SELECT [EspectaculoId], [LugarSectorEstadoSector], [LugarSectorId] FROM [EspectaculoLugarSector] WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A6", "SELECT [LugarSectorName], [LugarSectorCantidad], [LugarSectorPrecio] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A8", "SELECT COALESCE( T1.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (SELECT COUNT(*) AS LugarSectorVendidas, [EspectaculoId], [LugarSectorId] FROM [Entrada] GROUP BY [EspectaculoId], [LugarSectorId] ) T1 WHERE T1.[EspectaculoId] = @EspectaculoId AND T1.[LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A9", "SELECT [EspectaculoId], [EspectaculoName], [EspectaculoFecha], [EspectaculoImagen_GXI], [LugarId], [TipoEspectaculoId], [EspectaculoImagen] FROM [Espectaculo] WITH (UPDLOCK) WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A10", "SELECT [EspectaculoId], [EspectaculoName], [EspectaculoFecha], [EspectaculoImagen_GXI], [LugarId], [TipoEspectaculoId], [EspectaculoImagen] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A11", "SELECT [LugarName], [PaisId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A12", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A13", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A14", "SELECT TM1.[EspectaculoId], TM1.[EspectaculoName], TM1.[EspectaculoFecha], T2.[LugarName], T3.[PaisName], T4.[TipoEspectaculoName], TM1.[EspectaculoImagen_GXI], TM1.[LugarId], TM1.[TipoEspectaculoId], T2.[PaisId], TM1.[EspectaculoImagen] FROM ((([Espectaculo] TM1 INNER JOIN [Lugar] T2 ON T2.[LugarId] = TM1.[LugarId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = T2.[PaisId]) INNER JOIN [TipoEspectaculo] T4 ON T4.[TipoEspectaculoId] = TM1.[TipoEspectaculoId]) WHERE TM1.[EspectaculoId] = @EspectaculoId ORDER BY TM1.[EspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A15", "SELECT [LugarName], [PaisId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A16", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A17", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A18", "SELECT [EspectaculoId] FROM [Espectaculo] WHERE [EspectaculoId] = @EspectaculoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A19", "SELECT TOP 1 [EspectaculoId] FROM [Espectaculo] WHERE ( [EspectaculoId] > @EspectaculoId) ORDER BY [EspectaculoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A19,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A20", "SELECT TOP 1 [EspectaculoId] FROM [Espectaculo] WHERE ( [EspectaculoId] < @EspectaculoId) ORDER BY [EspectaculoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A20,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A21", "INSERT INTO [Espectaculo]([EspectaculoName], [EspectaculoFecha], [EspectaculoImagen], [EspectaculoImagen_GXI], [LugarId], [TipoEspectaculoId]) VALUES(@EspectaculoName, @EspectaculoFecha, @EspectaculoImagen, @EspectaculoImagen_GXI, @LugarId, @TipoEspectaculoId); SELECT SCOPE_IDENTITY()",true, GxErrorMask.GX_NOMASK, false, this,prmT000A21,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A22", "UPDATE [Espectaculo] SET [EspectaculoName]=@EspectaculoName, [EspectaculoFecha]=@EspectaculoFecha, [LugarId]=@LugarId, [TipoEspectaculoId]=@TipoEspectaculoId  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmT000A22)
             ,new CursorDef("T000A23", "UPDATE [Espectaculo] SET [EspectaculoImagen]=@EspectaculoImagen, [EspectaculoImagen_GXI]=@EspectaculoImagen_GXI  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmT000A23)
             ,new CursorDef("T000A24", "DELETE FROM [Espectaculo]  WHERE [EspectaculoId] = @EspectaculoId", GxErrorMask.GX_NOMASK,prmT000A24)
             ,new CursorDef("T000A25", "SELECT [LugarName], [PaisId] FROM [Lugar] WHERE [LugarId] = @LugarId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A26", "SELECT [PaisName] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A26,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A27", "SELECT [TipoEspectaculoName] FROM [TipoEspectaculo] WHERE [TipoEspectaculoId] = @TipoEspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A27,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A28", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A28,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A29", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE [EspectaculoId] = @EspectaculoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A29,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A30", "SELECT [EspectaculoId] FROM [Espectaculo] ORDER BY [EspectaculoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A30,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A32", "SELECT T2.[LugarId], T1.[EspectaculoId], T2.[LugarSectorName], T2.[LugarSectorCantidad], T1.[LugarSectorEstadoSector], T2.[LugarSectorPrecio], T1.[LugarSectorId], COALESCE( T3.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (([EspectaculoLugarSector] T1 LEFT JOIN [LugarSector] T2 ON T2.[LugarId] = @LugarId AND T2.[LugarSectorId] = T1.[LugarSectorId]) LEFT JOIN (SELECT COUNT(*) AS LugarSectorVendidas, [EspectaculoId], [LugarSectorId] FROM [Entrada] GROUP BY [EspectaculoId], [LugarSectorId] ) T3 ON T3.[EspectaculoId] = T1.[EspectaculoId] AND T3.[LugarSectorId] = T1.[LugarSectorId]) WHERE T1.[EspectaculoId] = @EspectaculoId and T1.[LugarSectorId] = @LugarSectorId ORDER BY T1.[EspectaculoId], T1.[LugarSectorId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A32,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A33", "SELECT [LugarSectorName], [LugarSectorCantidad], [LugarSectorPrecio] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A33,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A35", "SELECT COALESCE( T1.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (SELECT COUNT(*) AS LugarSectorVendidas, [EspectaculoId], [LugarSectorId] FROM [Entrada] GROUP BY [EspectaculoId], [LugarSectorId] ) T1 WHERE T1.[EspectaculoId] = @EspectaculoId AND T1.[LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A35,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A36", "SELECT [EspectaculoId], [LugarSectorId] FROM [EspectaculoLugarSector] WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A36,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A37", "INSERT INTO [EspectaculoLugarSector]([EspectaculoId], [LugarSectorEstadoSector], [LugarSectorId]) VALUES(@EspectaculoId, @LugarSectorEstadoSector, @LugarSectorId)", GxErrorMask.GX_NOMASK,prmT000A37)
             ,new CursorDef("T000A38", "UPDATE [EspectaculoLugarSector] SET [LugarSectorEstadoSector]=@LugarSectorEstadoSector  WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId", GxErrorMask.GX_NOMASK,prmT000A38)
             ,new CursorDef("T000A39", "DELETE FROM [EspectaculoLugarSector]  WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId", GxErrorMask.GX_NOMASK,prmT000A39)
             ,new CursorDef("T000A40", "SELECT [LugarSectorName], [LugarSectorCantidad], [LugarSectorPrecio] FROM [LugarSector] WHERE [LugarId] = @LugarId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A40,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A42", "SELECT COALESCE( T1.[LugarSectorVendidas], 0) AS LugarSectorVendidas FROM (SELECT COUNT(*) AS LugarSectorVendidas, [EspectaculoId], [LugarSectorId] FROM [Entrada] GROUP BY [EspectaculoId], [LugarSectorId] ) T1 WHERE T1.[EspectaculoId] = @EspectaculoId AND T1.[LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A42,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A43", "SELECT TOP 1 [InvitacionId] FROM [Invitacion] WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A43,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A44", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE [EspectaculoId] = @EspectaculoId AND [LugarSectorId] = @LugarSectorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A44,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A45", "SELECT [EspectaculoId], [LugarSectorId] FROM [EspectaculoLugarSector] WHERE [EspectaculoId] = @EspectaculoId ORDER BY [EspectaculoId], [LugarSectorId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A45,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A46", "SELECT [EspectaculoId], [EspectaculoFuncionId], [EspectaculoFuncionName], [EspectaculoFuncionPrecio] FROM [EspectaculoFuncion] WHERE [EspectaculoId] = @EspectaculoId and [EspectaculoFuncionId] = @EspectaculoFuncionId ORDER BY [EspectaculoId], [EspectaculoFuncionId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A46,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A47", "SELECT [EspectaculoId], [EspectaculoFuncionId] FROM [EspectaculoFuncion] WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoFuncionId] = @EspectaculoFuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A47,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A48", "INSERT INTO [EspectaculoFuncion]([EspectaculoId], [EspectaculoFuncionId], [EspectaculoFuncionName], [EspectaculoFuncionPrecio]) VALUES(@EspectaculoId, @EspectaculoFuncionId, @EspectaculoFuncionName, @EspectaculoFuncionPrecio)", GxErrorMask.GX_NOMASK,prmT000A48)
             ,new CursorDef("T000A49", "UPDATE [EspectaculoFuncion] SET [EspectaculoFuncionName]=@EspectaculoFuncionName, [EspectaculoFuncionPrecio]=@EspectaculoFuncionPrecio  WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoFuncionId] = @EspectaculoFuncionId", GxErrorMask.GX_NOMASK,prmT000A49)
             ,new CursorDef("T000A50", "DELETE FROM [EspectaculoFuncion]  WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoFuncionId] = @EspectaculoFuncionId", GxErrorMask.GX_NOMASK,prmT000A50)
             ,new CursorDef("T000A51", "SELECT TOP 1 [InvitacionId] FROM [Invitacion] WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoFuncionId] = @EspectaculoFuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A51,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A52", "SELECT TOP 1 [EntradaId] FROM [Entrada] WHERE [EspectaculoId] = @EspectaculoId AND [EspectaculoFuncionId] = @EspectaculoFuncionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A52,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A53", "SELECT [EspectaculoId], [EspectaculoFuncionId] FROM [EspectaculoFuncion] WHERE [EspectaculoId] = @EspectaculoId ORDER BY [EspectaculoId], [EspectaculoFuncionId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A53,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 23 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 24 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 25 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 26 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 27 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 28 :
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
             case 29 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 31 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 35 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 36 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 37 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 38 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 39 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 40 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 41 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 45 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 46 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 47 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
