import { Component, Inject, OnInit } from '@angular/core';
import { ApiStudyService } from '../../services/api-study.service';

@Component({
    selector: 'app-product',
    templateUrl: './product.component.html'
})
export class ProductComponent implements OnInit {

    productsRoot: PagedList = <PagedList>{
        hasPrevious: false,
        hasNext: false

    }
    products: Product[] = []
    pageIndex:number = 0
    pageSize:number = 10 
    term:string = ""  

    pagination:any = {
        TotalItems: 100,
        CurrentPage: 1,
        PageSize: 10,
        TotalPageLinkButtons: 5
      };

    constructor(private productService:ApiStudyService) { 
    }

    ngOnInit(): void {
        this.searchForm()
    }

    initPage() {
        this.pagination = {
            TotalItems: this.productsRoot.totalCount,
            CurrentPage: this.productsRoot.currentPage,
            PageSize: this.productsRoot.pageSize,
            TotalPageLinkButtons: 5
        }
        this.products = this.productsRoot.sources;
    }

    searchForm() {
        this.pageIndex = 0
        this.fetchData()
     
    }

    fetchData() { 
        this.productService.search(this.term, this.pageIndex, this.pageSize)
            .subscribe(result => {
                this.productsRoot = result.json() as PagedList;
                this.initPage();
            }, error => console.error(error));
    }

    nextPage() {
        this.pageIndex++;
        this.fetchData();
    }

    prevPage(){
        this.pageIndex--;
        if(this.pageIndex < 0)
            this.pageIndex = 0;

        this.fetchData();
    }

    hasPrevPage(){
        return this.productsRoot.hasPrevious
    }

    hasNextPage(){
        return this.productsRoot.hasNext
    }

    hasSearchLength(){
        return this.term.length > 0
    }


    /* Paging Component metod */
    onPagination(event:any) {
        this.pagination.CurrentPage = event.currentPage;
        this.pagination.TotalItems = event.totalItems;
        this.pagination.PageSize = event.pageSize;
        this.pagination.TotalPageLinkButtons = event.totalPageLinkButtons;
      }
}

interface Product {
    id: number;
    name: string;
    lastModified: Date; 
}

interface PagedList {
    sources: Product[]
    currentPage: number
    totalPages: number
    pageSize: number
    totalCount: number
    hasPrevious: boolean
    hasNext: boolean 

}
