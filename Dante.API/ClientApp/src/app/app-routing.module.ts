import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { feedGuard } from './guards/feed.guard';
import { userResolver } from './resolvers/user.resolver';

const routes: Routes = [
  {
    path: 'auth',
    loadChildren: () => import('./components/user/user.module').then(m => m.UserModule)
  },
  {
    path: '',
    loadChildren: () => import('./components/feed/feed.module').then(m => m.FeedModule),
    canActivate: [feedGuard],
    resolve: { userData: userResolver }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
