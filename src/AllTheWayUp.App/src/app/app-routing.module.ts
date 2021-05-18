import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path:"",
    loadChildren: () => import("src/app/artists/artists.module").then(x => x.ArtistsModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    scrollPositionRestoration:"top"
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
