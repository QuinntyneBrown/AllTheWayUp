import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TrackListComponent } from './track-list/track-list.component';
import { TrackDetailComponent } from './track-detail/track-detail.component';
import { TrackEditorComponent } from './track-editor/track-editor.component';



@NgModule({
  declarations: [
    TrackListComponent,
    TrackDetailComponent,
    TrackEditorComponent
  ],
  imports: [
    CommonModule
  ]
})
export class TracksModule { }
