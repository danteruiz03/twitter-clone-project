import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AuthService } from './services/auth.service';
// import { first, firstValueFrom, of } from 'rxjs';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { ProfileComponent } from './components/feed/feed/profile/profile.component';

// function appInit(authService: AuthService) {
//   console.log('checked')
//   return async () => {

//     const value = await firstValueFrom(authService.tokenInit());
//     console.log(value)

//     return new Promise((resolve) => {
//       resolve('done');
//     })
//   }
// }

@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
  ],
  providers: [
    AuthService,
    // {
    //   provide: APP_INITIALIZER,
    //   useFactory: appInit,
    //   deps: [AuthService],
    //   multi: true
    // },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
