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
   public class aumentarpreciosectores : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public aumentarpreciosectores( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public aumentarpreciosectores( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavPaisid = new GXCombobox();
         dynavEspectaculoid = new GXCombobox();
         dynavLugarsectorid = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vESPECTACULOID") == 0 )
            {
               AV5PaisId = (short)(NumberUtil.Val( GetPar( "PaisId"), "."));
               AssignAttri("", false, "AV5PaisId", StringUtil.LTrimStr( (decimal)(AV5PaisId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvESPECTACULOID252( AV5PaisId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vLUGARSECTORID") == 0 )
            {
               AV6EspectaculoId = (short)(NumberUtil.Val( GetPar( "EspectaculoId"), "."));
               AssignAttri("", false, "AV6EspectaculoId", StringUtil.LTrimStr( (decimal)(AV6EspectaculoId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvLUGARSECTORID252( AV6EspectaculoId) ;
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA252( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START252( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 552120), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 552120), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 552120), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20228281414876", false, true);
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
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("aumentarpreciosectores.aspx") +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE252( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT252( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("aumentarpreciosectores.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "AumentarPrecioSectores" ;
      }

      public override string GetPgmdesc( )
      {
         return "Aumentar Precio Sectores" ;
      }

      protected void WB250( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavPaisid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavPaisid_Internalname, "Pais", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavPaisid, dynavPaisid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV5PaisId), 4, 0)), 1, dynavPaisid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavPaisid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,8);\"", "", true, 1, "HLP_AumentarPrecioSectores.htm");
            dynavPaisid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5PaisId), 4, 0));
            AssignProp("", false, dynavPaisid_Internalname, "Values", (string)(dynavPaisid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavEspectaculoid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavEspectaculoid_Internalname, "Espectaculo", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavEspectaculoid, dynavEspectaculoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0)), 1, dynavEspectaculoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavEspectaculoid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,13);\"", "", true, 1, "HLP_AumentarPrecioSectores.htm");
            dynavEspectaculoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0));
            AssignProp("", false, dynavEspectaculoid_Internalname, "Values", (string)(dynavEspectaculoid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavLugarsectorid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavLugarsectorid_Internalname, "Sector", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavLugarsectorid, dynavLugarsectorid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7LugarSectorId), 4, 0)), 1, dynavLugarsectorid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavLugarsectorid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "", true, 1, "HLP_AumentarPrecioSectores.htm");
            dynavLugarsectorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7LugarSectorId), 4, 0));
            AssignProp("", false, dynavLugarsectorid_Internalname, "Values", (string)(dynavLugarsectorid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavPorcentaje_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavPorcentaje_Internalname, "Porcentaje de aumento", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavPorcentaje_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8Porcentaje), 4, 0, ",", "")), StringUtil.LTrim( ((edtavPorcentaje_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8Porcentaje), "ZZZ9") : context.localUtil.Format( (decimal)(AV8Porcentaje), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,23);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavPorcentaje_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavPorcentaje_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AumentarPrecioSectores.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGuardar_Internalname, "", "Guardar", bttGuardar_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GUARDAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AumentarPrecioSectores.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START252( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_10-161416", 0) ;
            }
            Form.Meta.addItem("description", "Aumentar Precio Sectores", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP250( ) ;
      }

      protected void WS252( )
      {
         START252( ) ;
         EVT252( ) ;
      }

      protected void EVT252( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E11252 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GUARDAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
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
      }

      protected void WE252( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA252( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = dynavPaisid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         GXVvESPECTACULOID_html252( AV5PaisId) ;
         GXVvLUGARSECTORID_html252( AV6EspectaculoId) ;
         /* End function dynload_actions */
      }

      protected void GXDLVvPAISID251( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvPAISID_data251( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvPAISID_html251( )
      {
         short gxdynajaxvalue;
         GXDLVvPAISID_data251( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavPaisid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavPaisid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavPaisid.ItemCount > 0 )
         {
            AV5PaisId = (short)(NumberUtil.Val( dynavPaisid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5PaisId), 4, 0))), "."));
            AssignAttri("", false, "AV5PaisId", StringUtil.LTrimStr( (decimal)(AV5PaisId), 4, 0));
         }
      }

      protected void GXDLVvPAISID_data251( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00252 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00252_A3PaisId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00252_A6PaisName[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvESPECTACULOID252( short AV5PaisId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvESPECTACULOID_data252( AV5PaisId) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvESPECTACULOID_html252( short AV5PaisId )
      {
         short gxdynajaxvalue;
         GXDLVvESPECTACULOID_data252( AV5PaisId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavEspectaculoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavEspectaculoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavEspectaculoid.ItemCount > 0 )
         {
            AV6EspectaculoId = (short)(NumberUtil.Val( dynavEspectaculoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0))), "."));
            AssignAttri("", false, "AV6EspectaculoId", StringUtil.LTrimStr( (decimal)(AV6EspectaculoId), 4, 0));
         }
      }

      protected void GXDLVvESPECTACULOID_data252( short AV5PaisId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00253 */
         pr_default.execute(1, new Object[] {AV5PaisId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00253_A1EspectaculoId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00253_A2EspectaculoName[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvLUGARSECTORID252( short AV6EspectaculoId )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvLUGARSECTORID_data252( AV6EspectaculoId) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvLUGARSECTORID_html252( short AV6EspectaculoId )
      {
         short gxdynajaxvalue;
         GXDLVvLUGARSECTORID_data252( AV6EspectaculoId) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavLugarsectorid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavLugarsectorid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavLugarsectorid.ItemCount > 0 )
         {
            AV7LugarSectorId = (short)(NumberUtil.Val( dynavLugarsectorid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7LugarSectorId), 4, 0))), "."));
            AssignAttri("", false, "AV7LugarSectorId", StringUtil.LTrimStr( (decimal)(AV7LugarSectorId), 4, 0));
         }
      }

      protected void GXDLVvLUGARSECTORID_data252( short AV6EspectaculoId )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00254 */
         pr_default.execute(2, new Object[] {AV6EspectaculoId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00254_A27LugarSectorId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00254_A28LugarSectorName[0]);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynavPaisid.Name = "vPAISID";
            dynavPaisid.WebTags = "";
            dynavPaisid.removeAllItems();
            /* Using cursor H00255 */
            pr_default.execute(3);
            while ( (pr_default.getStatus(3) != 101) )
            {
               dynavPaisid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00255_A3PaisId[0]), 4, 0)), H00255_A6PaisName[0], 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            if ( dynavPaisid.ItemCount > 0 )
            {
               AV5PaisId = (short)(NumberUtil.Val( dynavPaisid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5PaisId), 4, 0))), "."));
               AssignAttri("", false, "AV5PaisId", StringUtil.LTrimStr( (decimal)(AV5PaisId), 4, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavPaisid.ItemCount > 0 )
         {
            AV5PaisId = (short)(NumberUtil.Val( dynavPaisid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5PaisId), 4, 0))), "."));
            AssignAttri("", false, "AV5PaisId", StringUtil.LTrimStr( (decimal)(AV5PaisId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavPaisid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5PaisId), 4, 0));
            AssignProp("", false, dynavPaisid_Internalname, "Values", dynavPaisid.ToJavascriptSource(), true);
         }
         if ( dynavEspectaculoid.ItemCount > 0 )
         {
            AV6EspectaculoId = (short)(NumberUtil.Val( dynavEspectaculoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0))), "."));
            AssignAttri("", false, "AV6EspectaculoId", StringUtil.LTrimStr( (decimal)(AV6EspectaculoId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavEspectaculoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0));
            AssignProp("", false, dynavEspectaculoid_Internalname, "Values", dynavEspectaculoid.ToJavascriptSource(), true);
         }
         if ( dynavLugarsectorid.ItemCount > 0 )
         {
            AV7LugarSectorId = (short)(NumberUtil.Val( dynavLugarsectorid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7LugarSectorId), 4, 0))), "."));
            AssignAttri("", false, "AV7LugarSectorId", StringUtil.LTrimStr( (decimal)(AV7LugarSectorId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLugarsectorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7LugarSectorId), 4, 0));
            AssignProp("", false, dynavLugarsectorid_Internalname, "Values", dynavLugarsectorid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF252( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF252( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E11252 ();
            WB250( ) ;
         }
      }

      protected void send_integrity_lvl_hashes252( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP250( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            dynavPaisid.CurrentValue = cgiGet( dynavPaisid_Internalname);
            AV5PaisId = (short)(NumberUtil.Val( cgiGet( dynavPaisid_Internalname), "."));
            AssignAttri("", false, "AV5PaisId", StringUtil.LTrimStr( (decimal)(AV5PaisId), 4, 0));
            dynavEspectaculoid.CurrentValue = cgiGet( dynavEspectaculoid_Internalname);
            AV6EspectaculoId = (short)(NumberUtil.Val( cgiGet( dynavEspectaculoid_Internalname), "."));
            AssignAttri("", false, "AV6EspectaculoId", StringUtil.LTrimStr( (decimal)(AV6EspectaculoId), 4, 0));
            dynavLugarsectorid.CurrentValue = cgiGet( dynavLugarsectorid_Internalname);
            AV7LugarSectorId = (short)(NumberUtil.Val( cgiGet( dynavLugarsectorid_Internalname), "."));
            AssignAttri("", false, "AV7LugarSectorId", StringUtil.LTrimStr( (decimal)(AV7LugarSectorId), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavPorcentaje_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavPorcentaje_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vPORCENTAJE");
               GX_FocusControl = edtavPorcentaje_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8Porcentaje = 0;
               AssignAttri("", false, "AV8Porcentaje", StringUtil.LTrimStr( (decimal)(AV8Porcentaje), 4, 0));
            }
            else
            {
               AV8Porcentaje = (short)(context.localUtil.CToN( cgiGet( edtavPorcentaje_Internalname), ",", "."));
               AssignAttri("", false, "AV8Porcentaje", StringUtil.LTrimStr( (decimal)(AV8Porcentaje), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E11252( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA252( ) ;
         WS252( ) ;
         WE252( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228281414887", true, true);
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
         context.AddJavascriptSource("aumentarpreciosectores.js", "?20228281414887", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavPaisid.Name = "vPAISID";
         dynavPaisid.WebTags = "";
         dynavPaisid.removeAllItems();
         /* Using cursor H00256 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            dynavPaisid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H00256_A3PaisId[0]), 4, 0)), H00256_A6PaisName[0], 0);
            pr_default.readNext(4);
         }
         pr_default.close(4);
         if ( dynavPaisid.ItemCount > 0 )
         {
            AV5PaisId = (short)(NumberUtil.Val( dynavPaisid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5PaisId), 4, 0))), "."));
            AssignAttri("", false, "AV5PaisId", StringUtil.LTrimStr( (decimal)(AV5PaisId), 4, 0));
         }
         dynavEspectaculoid.Name = "vESPECTACULOID";
         dynavEspectaculoid.WebTags = "";
         dynavLugarsectorid.Name = "vLUGARSECTORID";
         dynavLugarsectorid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         dynavPaisid_Internalname = "vPAISID";
         dynavEspectaculoid_Internalname = "vESPECTACULOID";
         dynavLugarsectorid_Internalname = "vLUGARSECTORID";
         edtavPorcentaje_Internalname = "vPORCENTAJE";
         bttGuardar_Internalname = "GUARDAR";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtavPorcentaje_Jsonclick = "";
         edtavPorcentaje_Enabled = 1;
         dynavLugarsectorid_Jsonclick = "";
         dynavLugarsectorid.Enabled = 1;
         dynavEspectaculoid_Jsonclick = "";
         dynavEspectaculoid.Enabled = 1;
         dynavPaisid_Jsonclick = "";
         dynavPaisid.Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Aumentar Precio Sectores";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public void Validv_Paisid( )
      {
         AV5PaisId = (short)(NumberUtil.Val( dynavPaisid.CurrentValue, "."));
         AV6EspectaculoId = (short)(NumberUtil.Val( dynavEspectaculoid.CurrentValue, "."));
         GXVvESPECTACULOID_html252( AV5PaisId) ;
         dynload_actions( ) ;
         if ( dynavEspectaculoid.ItemCount > 0 )
         {
            AV6EspectaculoId = (short)(NumberUtil.Val( dynavEspectaculoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0))), "."));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavEspectaculoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "AV6EspectaculoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6EspectaculoId), 4, 0, ".", "")));
         dynavEspectaculoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6EspectaculoId), 4, 0));
         AssignProp("", false, dynavEspectaculoid_Internalname, "Values", dynavEspectaculoid.ToJavascriptSource(), true);
      }

      public void Validv_Espectaculoid( )
      {
         AV6EspectaculoId = (short)(NumberUtil.Val( dynavEspectaculoid.CurrentValue, "."));
         AV7LugarSectorId = (short)(NumberUtil.Val( dynavLugarsectorid.CurrentValue, "."));
         GXVvLUGARSECTORID_html252( AV6EspectaculoId) ;
         dynload_actions( ) ;
         if ( dynavLugarsectorid.ItemCount > 0 )
         {
            AV7LugarSectorId = (short)(NumberUtil.Val( dynavLugarsectorid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7LugarSectorId), 4, 0))), "."));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavLugarsectorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7LugarSectorId), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "AV7LugarSectorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7LugarSectorId), 4, 0, ".", "")));
         dynavLugarsectorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7LugarSectorId), 4, 0));
         AssignProp("", false, dynavLugarsectorid_Internalname, "Values", dynavLugarsectorid.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'dynavPaisid'},{av:'AV5PaisId',fld:'vPAISID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALIDV_PAISID","{handler:'Validv_Paisid',iparms:[{av:'dynavPaisid'},{av:'AV5PaisId',fld:'vPAISID',pic:'ZZZ9'},{av:'dynavEspectaculoid'},{av:'AV6EspectaculoId',fld:'vESPECTACULOID',pic:'ZZZ9'}]");
         setEventMetadata("VALIDV_PAISID",",oparms:[{av:'dynavEspectaculoid'},{av:'AV6EspectaculoId',fld:'vESPECTACULOID',pic:'ZZZ9'}]}");
         setEventMetadata("VALIDV_ESPECTACULOID","{handler:'Validv_Espectaculoid',iparms:[{av:'dynavEspectaculoid'},{av:'AV6EspectaculoId',fld:'vESPECTACULOID',pic:'ZZZ9'},{av:'dynavLugarsectorid'},{av:'AV7LugarSectorId',fld:'vLUGARSECTORID',pic:'ZZZ9'}]");
         setEventMetadata("VALIDV_ESPECTACULOID",",oparms:[{av:'dynavLugarsectorid'},{av:'AV7LugarSectorId',fld:'vLUGARSECTORID',pic:'ZZZ9'}]}");
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttGuardar_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H00252_A3PaisId = new short[1] ;
         H00252_A6PaisName = new string[] {""} ;
         H00253_A4LugarId = new short[1] ;
         H00253_A1EspectaculoId = new short[1] ;
         H00253_A2EspectaculoName = new string[] {""} ;
         H00253_A3PaisId = new short[1] ;
         H00254_A4LugarId = new short[1] ;
         H00254_A27LugarSectorId = new short[1] ;
         H00254_A28LugarSectorName = new string[] {""} ;
         H00254_A1EspectaculoId = new short[1] ;
         H00255_A3PaisId = new short[1] ;
         H00255_A6PaisName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         H00256_A3PaisId = new short[1] ;
         H00256_A6PaisName = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aumentarpreciosectores__default(),
            new Object[][] {
                new Object[] {
               H00252_A3PaisId, H00252_A6PaisName
               }
               , new Object[] {
               H00253_A4LugarId, H00253_A1EspectaculoId, H00253_A2EspectaculoName, H00253_A3PaisId
               }
               , new Object[] {
               H00254_A4LugarId, H00254_A27LugarSectorId, H00254_A28LugarSectorName, H00254_A1EspectaculoId
               }
               , new Object[] {
               H00255_A3PaisId, H00255_A6PaisName
               }
               , new Object[] {
               H00256_A3PaisId, H00256_A6PaisName
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV5PaisId ;
      private short AV6EspectaculoId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV7LugarSectorId ;
      private short AV8Porcentaje ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short ZV6EspectaculoId ;
      private short ZV7LugarSectorId ;
      private int edtavPorcentaje_Enabled ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string dynavPaisid_Internalname ;
      private string TempTags ;
      private string dynavPaisid_Jsonclick ;
      private string dynavEspectaculoid_Internalname ;
      private string dynavEspectaculoid_Jsonclick ;
      private string dynavLugarsectorid_Internalname ;
      private string dynavLugarsectorid_Jsonclick ;
      private string edtavPorcentaje_Internalname ;
      private string edtavPorcentaje_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string bttGuardar_Internalname ;
      private string bttGuardar_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavPaisid ;
      private GXCombobox dynavEspectaculoid ;
      private GXCombobox dynavLugarsectorid ;
      private IDataStoreProvider pr_default ;
      private short[] H00252_A3PaisId ;
      private string[] H00252_A6PaisName ;
      private short[] H00253_A4LugarId ;
      private short[] H00253_A1EspectaculoId ;
      private string[] H00253_A2EspectaculoName ;
      private short[] H00253_A3PaisId ;
      private short[] H00254_A4LugarId ;
      private short[] H00254_A27LugarSectorId ;
      private string[] H00254_A28LugarSectorName ;
      private short[] H00254_A1EspectaculoId ;
      private short[] H00255_A3PaisId ;
      private string[] H00255_A6PaisName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short[] H00256_A3PaisId ;
      private string[] H00256_A6PaisName ;
      private GXWebForm Form ;
   }

   public class aumentarpreciosectores__default : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00252;
          prmH00252 = new Object[] {
          };
          Object[] prmH00253;
          prmH00253 = new Object[] {
          new ParDef("@AV5PaisId",GXType.Int16,4,0)
          };
          Object[] prmH00254;
          prmH00254 = new Object[] {
          new ParDef("@AV6EspectaculoId",GXType.Int16,4,0)
          };
          Object[] prmH00255;
          prmH00255 = new Object[] {
          };
          Object[] prmH00256;
          prmH00256 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00252", "SELECT [PaisId], [PaisName] FROM [Pais] ORDER BY [PaisName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00252,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00253", "SELECT T2.[LugarId], T1.[EspectaculoId], T1.[EspectaculoName], T2.[PaisId] FROM ([Espectaculo] T1 INNER JOIN [Lugar] T2 ON T2.[LugarId] = T1.[LugarId]) WHERE T2.[PaisId] = @AV5PaisId ORDER BY T1.[EspectaculoName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00253,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00254", "SELECT T3.[LugarId], T1.[LugarSectorId], T3.[LugarSectorName], T1.[EspectaculoId] FROM (([EspectaculoLugarSector] T1 INNER JOIN [Espectaculo] T2 ON T2.[EspectaculoId] = T1.[EspectaculoId]) LEFT JOIN [LugarSector] T3 ON T3.[LugarId] = T2.[LugarId] AND T3.[LugarSectorId] = T1.[LugarSectorId]) WHERE T1.[EspectaculoId] = @AV6EspectaculoId ORDER BY T3.[LugarSectorName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00254,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00255", "SELECT [PaisId], [PaisName] FROM [Pais] ORDER BY [PaisName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00255,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00256", "SELECT [PaisId], [PaisName] FROM [Pais] ORDER BY [PaisName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00256,0, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
