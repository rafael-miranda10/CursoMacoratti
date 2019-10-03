import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { ProdutoComponent } from './components/produto/produto.component';
import { CategoriaComponent } from './components/categoria/categoria.component';
import { FornecedorComponent } from './components/fornecedor/fornecedor.component';
import { ReactiveFormsModule } from '@angular/forms';

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        ProdutoComponent,
        CategoriaComponent,
        FornecedorComponent
    ],
    imports: [
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'produto', component: ProdutoComponent },
            { path: 'categoria', component: CategoriaComponent },
            { path: 'fornecedor', component: FornecedorComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
};
