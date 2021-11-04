import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './components/common/nav/nav.component';
import { LayoutModule } from '@angular/cdk/layout';


import { MatImportModule } from './modules/common/mat-import/mat-import.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MultilevelMenuService, NgMaterialMultilevelMenuModule } from 'ng-material-multilevel-menu';
import { NotifyService } from './services/common/notify.service';
import { AuthenticationService } from './services/authentication/authentication.service';
import { UserService } from './services/authentication/user.service';
import { HomeComponent } from './components/home/home.component';
import { ConfirmDialogComponent } from './dialogs/confirm-dialog/confirm-dialog.component';
import { SettingsComponent } from './components/admin/settings/settings.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './guards/auth-guard';
import { JwtTokenInterceptor } from './interceptors/jwt-token-interceptor';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { DbUtilityService } from './services/data/db/db-utility.service';
import { BrandViewComponent } from './components/brand/brand-view/brand-view.component';
import { BrandCreateComponent } from './components/brand/brand-create/brand-create.component';
import { BrandEditComponent } from './components/brand/brand-edit/brand-edit.component';
import { BrandService } from './services/data/brand.service';
import { CategoryViewComponent } from './components/category/category-view/category-view.component';
import { CategoryService } from './services/data/category.service';
import { ShippingViewComponent } from './components/shipping/shipping-view/shipping-view.component';
import { ShippingCreateComponent } from './components/shipping/shipping-create/shipping-create.component';
import { ShippingEditComponent } from './components/shipping/shipping-edit/shipping-edit.component';
import { ShippingService } from './services/data/shipping.service';
import { SizeService } from './services/data/size.service';
import { SizeViewComponent } from './components/size/size-view/size-view.component';
import { SizeCreateComponent } from './components/size/size-create/size-create.component';
import { SizeEditComponent } from './components/size/size-edit/size-edit.component';
import { SubcategoryService } from './services/data/subcategory.service';
import { SubcategoryViewComponent } from './components/subcategory/subcategory-view/subcategory-view.component';
import { SubcategoryCreateComponent } from './components/subcategory/subcategory-create/subcategory-create.component';
import { SubcategoryEditComponent } from './components/subcategory/subcategory-edit/subcategory-edit.component';
import { CategoryCreateComponent } from './components/category/category-create/category-create.component';
import { CategoryEditComponent } from './components/category/category-edit/category-edit.component';
import { UserViewComponent } from './components/admin/user-management/user-view/user-view.component';
import { UserDataService } from './services/data/user-data.service';

import { CampaignService } from './services/data/campaign.service';
import { CampaignViewComponent } from './components/campaign/campaign-view/campaign-view.component';
import { CampaignCreateComponent } from './components/campaign/campaign-create/campaign-create.component';
import { CampaignEditComponent } from './components/campaign/campaign-edit/campaign-edit.component';
import { MatNativeDateModule } from '@angular/material/core';
import { DatePipe } from '@angular/common';
import { HttpErrorInterceptor } from './interceptors/http-error-interceptor';
import { ErrorHandler } from '@angular/core';
import { GlobalErrorHandler } from './handlers/global-error-handler';
import { CustomerService } from './services/data/customer.service';
import { CustomerViewComponent } from './components/customer/customer-view/customer-view.component';
import { SignalrService } from './services/persistent/signalr.service';
import { APP_INITIALIZER } from '@angular/core';
import { ProductViewComponent } from './components/product/product-view/product-view.component';
import { ProductCreateComponent } from './components/product/product-create/product-create.component';
import { ProductEditComponent } from './components/product/product-edit/product-edit.component';
import { BrandProductComponent } from './components/brand/brand-product/brand-product.component';
import { ProductService } from './services/data/product.service';
import { ConfigLabelComponent } from './components/subcategory/config-label/config-label.component';
import { ProductConfigService } from './services/data/product-config.service';
import { DecimalPipe } from '@angular/common';
import { NgxMatFileInputModule } from '@angular-material-components/file-input';
import { ProductInfoComponent } from './components/product/product-info/product-info.component';
import { NgImageSliderModule } from 'ng-image-slider';
import { OrderViewComponent } from './components/order/order-view/order-view.component';
import { OrderService } from './services/data/order.service';
import { OrderSummaryComponent } from './components/order/order-summary/order-summary.component';
import { PaymentService } from './services/data/payment.service';
import { PaymentCreateComponent } from './components/payment/payment-create/payment-create.component';
import { PaymentEditComponent } from './components/payment/payment-edit/payment-edit.component';
import { PaymentViewComponent } from './components/payment/payment-view/payment-view.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    ConfirmDialogComponent,
    SettingsComponent,
    LoginComponent,
    BrandViewComponent,
    BrandCreateComponent,
    BrandEditComponent,
    CategoryViewComponent,
    ShippingViewComponent,
    ShippingCreateComponent,
    ShippingEditComponent,
    SizeViewComponent,
    SizeCreateComponent,
    SizeEditComponent,
    SubcategoryViewComponent,
    SubcategoryCreateComponent,
    SubcategoryEditComponent,
    CategoryCreateComponent,
    CategoryEditComponent,
    UserViewComponent,
    CampaignViewComponent,
    CampaignCreateComponent,
    CampaignEditComponent,
    CustomerViewComponent,
    ProductViewComponent,
    ProductCreateComponent,
    ProductEditComponent,
    BrandProductComponent,
    ConfigLabelComponent,
    ProductInfoComponent,
    OrderViewComponent,
    OrderSummaryComponent,
    PaymentCreateComponent,
    PaymentEditComponent,
    PaymentViewComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    LayoutModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    HttpClientModule,
    NgMaterialMultilevelMenuModule,
    NgxMatFileInputModule,
    NgImageSliderModule,
    MatImportModule,
    MatNativeDateModule
   
  ],
  entryComponents: [ConfirmDialogComponent],
  providers: [
    DatePipe,
    DecimalPipe,
    MultilevelMenuService,
    NotifyService,
    AuthenticationService,
    UserService,
    DbUtilityService,
    BrandService,
    CategoryService,
    SubcategoryService,
    ShippingService,
    UserDataService,
    CampaignService,
    CustomerService,
    SignalrService,
    ProductService,
    ProductConfigService,
    OrderService,
    PaymentService,
    AuthGuard,
    SignalrService, {
      provide: APP_INITIALIZER, useFactory: (svc: SignalrService) => () => svc.initiateConnection(),
      deps: [SignalrService],
      multi: true
    },
    { provide: HTTP_INTERCEPTORS, useClass: JwtTokenInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: HttpErrorInterceptor, multi: true },
    { provide: ErrorHandler, useClass: GlobalErrorHandler }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
