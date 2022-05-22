import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { CollectionService } from 'src/services/CollectionService';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.css']
})
export class SearchResultComponent implements OnInit {

  result: any = "No result";
  constructor(private route: ActivatedRoute, private service: CollectionService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      if (params["searchTerm"]) {
        const searchString = params["searchTerm"];
        this.service.getCollections(searchString, "LongPlay", 1, 5)
          .subscribe(
            data => this.result = data,
            error => console.log(error));
      }
    });
  }

}
