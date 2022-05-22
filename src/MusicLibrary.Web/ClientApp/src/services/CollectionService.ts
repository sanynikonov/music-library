import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable, Inject } from "@angular/core";
import { Observable } from "rxjs";
import { CollectionModel } from "src/models/CollectionModel";
import { PagedList } from "src/models/PagedList";

@Injectable({
  providedIn: "root"
})
export class CollectionService {
  root : string;

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string){this.root = `${baseUrl}api/`}

  getCollections(search: string, type: string, page: number, limit: number): Observable<PagedList<CollectionModel>> {
    const params = new HttpParams()
      .set("SearchString", search)
      .set("ReleaseType", type)
      .set("PageNumber", page)
      .set("PageSize", limit);

    return this.http.get<PagedList<CollectionModel>>(`${this.root}collections`, { params: params });
  }
}
