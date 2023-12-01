import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FeedComponent } from './feed/feed.component';
import { feedResolver } from 'src/app/resolvers/feed.resolver';

const routes: Routes = [{
  path: '', pathMatch: 'full', component: FeedComponent, resolve: {feedData: feedResolver}
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FeedRoutingModule { }
