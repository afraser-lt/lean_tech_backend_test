// carriers
{
	id: "string",
	name: "string",
	scac: "string",
	mc: 0,
	dot: 0,
	fein: 0,
	rate: 0
}
//customers
{
	id: "string",
	name: "string"
}

//orders
{
	id: "string",
	number: "string",
	packages: 0,
	weight: 0,
	pallet: true,
	slip: true,
	shippperInfo: "string"
}

//customer_orders
{
	id: "string",
	customer: {},
	orders: [{}]
}

//receivers
{
	id: "string",
	name: "string"
}

//packagin_types
{
	id: "string",
	name: "string",
	heigth: 0,
	width: 0,
	length: 0,
	description: "string"
}

//shippmets
{
	id: "string",
	date: "string",
	originCountry: "string",
	originState: "string",
	originCity: "string",
	destinationCountry: "string",
	destinationState: "string",
	destinationCity: "string",
	pickupDate: "string",
	deliveryDate: "string",
	status: "string",
	carrier: {}
}

//BOLs
{
  id: "string",
  po: "string",
  specialInstruction: "string",
  itemsDesciptions: "string",
  packaginType: {},
  receiver: {},
  shipment: {}
  customerOrders: [{}]
}