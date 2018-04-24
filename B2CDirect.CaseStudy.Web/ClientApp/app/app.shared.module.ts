import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component'; 
import { ProductComponent } from './components/product/product.component';  

@NgModule({
    declarations: [
        AppComponent, 
        ProductComponent 
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'products', pathMatch: 'full' },
            { path: 'products', component: ProductComponent }, 
            { path: '**', redirectTo: 'products' }
        ])
    ]
})
export class AppModuleShared {
}
