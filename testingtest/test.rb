#!/usr/bin/ruby
# -*- coding: utf-8 -*-

def diff(exp, got)
  ret = ""
  dexp = exp.split "\n"
  dgot = got.split "\n"
  failed = false
  [dexp.length, dgot.length].max.times do |i|
    if dexp[i] == dgot[i] then
      ret += ">  . " + dexp[i] + "\n"
    else
      failed = true
      ret += ">  ! expected: '" + (dexp[i] or "<nothing>") + "', got: '" + (dgot[i] or "<nothing>") + "'\n"
    end
  end
  return ret if failed
  return nil
end

teststring = `#{ARGV * " "}`

#puts "profile:"
#s = `gprof #{(ARGV * " ").match(/[^\s]+/)[0]}`
#unit = s.match(/(?<unit>\S*)\/call\s*name/)[:unit]
#s.scan(/(?:\d{1,3}\.\d\d\s+)(\d{1,3}\.\d\d)\s+\d{1,3}\.\d\d\s+(\d+)\s+\d{1,3}\.\d\d\s+(\d{1,3}\.\d\d)\s+([^\s_][^\n]*)/m).each do
#  |data|
#  puts " >" + data[3] + " executed " + data[0] + "s, " + data[1] + " x " + data[2] + unit if not /void out</.match data[3]
#end

s1 = s2 = ""
puts "test:"
# output syntax: [<id>\n<exp1[\nexpn]*>$$$<got1[\ngotn]*>$$$\n]*
teststring.scan(/([^\n]+)\n([^§]+)§§§\n([^§]+)§§§\n/m).each do |data|
  print "> " + data[0] + ": "
  s = diff(data[1], data[2])
  if s then
    puts "fail!\n" + s
  else
    puts "ok"
  end
end
