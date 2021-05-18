import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { ArtistService } from './artists/artist.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  
  public vm$: Observable<any> = this._artistService.get()
  .pipe(
    map(x => {
      return {
        navItems: x.map(x => ({ 
          label: x.name,
          url: [x.artistId]
        }))
      }
    })
  );

  constructor(
    private readonly _artistService: ArtistService
  ) {

  }


}
