import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';
import { ClienteService } from './Services/cliente.service';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        FormsModule,
        AppModuleShared

    ],
    providers: [
        ClienteService,
        { provide: 'BASE_URL', useFactory: getBaseUrl }
    ]
})
export class AppModule {
}

export function getBaseUrl() {
    return document.getElementsByTagName('base')[0].href;
}
