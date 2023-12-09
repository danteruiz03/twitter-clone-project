import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FeedComponent } from './feed/feed.component';
import { feedResolver } from 'src/app/resolvers/feed.resolver';
import { ProfileComponent } from './feed/profile/profile.component';
import { profileResolver } from 'src/app/resolvers/profile.resolver';

const routes: Routes = [
  { path: '', pathMatch: 'full', component: FeedComponent, resolve: { feedData: feedResolver } },
  { path: ':userName', pathMatch: 'full', component: ProfileComponent, resolve: { profileData: profileResolver } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FeedRoutingModule { }
