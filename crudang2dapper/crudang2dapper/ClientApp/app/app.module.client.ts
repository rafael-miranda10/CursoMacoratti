import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { sharedConfig } from './app.module.shared';
import { AppService } from './Services/app.service';
import { CategoriaService } from './Services/categoria.service';
import { FornecedorService } from './Services/fornecedor.service';

@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: sharedConfig.declarations,
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        ReactiveFormsModule,
        ...sharedConfig.imports
    ],
    providers:
    [
        AppService,CategoriaService,FornecedorService,
        { provide: 'ORIGIN_URL', useValue: location.origin }
    ]
})
export class AppModule {
}
