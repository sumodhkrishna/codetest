import { DeliveryService } from "./delivery-service";
import { TestBed } from "@angular/core/testing";
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
describe('DeliveryService', () => {
    let deliveryService:DeliveryService;
    let httpMock: HttpTestingController;
    beforeEach(()=> {
        TestBed.configureTestingModule({
            imports:[
                HttpClientTestingModule

            ],
            providers:[
                deliveryService
            ]
        });
        deliveryService = TestBed.get(DeliveryService);
        httpMock = TestBed.get(HttpTestingController);

    })

    it('should return error if country request failed', (done) => {
        deliveryService.getAllOrders().subscribe((res:any)=>{
            done();
        })
    
        let countryRequest = httpMock.expectOne("http://localhost:50782/api/Delivery");
    
    
        httpMock.verify();
      });
})