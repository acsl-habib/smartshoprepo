import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SettingsComponent } from './components/admin/settings/settings.component';
import { UserViewComponent } from './components/admin/user-management/user-view/user-view.component';
import { BrandCreateComponent } from './components/brand/brand-create/brand-create.component';
import { BrandEditComponent } from './components/brand/brand-edit/brand-edit.component';
import { BrandProductComponent } from './components/brand/brand-product/brand-product.component';
import { BrandViewComponent } from './components/brand/brand-view/brand-view.component';
import { CampaignCreateComponent } from './components/campaign/campaign-create/campaign-create.component';
import { CampaignEditComponent } from './components/campaign/campaign-edit/campaign-edit.component';
import { CampaignViewComponent } from './components/campaign/campaign-view/campaign-view.component';
import { CategoryCreateComponent } from './components/category/category-create/category-create.component';
import { CategoryEditComponent } from './components/category/category-edit/category-edit.component';
import { CategoryViewComponent } from './components/category/category-view/category-view.component';
import { CustomerViewComponent } from './components/customer/customer-view/customer-view.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { OrderSummaryComponent } from './components/order/order-summary/order-summary.component';
import { OrderViewComponent } from './components/order/order-view/order-view.component';
import { PaymentCreateComponent } from './components/payment/payment-create/payment-create.component';
import { PaymentEditComponent } from './components/payment/payment-edit/payment-edit.component';
import { PaymentViewComponent } from './components/payment/payment-view/payment-view.component';
import { ProductCreateComponent } from './components/product/product-create/product-create.component';
import { ProductEditComponent } from './components/product/product-edit/product-edit.component';
import { ProductInfoComponent } from './components/product/product-info/product-info.component';
import { ProductViewComponent } from './components/product/product-view/product-view.component';
import { ShippingCreateComponent } from './components/shipping/shipping-create/shipping-create.component';
import { ShippingEditComponent } from './components/shipping/shipping-edit/shipping-edit.component';
import { ShippingViewComponent } from './components/shipping/shipping-view/shipping-view.component';
import { SizeCreateComponent } from './components/size/size-create/size-create.component';
import { SizeEditComponent } from './components/size/size-edit/size-edit.component';
import { SizeViewComponent } from './components/size/size-view/size-view.component';
import { ConfigLabelComponent } from './components/subcategory/config-label/config-label.component';
import { SubcategoryCreateComponent } from './components/subcategory/subcategory-create/subcategory-create.component';
import { SubcategoryEditComponent } from './components/subcategory/subcategory-edit/subcategory-edit.component';
import { SubcategoryViewComponent } from './components/subcategory/subcategory-view/subcategory-view.component';
import { AuthGuard } from './guards/auth-guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  {path:'login', component:LoginComponent},
  {path:'settings', component:SettingsComponent, canActivate:[AuthGuard],data: { AllowedRoles: ["Admin"] }},
  {path:'brands', component:BrandViewComponent, canActivate:[AuthGuard],data: { AllowedRoles: ["Admin", "Staff"] }},
  {path:'brand-create', component:BrandCreateComponent, canActivate:[AuthGuard],data: { AllowedRoles: ["Admin", "Staff"] }},
  { path: 'brand-edit/:id', component: BrandEditComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'brand-product/:id', component: BrandProductComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'categories', component: CategoryViewComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'category-edit/:id', component: CategoryEditComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'category-create', component: CategoryCreateComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'shipping', component: ShippingViewComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'shipping-create', component: ShippingCreateComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'shipping-edit/:id', component: ShippingEditComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'sizes', component: SizeViewComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'size-create', component: SizeCreateComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'size-edit/:id', component: SizeEditComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'subcategories', component: SubcategoryViewComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'subcategory-create', component: SubcategoryCreateComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'product-config', component: ConfigLabelComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'subcategory-edit/:id', component: SubcategoryEditComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'users', component: UserViewComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin"] } },
  { path: 'campaigns', component: CampaignViewComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'campaign-create', component: CampaignCreateComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'campaign-edit/:id', component: CampaignEditComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'customers', component: CustomerViewComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } }, 
  { path: 'products', component: ProductViewComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'product-create', component: ProductCreateComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'product-edit/:id', component: ProductEditComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'product-info/:id', component: ProductInfoComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'orders', component: OrderViewComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'order-full/:id', component: OrderSummaryComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'payments', component: PaymentViewComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'payment-create', component: PaymentCreateComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
  { path: 'payment-edit/:id', component: PaymentEditComponent, canActivate: [AuthGuard], data: { AllowedRoles: ["Admin", "Staff"] } },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
