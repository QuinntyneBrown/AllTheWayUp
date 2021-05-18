import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { ArtistService } from '../artist.service';

@Component({
  selector: 'app-artist',
  templateUrl: './artist.component.html',
  styleUrls: ['./artist.component.scss']
})
export class ArtistComponent {

  public vm$ = this._activatedRoute.paramMap
  .pipe(
    switchMap(paramMap => {
      const artistId = paramMap.get("id") as string;
      return this._artistService.getById({ artistId })
    })
  );
  
  constructor(
    private readonly _artistService: ArtistService,
    private readonly _activatedRoute: ActivatedRoute
  ) { }
}
