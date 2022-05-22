import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { CollectionModel } from 'src/models/CollectionModel';
import { CollectionService } from 'src/services/CollectionService';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.css']
})
export class SearchResultComponent implements OnInit {

  result: any = "No result";

  albums: CollectionModel[] = [];
  playlists: CollectionModel[] = [];
  singles: CollectionModel[] = [];
  eps: CollectionModel[] = [];

  constructor(private route: ActivatedRoute, private service: CollectionService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      if (params["searchTerm"]) {
        const searchString = params["searchTerm"];
        this.requestData(searchString, "LongPlay", data => this.albums = data);
        this.requestData(searchString, "", data => this.playlists = data);
        this.requestData(searchString, "Single", data => this.singles = data);
        this.requestData(searchString, "ExtendedPlay", data => this.eps = data);
      }
    });
  }

  requestData(searchString: string, type: string, handler: (data: CollectionModel[]) => void) {
    this.service.getCollections(searchString, type, 1, 5)
      .subscribe(
        list => handler(list.data),
        error => {
          if (error.status === 404)
            handler([]);
          console.log(error);
        });
  }

}
