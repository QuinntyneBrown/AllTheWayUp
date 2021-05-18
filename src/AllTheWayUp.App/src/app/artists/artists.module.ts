import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArtistListComponent } from './artist-list/artist-list.component';
import { ArtistDetailComponent } from './artist-detail/artist-detail.component';
import { ArtistEditorComponent } from './artist-editor/artist-editor.component';
import { SharedModule } from '@shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ArtistComponent } from './artist/artist.component';



@NgModule({
  declarations: [
    ArtistListComponent,
    ArtistDetailComponent,
    ArtistEditorComponent,
    ArtistComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forChild([
      { 
        path: "", component: ArtistListComponent,
      },
      { 
        path: ":id", component: ArtistComponent,
      }      
    ])
  ]
})
export class ArtistsModule { }
