import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./Modules/user/user.module').then(m => m.UserModule)
  },
  {
    path: 'product',
    loadChildren: () => import('./Modules/product/product.module').then(m => m.ProductModule)
  },
  {
    path: '**',
    component: PageNotFoundComponent,
   }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
