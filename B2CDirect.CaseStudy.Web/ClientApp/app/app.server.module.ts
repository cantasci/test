import { NgModule } from '@angular/core';
import { ServerModule } from '@angular/platform-server';
import { AppModuleShared } from './app.shared.module';
import { AppComponent } from './components/app/app.component';
import { ApiStudyService } from './services/api-study.service'; 

@NgModule({
    bootstrap: [ AppComponent ],
    imports: [
        ServerModule,
        AppModuleShared
    ], 
    providers: [ 
        ApiStudyService        
    ]
})
export class AppModule {
}
