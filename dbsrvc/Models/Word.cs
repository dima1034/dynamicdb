using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;

namespace dbsrvc.Models {
	public class Word {
		public virtual int Id { get; set; }
		public virtual string Value { get; set; }
	}

	public class WordMap : ClassMap<Word> {
		public WordMap() {
			Id(x => x.Id);
			Map(x => x.Value);
		}
	}
}